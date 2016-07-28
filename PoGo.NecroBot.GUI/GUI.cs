using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PoGo.NecroBot.Logic;
using PoGo.NecroBot.Logic.Logging;
using PoGo.NecroBot.Logic.State;
using PoGo.NecroBot.Logic.Utils;
using System.Threading;
using System.Diagnostics;
using System.Globalization;
using System.Collections;
using POGOProtos.Inventory.Item;
using POGOProtos.Enums;
using PoGo.NecroBot.Logic.PoGoUtils;
using GUI.Utils;
using PoGo.NecroBot.Logic.Event;
using System.IO;
using POGOProtos.Data;
using GMap.NET.WindowsForms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms.Markers;
using PoGo.NecroBot.GUI.Util;

namespace PoGo.NecroBot.GUI
{
    public partial class GUI : Form
    {
        private static System.Windows.Forms.Timer _exphrUpdater;

        private static GUIStats _guiStats = new GUIStats();
        private static GUIItems _guiItems = new GUIItems();
        private static GUIPokemons _guiPokemons = new GUIPokemons();
        private static GUILiveMap _guiLiveMap = new GUILiveMap();

        private static Session _session;
        private static StateMachine _machine;

        private static Dictionary<string, Bitmap> _imagesList = new Dictionary<string, Bitmap>();

        private static Dictionary<string, GMapOverlay> _mapOverlays;

        public GUI()
        {
            InitializeComponent();
        }

        private void GUI_Load(object sender, EventArgs e)
        {
            this.Show();
            InitImageList();

            var subPath = "";
            var profilePath = "";

            GUILogin loadProfile = new GUILogin();
            var result = loadProfile.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                profilePath = loadProfile.ProfileFolder;
                subPath = "\\config\\profiles\\" + loadProfile.ProfileName;
            }
            //return;
            

            Logger.SetLogger(new GUILogger(LogLevel.Info, this), subPath);

            var settings = GlobalSettings.Load(profilePath);
            settings.AutoUpdate = false;

            _machine = new StateMachine();
            _session = new Session(new ClientSettings(settings), new LogicSettings(settings));

            _guiItems.DirtyEvent += () => UpdateMyItems();
            _guiPokemons.DirtyEvent += () => UpdateMyPokemons();
            _guiLiveMap.DirtyEvent += () => UpdateLiveMap();

            var listener = new GUIEventListener();
            var statsAggregator = new GUIStatsAggregator(_guiStats);
            var itemsAggregator = new GUIItemsAggregator(_guiItems);
            var pokemonsAggregator = new GUIPokemonsAggregator(_guiPokemons);
            var livemapAggregator = new GUILiveMapAggregator(_guiLiveMap);

            _session.EventDispatcher.EventReceived += (IEvent evt) => listener.Listen(evt, _session);
            _session.EventDispatcher.EventReceived += (IEvent evt) => statsAggregator.Listen(evt, _session);
            _session.EventDispatcher.EventReceived += (IEvent evt) => itemsAggregator.Listen(evt, _session);
            _session.EventDispatcher.EventReceived += (IEvent evt) => pokemonsAggregator.Listen(evt, _session);
            _session.EventDispatcher.EventReceived += (IEvent evt) => livemapAggregator.Listen(evt, _session);

            _machine.SetFailureState(new LoginState());

            _session.Navigation.UpdatePositionEvent +=
                (lat, lng) => _session.EventDispatcher.Send(new UpdatePositionEvent { Latitude = lat, Longitude = lng });

            _session.Client.Login.GoogleDeviceCodeEvent += LoginWithGoogle;

            _machine.AsyncStart(new VersionCheckState(), _session);

            _exphrUpdater = new System.Windows.Forms.Timer();
            _exphrUpdater.Interval = 1000;
            _exphrUpdater.Tick += new EventHandler(UpdateStats);
            _exphrUpdater.Start();

            gMap.MapProvider = GoogleMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gMap.Zoom = 15;

            _mapOverlays = new Dictionary<string, GMapOverlay>();
            _mapOverlays.Add("pokemons", new GMapOverlay("pokemons"));
            gMap.Overlays.Add(_mapOverlays["pokemons"]);

            _mapOverlays.Add("pokestops", new GMapOverlay("pokestops"));
            gMap.Overlays.Add(_mapOverlays["pokestops"]);

            _mapOverlays.Add("pokegyms", new GMapOverlay("pokegyms"));
            gMap.Overlays.Add(_mapOverlays["pokegyms"]);

            _mapOverlays.Add("player", new GMapOverlay("player"));
            gMap.Overlays.Add(_mapOverlays["player"]);

            _mapOverlays.Add("path", new GMapOverlay("path"));
            gMap.Overlays.Add(_mapOverlays["path"]);

            Bitmap player = new Bitmap(_imagesList["player"]);
            player.MakeTransparent(Color.White);
            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(_session.Client.CurrentLatitude, _session.Client.CurrentLongitude), player);
            _mapOverlays["player"].Markers.Add(marker);
            gMap.Position = new PointLatLng(_session.Client.CurrentLatitude, _session.Client.CurrentLongitude);
            textCurrentLatLng.Text = _session.Client.CurrentLatitude.ToString() + "," + _session.Client.CurrentLongitude.ToString();
        }

        private void InitImageList()
        {
            var resourceImages = PoGoImages.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, false);

            if (resourceImages != null)
            {
                foreach (DictionaryEntry entry in resourceImages)
                {
                    var value = entry.Value as Bitmap;
                    if (value != null)
                    {
                        Bitmap bmp = new Bitmap(value, new Size(40, 30));
                        _imagesList.Add((string)entry.Key, bmp);
                    }
                }
            }
        }

        public static void LoginWithGoogle(string usercode, string uri)
        {
            try
            {
                Logger.Write("Google Device Code copied to clipboard");
                Thread.Sleep(2000);
                Process.Start(uri);
                var thread = new Thread(() => Clipboard.SetText(usercode)); //Copy device code
                thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA
                thread.Start();
                thread.Join();
            }
            catch (Exception)
            {
                Logger.Write("Couldnt copy to clipboard, do it manually", LogLevel.Error);
                Logger.Write($"Goto: {uri} & enter {usercode}", LogLevel.Error);
            }
        }

        public void UpdateLog(LogLevel level, string message, Color color)
        {
            DataGridViewRow newRow = new DataGridViewRow();

            newRow.CreateCells(dataGridConsole, DateTime.Now, level.ToString(), message);

            newRow.DefaultCellStyle.ForeColor = color;
            newRow.DefaultCellStyle.SelectionForeColor = color;
            //newRow.DefaultCellStyle.BackColor = Color.Black;
            //newRow.DefaultCellStyle.SelectionBackColor = Color.Black;

            dataGridConsole.Invoke(new Action(() => dataGridConsole.Rows.Add(newRow)));
            dataGridConsole.Invoke(new Action(() => dataGridConsole.FirstDisplayedScrollingRowIndex = dataGridConsole.RowCount - 1));
            dataGridConsole.Invoke(new Action(() => dataGridConsole.Refresh()));
        }

        private void UpdateStats(Object myObject, EventArgs myEventArgs)
        {
            textPlayerName.Invoke(new Action(() => textPlayerName.Text = _guiStats._playerName));
            textPlayerLevel.Invoke(new Action(() => textPlayerLevel.Text = _guiStats._playerLevel.ToString()));
            textPlayerStardust.Invoke(new Action(() => textPlayerStardust.Text = _guiStats._playerStardust.ToString()));
            textPlayerPokecoins.Invoke(new Action(() => textPlayerPokecoins.Text = _guiStats._playerPokecoins.ToString()));

            int max = (int)_guiStats._playerNextLevelXp - (int)_guiStats._playerPrevLevelXp - Statistics.GetXpDiff(_guiStats._playerLevel);
            int current = (int)_guiStats._playerExperience - (int)_guiStats._playerPrevLevelXp - Statistics.GetXpDiff(_guiStats._playerLevel);

            if (current < max)
            {
                progressPlayerExpBar.Invoke(new Action(() => progressPlayerExpBar.Maximum = max));
                progressPlayerExpBar.Invoke(new Action(() => progressPlayerExpBar.Value = current));
            }

            labelPlayerExpOverLevelExp.Invoke(new Action(() => labelPlayerExpOverLevelExp.Text = progressPlayerExpBar.Value.ToString() + "/" + progressPlayerExpBar.Maximum.ToString()));

            labelPlayerExpHr.Invoke(new Action(() => labelPlayerExpHr.Text = Math.Round(_guiStats._sessionExperience / _guiStats.GetRuntime(), 0).ToString() + " xp/hr"));
            labelPlayerPokeHr.Invoke(new Action(() => labelPlayerPokeHr.Text = Math.Round(_guiStats._sessionPokemon / _guiStats.GetRuntime(), 0).ToString() + " p/hr"));


            this.Invoke(new Action(() => this.Text = _guiStats.ToString()));
        }

        private void UpdateMyPokemons()
        {
            var currentPokemonList = dataMyPokemons.Rows.OfType<DataGridViewRow>().ToArray();

            foreach (var line in currentPokemonList)
            {
                if (_guiPokemons._pokemons.Where(p => p.Value.Id == (ulong)line.Cells[0].Value).ToList().Count == 0)
                {
                    dataMyPokemons.Invoke(new Action(() => dataMyPokemons.Rows.Remove(line)));
                }
            }

            foreach (var pokemon in _guiPokemons._pokemons)
            {
                if (currentPokemonList.Where(p => (ulong)p.Cells[0].Value == pokemon.Value.Id).Count() == 0)
                {
                    string power = pokemon.Value.IndividualAttack.ToString() + "a/" + pokemon.Value.IndividualDefense.ToString() + "d/" + pokemon.Value.IndividualStamina.ToString() + "s";
                    Bitmap evolve = new Bitmap(40, 30);
                    _imagesList.TryGetValue("evolve", out evolve);
                    Bitmap transfer = new Bitmap(40, 30);
                    _imagesList.TryGetValue("transfer", out transfer);
                    Bitmap bmp = new Bitmap(40, 30);
                    if (_imagesList.TryGetValue("pokemon_" + ((int)pokemon.Value.PokemonId).ToString(), out bmp))
                        dataMyPokemons.Invoke(new Action(() => dataMyPokemons.Rows.Add(pokemon.Value.Id, bmp, pokemon.Value.PokemonId.ToString(), pokemon.Value.Cp, PokemonInfo.CalculateMaxCp(pokemon.Value), Math.Round(PokemonInfo.CalculatePokemonPerfection(pokemon.Value), 1), PokemonInfo.GetLevel(pokemon.Value), pokemon.Value.Move1.ToString(), pokemon.Value.Move2.ToString(), power, evolve, transfer)));
                    else
                        dataMyPokemons.Invoke(new Action(() => dataMyPokemons.Rows.Add(pokemon.Value.Id, new Bitmap(40, 30), pokemon.Value.PokemonId.ToString(), pokemon.Value.Cp, PokemonInfo.CalculateMaxCp(pokemon.Value), Math.Round(PokemonInfo.CalculatePokemonPerfection(pokemon.Value), 1), PokemonInfo.GetLevel(pokemon.Value), pokemon.Value.Move1.ToString(), pokemon.Value.Move2.ToString(), power, evolve, transfer)));
                }
            }

            //dataMyPokemons.Invoke(new Action(() => dataMyPokemons.Sort(dataMyPokemons.Columns[2], ListSortDirection.Ascending)));
            grpMyPokemons.Invoke(new Action(() => grpMyPokemons.Text = "Pokemons (" + _guiPokemons._pokemons.Count().ToString() + "/" + _guiStats._playerMaxPokemonSpace.ToString() + ")"));
        }

        private void UpdateMyItems()
        {
            // Items
            int total = 0;

            var currentItemList = dataMyItems.Rows.OfType<DataGridViewRow>().ToArray();

            foreach (var line in currentItemList)
            {
                if (_guiItems._items.Where(i => i.Key == (ItemId)line.Cells[0].Value).ToList().Count == 0)
                {
                    dataMyItems.Invoke(new Action(() => dataMyItems.Rows.Remove(line)));
                }
            }

            foreach (var item in _guiItems._items)
            {
                if (currentItemList.Where(p => (ItemId)p.Cells[0].Value == item.Key).Count() == 0)
                {
                    object name = Enum.Parse(typeof(ItemId), ((int)item.Key).ToString());
                    Bitmap bmp = new Bitmap(40, 30);
                    if (_imagesList.TryGetValue("item_" + ((int)item.Key).ToString(), out bmp))
                        dataMyItems.Invoke(new Action(() => dataMyItems.Rows.Add(item.Key, bmp, name, item.Value)));
                    else
                        dataMyItems.Invoke(new Action(() => dataMyItems.Rows.Add(item.Key, new Bitmap(40, 30), name, item.Value)));
                }
                else
                {
                    DataGridViewRow row = currentItemList.Where(p => (ItemId)p.Cells[0].Value == item.Key).FirstOrDefault();
                    if (row != null)
                        dataMyItems.Invoke(new Action(() => dataMyItems[3, row.Index].Value = item.Value));
                }
                total += item.Value;
            }
            tabItems.Invoke(new Action(() => tabItems.Text = "Items (" + total.ToString() + "/" + _guiStats._playerMaxBagSpace.ToString()));

            // Candies
            var currentCandyList = dataMyCandies.Rows.OfType<DataGridViewRow>().ToArray();

            foreach (var line in currentCandyList)
            {
                if (_guiItems._candies.Where(i => i.Key == (PokemonFamilyId)line.Cells[0].Value).ToList().Count == 0)
                {
                    dataMyCandies.Invoke(new Action(() => dataMyCandies.Rows.Remove(line)));
                }
            }

            foreach (var candy in _guiItems._candies)
            {
                if (currentCandyList.Where(p => (PokemonFamilyId)p.Cells[0].Value == candy.Key).Count() == 0)
                {
                    dataMyCandies.Invoke(new Action(() => dataMyCandies.Rows.Add(candy.Key, candy.Key.ToString(), candy.Value)));
                }
                else
                {
                    DataGridViewRow row = currentCandyList.Where(p => (PokemonFamilyId)p.Cells[0].Value == candy.Key).FirstOrDefault();
                    if (row != null)
                        dataMyCandies.Invoke(new Action(() => dataMyCandies[2, row.Index].Value = candy.Value));
                }
            }
        }

        private void UpdateLiveMap()
        {
            // Position
            if (_guiLiveMap._positionUpdated)
            {
                _guiLiveMap._positionUpdated = false;
                gMap.Invoke(new Action(() => gMap.Position = _guiLiveMap._currentPosition));
                textCurrentLatLng.Invoke(new Action(() => textCurrentLatLng.Text = _guiLiveMap._currentPosition.Lat.ToString() + "," + _guiLiveMap._currentPosition.Lng.ToString()));
                _mapOverlays["player"].Markers[0].Position = _guiLiveMap._currentPosition;

                if (_guiLiveMap._lastPosition != null && (_guiLiveMap._lastPosition.Lat != 0 && _guiLiveMap._lastPosition.Lng != 0))
                {
                    List<PointLatLng> polygon = new List<PointLatLng>();
                    polygon.Add(new PointLatLng(_guiLiveMap._lastPosition.Lat, _guiLiveMap._lastPosition.Lng));
                    polygon.Add(new PointLatLng(_guiLiveMap._currentPosition.Lat, _guiLiveMap._currentPosition.Lng));
                    GMapRoute route = new GMapRoute(polygon, "route");

                    route.Stroke.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    route.Stroke.Width = 2;
                    _mapOverlays["path"].Routes.Add(route);
                }
            }

            // PokeStops
            var currentListPokestop = _mapOverlays["pokestops"].Markers.ToList();

            foreach (var line in currentListPokestop)
            {
                if (_guiLiveMap._pokeStops.Where(p => p.Key == (string)line.Tag).ToList().Count == 0)
                {
                    gMap.Invoke(new Action(() => _mapOverlays["pokestops"].Markers.Remove(line)));
                }
            }

            Bitmap pokestopImg = new Bitmap(_imagesList["pokestop"], new Size(20, 20));
            pokestopImg.MakeTransparent(Color.White);

            Bitmap pokestopluredImg = new Bitmap(_imagesList["pokestop_lured"], new Size(20, 20));
            pokestopluredImg.MakeTransparent(Color.White);

            foreach (var pokestop in _guiLiveMap._pokeStops)
            {
                if (currentListPokestop.Where(p => (string)p.Tag == pokestop.Key).Count() == 0)
                {
                    GMarkerGoogle marker;
                    marker = new GMarkerGoogle(new PointLatLng(pokestop.Value.Latitude, pokestop.Value.Longitude), pokestop.Value.LureInfo != null ? pokestopluredImg: pokestopImg);
                    marker.Tag = pokestop.Value.Id;
                    gMap.Invoke(new Action(() => _mapOverlays["pokestops"].Markers.Add(marker)));
                }
            }

            // Pokegyms
            var currentListPokegyms = _mapOverlays["pokegyms"].Markers.ToList();

            foreach (var line in currentListPokegyms)
            {
                if (_guiLiveMap._pokeGyms.Where(p => p.Key == (string)line.Tag).ToList().Count == 0)
                {
                    gMap.Invoke(new Action(() => _mapOverlays["pokegyms"].Markers.Remove(line)));
                }
            }

            Bitmap pokegymImg = new Bitmap(_imagesList["pokegym"], new Size(20, 20));
            pokestopImg.MakeTransparent(Color.White);
 
            foreach (var pokegym in _guiLiveMap._pokeGyms)
            {
                if (currentListPokegyms.Where(p => (string)p.Tag == pokegym.Key).Count() == 0)
                {
                    GMarkerGoogle marker;
                    marker = new GMarkerGoogle(new PointLatLng(pokegym.Value.Latitude, pokegym.Value.Longitude), pokegymImg);
                    marker.Tag = pokegym.Value.Id;
                    gMap.Invoke(new Action(() => _mapOverlays["pokegyms"].Markers.Add(marker)));
                }
            }
        }

        private async void dataMyPokemons_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && 
                e.RowIndex >= 0)
            {
                ulong pokemonId = (ulong)dataMyPokemons.Rows[dataMyPokemons.CurrentCell.RowIndex].Cells[0].Value;
                PokemonData selectedPokemon = _guiPokemons._pokemons[pokemonId];

                switch (e.ColumnIndex)
                {
                    case 10:
                        // Evolve
                        var evolveResponse = await _session.Client.Inventory.EvolvePokemon(selectedPokemon.Id);

                        _session.EventDispatcher.Send(new PokemonEvolveEvent
                        {
                            Id = selectedPokemon.PokemonId,
                            Exp = evolveResponse.ExperienceAwarded,
                            Result = evolveResponse.Result
                        });
                        if(evolveResponse.Result == POGOProtos.Networking.Responses.EvolvePokemonResponse.Types.Result.Success)
                        {
                            _guiPokemons.RemovePokemon(selectedPokemon.Id);
                            _guiPokemons.AddPokemon(evolveResponse.EvolvedPokemonData);
                            UpdateMyPokemons();
                        }
  
                        break;

                    case 11:
                        // Transfer
                        await _session.Client.Inventory.TransferPokemon(selectedPokemon.Id);
                        await _session.Inventory.DeletePokemonFromInvById(selectedPokemon.Id);

                        var pokemonSettings = await _session.Inventory.GetPokemonSettings();
                        var pokemonFamilies = await _session.Inventory.GetPokemonFamilies();

                        var bestPokemonOfType = (_session.LogicSettings.PrioritizeIvOverCp
                            ? await _session.Inventory.GetHighestPokemonOfTypeByIv(selectedPokemon)
                            : await _session.Inventory.GetHighestPokemonOfTypeByCp(selectedPokemon)) ?? selectedPokemon;

                        var setting = pokemonSettings.Single(q => q.PokemonId == selectedPokemon.PokemonId);
                        var family = pokemonFamilies.First(q => q.FamilyId == setting.FamilyId);

                        family.Candy++;

                        _session.EventDispatcher.Send(new TransferPokemonEvent
                        {
                            Id = selectedPokemon.PokemonId,
                            Perfection = PokemonInfo.CalculatePokemonPerfection(selectedPokemon),
                            Cp = selectedPokemon.Cp,
                            BestCp = bestPokemonOfType.Cp,
                            BestPerfection = PokemonInfo.CalculatePokemonPerfection(bestPokemonOfType),
                            FamilyCandies = family.Candy
                        });
                        _guiPokemons.RemovePokemon(pokemonId);
                        UpdateMyPokemons();
                        break;
                }
            }
        }

        private void checkShowPokemons_CheckedChanged(object sender, EventArgs e)
        {
            _mapOverlays["pokemons"].IsVisibile = checkShowPokemons.Checked ? true : false;
        }

        private void checkShowPokestops_CheckedChanged(object sender, EventArgs e)
        {
            _mapOverlays["pokestops"].IsVisibile = checkShowPokestops.Checked ? true : false;
        }

        private void checkShowPokegyms_CheckedChanged(object sender, EventArgs e)
        {
            _mapOverlays["pokegyms"].IsVisibile = checkShowPokegyms.Checked ? true : false;
        }

        private void checkShowPath_CheckedChanged(object sender, EventArgs e)
        {
            _mapOverlays["path"].IsVisibile = checkShowPath.Checked ? true : false;
        }
    }
}
