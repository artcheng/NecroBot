﻿using System;
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
using PoGo.NecroBot.CLI;
using PoGo.NecroBot.Logic.Tasks;
using PoGo.NecroBot.Logic.Common;
using PoGo.NecroBot.GUI.Aggregators;
using PoGo.NecroBot.GUI.Tasks;
using static PoGo.NecroBot.GUI.GUISettings;

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

        private GlobalSettings _settings;
        private ProfileSettings _profileSettings;

        private string _profilePath = "";

        private bool _isStarted = false;

        private bool _currentlySniping = false;

        public GUI()
        {
            InitializeComponent();
        }

        private void GUI_Load(object sender, EventArgs e)
        {
            // for testing, don't mind this
            //_profilePath = "E:\\Nox\\NecroBot\\PoGo.NecroBot.GUI\\bin\\Debug\\config\\profiles\\vorak666";
            //_settings = GlobalSettings.Load(_profilePath);
            //_settings.AutoUpdate = false;

            //_machine = new StateMachine();
            //_session = new Session(new ClientSettings(_settings), new LogicSettings(_settings));

            //this.Show();
            //InitImageList();
            //LoadGUISettings();
            //return;

            this.Show();
            InitImageList();

            var subpath = "";

            GUILogin loadProfile = new GUILogin();
            var result = loadProfile.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                _profilePath = loadProfile._loginProfileFolder;
                subpath = Directory.GetCurrentDirectory() + "\\config\\profiles\\" + loadProfile._loginProfileName;
                _profileSettings = loadProfile._profileSettings;
            }

            Logger.SetLogger(new GUILogger(LogLevel.Info, this), subpath);

            _settings = GlobalSettings.Load(_profilePath);

            if(_settings == null)
            {
                MessageBox.Show("Error loading profile, restart bot and try again.", "Erreor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

            _settings.AutoUpdate = false;
            _settings.AmountOfPokemonToDisplayOnStart = 0;
            _settings.StartupWelcomeDelay = false;

            if (loadProfile._loginUseGPX)
            {
                _settings.UseGpxPathing = loadProfile._loginUseGPX;
                _settings.GpxFile = loadProfile._loginGPXFile;
            }

            if(loadProfile._loginUseLastCoords)
            {
                _settings.DefaultLatitude = loadProfile._loginLastLat;
                _settings.DefaultLongitude = loadProfile._loginLastLng;
            }

            _machine = new StateMachine();
            _session = new Session(new ClientSettings(_settings), new LogicSettings(_settings));
            _session.Client.ApiFailure = new ApiFailureStrategy(_session);
            _session.isAwaitingPaused = false;
            _session.isPaused = false;

            LoadGUISettings();
        }

        private void StartBotting()
        {
            if (_isStarted == true)
            {
                MessageBox.Show("Bot is already running", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Set on first start
            _isStarted = true;

            _guiItems.DirtyEvent += () => UpdateMyItems();
            _guiPokemons.DirtyEvent += () => UpdateMyPokemons();
            _guiLiveMap.DirtyEvent += () => UpdateLiveMap();

            var listener = new GUIEventListener();
            var statsAggregator = new GUIStatsAggregator(_guiStats);
            var itemsAggregator = new GUIItemsAggregator(_guiItems);
            var pokemonsAggregator = new GUIPokemonsAggregator(_guiPokemons);

            _session.EventDispatcher.EventReceived += (IEvent evt) => listener.Listen(evt, _session);
            _session.EventDispatcher.EventReceived += (IEvent evt) => statsAggregator.Listen(evt, _session);
            _session.EventDispatcher.EventReceived += (IEvent evt) => itemsAggregator.Listen(evt, _session);
            _session.EventDispatcher.EventReceived += (IEvent evt) => pokemonsAggregator.Listen(evt, _session);

            if (_profileSettings.UseLiveMap)
            {
                var livemapAggregator = new GUILiveMapAggregator(_guiLiveMap);
                _session.EventDispatcher.EventReceived += (IEvent evt) => livemapAggregator.Listen(evt, _session);
            }

            _machine.SetFailureState(new LoginState());

            _session.Navigation.UpdatePositionEvent +=
                (lat, lng) => _session.EventDispatcher.Send(new UpdatePositionEvent { Latitude = lat, Longitude = lng });

            _machine.AsyncStart(new VersionCheckState(), _session);
            if (_session.LogicSettings.UseSnipeLocationServer)
                SnipePokemonTask.AsyncStart(_session);

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

        public void UpdateConsole(LogLevel level, string message, Color color)
        {
            DataGridViewRow newRow = new DataGridViewRow();

            newRow.CreateCells(dataGridConsole, DateTime.Now, level.ToString(), message);

            newRow.DefaultCellStyle.ForeColor = color;
            newRow.DefaultCellStyle.SelectionForeColor = color;

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
                        dataMyPokemons.Invoke(new Action(() => dataMyPokemons.Rows.Add(pokemon.Value.Id, bmp, pokemon.Value.PokemonId.ToString(), (int)pokemon.Value.PokemonId, pokemon.Value.Cp, PokemonInfo.CalculateMaxCp(pokemon.Value), Math.Round(PokemonInfo.CalculatePokemonPerfection(pokemon.Value), 1), PokemonInfo.GetLevel(pokemon.Value), pokemon.Value.Move1.ToString(), pokemon.Value.Move2.ToString(), power)));
                    else
                        dataMyPokemons.Invoke(new Action(() => dataMyPokemons.Rows.Add(pokemon.Value.Id, new Bitmap(40, 30), pokemon.Value.PokemonId.ToString(), (int)pokemon.Value.PokemonId, pokemon.Value.Cp, PokemonInfo.CalculateMaxCp(pokemon.Value), Math.Round(PokemonInfo.CalculatePokemonPerfection(pokemon.Value), 1), PokemonInfo.GetLevel(pokemon.Value), pokemon.Value.Move1.ToString(), pokemon.Value.Move2.ToString(), power)));
                }
            }

            tabMyPokemons.Invoke(new Action(() => tabMyPokemons.Text = "Pokemons (" + _guiPokemons._pokemons.Count().ToString() + "/" + _guiStats._playerMaxPokemonSpace.ToString() + ")"));
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
            if (!_currentlySniping)
            {
                try
                {
                    // Position
                    if (_guiLiveMap._positionUpdated)
                    {
                        _guiLiveMap._positionUpdated = false;
                        gMap.Invoke(new Action(() => gMap.Position = _guiLiveMap._currentPosition));
                        textCurrentLatLng.Invoke(new Action(() => textCurrentLatLng.Text = _guiLiveMap._currentPosition.Lat.ToString() + "," + _guiLiveMap._currentPosition.Lng.ToString()));
                        _mapOverlays["player"].Markers[0].Position = _guiLiveMap._currentPosition;

                        if (_guiLiveMap._lastPosition != null && (_guiLiveMap._lastPosition.Lat != 0 && _guiLiveMap._lastPosition.Lng != 0) && LocationUtils.CalculateDistanceInMeters(_guiLiveMap._currentPosition.Lat, _guiLiveMap._currentPosition.Lng, _guiLiveMap._lastPosition.Lat, _guiLiveMap._lastPosition.Lng) < 2000)
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
                            marker = new GMarkerGoogle(new PointLatLng(pokestop.Value.Latitude, pokestop.Value.Longitude), pokestop.Value.LureInfo != null ? pokestopluredImg : pokestopImg);
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

                    // Pokemons
                    var currentListPokemons = _mapOverlays["pokemons"].Markers.ToList();

                    foreach (var line in currentListPokemons)
                    {
                        if (_guiLiveMap._mapPokemons.Where(p => p.Key == (ulong)line.Tag).ToList().Count == 0)
                        {
                            gMap.Invoke(new Action(() => _mapOverlays["pokemons"].Markers.Remove(line)));
                        }
                    }

                    foreach (var pokemon in _guiLiveMap._mapPokemons)
                    {
                        if (currentListPokemons.Where(p => (ulong)p.Tag == pokemon.Key).Count() == 0)
                        {
                            Bitmap pokemonImg = new Bitmap(40, 30);
                            _imagesList.TryGetValue("pokemon_" + ((int)pokemon.Value.PokemonId).ToString(), out pokemonImg);

                            GMarkerGoogle marker;
                            marker = new GMarkerGoogle(new PointLatLng(pokemon.Value.Latitude, pokemon.Value.Longitude), pokemonImg);
                            marker.Tag = pokemon.Value.EncounterId;
                            gMap.Invoke(new Action(() => _mapOverlays["pokemons"].Markers.Add(marker)));
                        }
                    }
                }
                catch
                {
                    // error with livemap
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

        private void LoadGUISettings()
        {
            // Global
            globalSettingsControl.SetSetting("AmountOfPokemonToDisplayOnStart", _session.LogicSettings.AmountOfPokemonToDisplayOnStart.ToString());
            globalSettingsControl.SetSetting("AutoUpdate", _session.LogicSettings.AutoUpdate.ToString());
            globalSettingsControl.SetSetting("DefaultAltitude", _session.Settings.DefaultAltitude.ToString(".0"));
            globalSettingsControl.SetSetting("DefaultLatitude", _session.Settings.DefaultLatitude.ToString());
            globalSettingsControl.SetSetting("DefaultLongitude", _session.Settings.DefaultLongitude.ToString());
            globalSettingsControl.SetSetting("DelayBetweenPokemonCatch", _session.LogicSettings.DelayBetweenPokemonCatch.ToString());
            globalSettingsControl.SetSetting("DelayBetweenPlayerActions", _session.LogicSettings.DelayBetweenPlayerActions.ToString());
            globalSettingsControl.SetSetting("UseLuckyEggsMinPokemonAmount", _session.LogicSettings.UseLuckyEggsMinPokemonAmount.ToString());
            globalSettingsControl.SetSetting("UseLuckyEggsWhileEvolving", _session.LogicSettings.UseLuckyEggsWhileEvolving.ToString());
            globalSettingsControl.SetSetting("UseEggIncubators", _session.LogicSettings.UseEggIncubators.ToString());
            globalSettingsControl.SetSetting("DumpPokemonStats", _session.LogicSettings.DumpPokemonStats.ToString());
            globalSettingsControl.SetSetting("GpxFile", _session.LogicSettings.GpxFile);
            globalSettingsControl.SetSetting("UseGpxPathing", _session.LogicSettings.UseGpxPathing.ToString());
            globalSettingsControl.SetSetting("WalkingSpeedInKilometerPerHour", _session.LogicSettings.WalkingSpeedInKilometerPerHour.ToString(".0"));
            globalSettingsControl.SetSetting("MaxTravelDistanceInMeters", _session.LogicSettings.MaxTravelDistanceInMeters.ToString());
            globalSettingsControl.SetSetting("TranslationLanguageCode", _session.LogicSettings.TranslationLanguageCode);

            // Sniping
            snipingSettingsControl.SetSetting("SnipeAtPokestops", _session.LogicSettings.SnipeAtPokestops.ToString());
            snipingSettingsControl.SetSetting("SnipeLocationServer", _session.LogicSettings.SnipeLocationServer.ToString());
            snipingSettingsControl.SetSetting("SnipeLocationServerPort", _session.LogicSettings.SnipeLocationServerPort.ToString());
            snipingSettingsControl.SetSetting("UseSnipeLocationServer", _session.LogicSettings.UseSnipeLocationServer.ToString());
            snipingSettingsControl.SetSetting("UseTransferIVForSnipe", _session.LogicSettings.UseTransferIVForSnipe.ToString());
            snipingSettingsControl.SetSetting("MinDelayBetweenSnipes", _session.LogicSettings.MinDelayBetweenSnipes.ToString());
            snipingSettingsControl.SetSetting("MinPokeballsToSnipe", _session.LogicSettings.MinPokeballsToSnipe.ToString());
            snipingSettingsControl.SetLocations(_session.LogicSettings.PokemonToSnipe.Locations.ToList());

            // Pokemons
            settingsEvolveAboveIvValue.Text = _session.LogicSettings.EvolveAboveIvValue.ToString();
            settingsEvolveAllPokemonAboveIv.Checked = _session.LogicSettings.EvolveAllPokemonAboveIv;
            settingsEvolveAllPokemonWithEnoughCandy.Checked = _session.LogicSettings.EvolveAllPokemonWithEnoughCandy;
            settingsKeepMinCp.Text = _session.LogicSettings.KeepMinCp.ToString();
            settingsKeepMinDuplicatePokemon.Text = _session.LogicSettings.KeepMinDuplicatePokemon.ToString();
            settingsKeepMinIvPercentage.Text = _session.LogicSettings.KeepMinIvPercentage.ToString();
            settingsKeepPokemonsThatCanEvolve.Checked = _session.LogicSettings.KeepPokemonsThatCanEvolve;
            settingsPrioritizeIvOverCp.Checked = _session.LogicSettings.PrioritizeIvOverCp;
            settingsRenameAboveIv.Checked = _session.LogicSettings.RenameAboveIv;
            settingsTransferDuplicatePokemon.Checked = _session.LogicSettings.TransferDuplicatePokemon;
            settingsUsePokemonToNotCatchFilter.Checked = _session.LogicSettings.UsePokemonToNotCatchFilter;

            // Items


            // Pokemon settings
            foreach (PokemonId pokemon in Enum.GetValues(typeof(PokemonId)))
            {
                // Skip pokemon = 0
                if ((int)pokemon > 0)
                {
                    // ToNotCatch
                    bool toNotCatch = false;
                    if (_session.LogicSettings.PokemonsNotToCatch.Where(p => p == pokemon).ToList().Count > 0)
                        toNotCatch = true;

                    //ToEvolve
                    bool toEvolve = false;
                    if (_session.LogicSettings.PokemonsToEvolve.Where(p => p == pokemon).ToList().Count > 0)
                        toEvolve = true;

                    // ToNotTransfer
                    bool toNotTransfer = false;
                    if (_session.LogicSettings.PokemonsNotToTransfer.Where(p => p == pokemon).ToList().Count > 0)
                        toNotTransfer = true;

                    // ToSnipe
                    bool toSnipe = false;
                    if (_session.LogicSettings.PokemonToSnipe.Pokemon.Where(p => p == pokemon).ToList().Count > 0)
                        toSnipe = true;

                    // TransferFilters
                    int KeepMinCp = 0;
                    double KeepMinIvPercentage = 50.0;
                    int KeepMinDuplicatePokemon = 1;

                    if (_session.LogicSettings.PokemonsTransferFilter.ContainsKey(pokemon))
                    {
                        KeepMinCp = _session.LogicSettings.PokemonsTransferFilter[pokemon].KeepMinCp;
                        KeepMinIvPercentage = _session.LogicSettings.PokemonsTransferFilter[pokemon].KeepMinIvPercentage;
                        KeepMinDuplicatePokemon = _session.LogicSettings.PokemonsTransferFilter[pokemon].KeepMinDuplicatePokemon;
                    }

                    Bitmap bmp = new Bitmap(40, 30);
                    _imagesList.TryGetValue("pokemon_" + ((int)pokemon).ToString(), out bmp);
                    dataPokemonSettings.Invoke(new Action(() => dataPokemonSettings.Rows.Add((int)pokemon, bmp, pokemon, KeepMinCp, KeepMinIvPercentage, KeepMinDuplicatePokemon, toNotTransfer, toEvolve, toNotCatch, toSnipe)));
                }
            }

            // Item settings
            foreach (ItemId item in Enum.GetValues(typeof(ItemId)))
            {
                int KeepMax = (int)_session.LogicSettings.ItemRecycleFilter.Where(i => i.Key == item).FirstOrDefault().Value;

                Bitmap bmp = new Bitmap(40, 30);
                _imagesList.TryGetValue("item_" + ((int)item).ToString(), out bmp);
                dataItemSettings.Invoke(new Action(() => dataItemSettings.Rows.Add((int)item, bmp, item, KeepMax)));
            }
        }

        private void cmdSaveSettings_Click(object sender, EventArgs e)
        {
            try
            {
                // Global
                _settings.AmountOfPokemonToDisplayOnStart = Convert.ToInt16(globalSettingsControl.GetSetting("AmountOfPokemonToDisplayOnStart"));
                _settings.AutoUpdate = Convert.ToBoolean(globalSettingsControl.GetSetting("AutoUpdate"));
                _settings.DefaultAltitude = Convert.ToDouble(globalSettingsControl.GetSetting("DefaultAltitude"));
                _settings.DefaultLatitude = Convert.ToDouble(globalSettingsControl.GetSetting("DefaultLatitude"));
                _settings.DefaultLongitude = Convert.ToDouble(globalSettingsControl.GetSetting("DefaultLongitude"));
                _settings.DelayBetweenPokemonCatch = Convert.ToInt16(globalSettingsControl.GetSetting("DelayBetweenPokemonCatch"));
                _settings.DelayBetweenPlayerActions = Convert.ToInt16(globalSettingsControl.GetSetting("DelayBetweenPlayerActions"));
                _settings.UseLuckyEggsMinPokemonAmount = Convert.ToInt16(globalSettingsControl.GetSetting("UseLuckyEggsMinPokemonAmount"));
                _settings.UseLuckyEggsWhileEvolving = Convert.ToBoolean(globalSettingsControl.GetSetting("UseLuckyEggsWhileEvolving"));
                _settings.UseEggIncubators = Convert.ToBoolean(globalSettingsControl.GetSetting("UseEggIncubators"));
                _settings.DumpPokemonStats = Convert.ToBoolean(globalSettingsControl.GetSetting("DumpPokemonStats"));
                _settings.GpxFile = globalSettingsControl.GetSetting("GpxFile");
                _settings.UseGpxPathing = Convert.ToBoolean(globalSettingsControl.GetSetting("UseGpxPathing"));
                _settings.WalkingSpeedInKilometerPerHour = Convert.ToDouble(globalSettingsControl.GetSetting("WalkingSpeedInKilometerPerHour"));
                _settings.MaxTravelDistanceInMeters = Convert.ToInt16(globalSettingsControl.GetSetting("MaxTravelDistanceInMeters"));
                _settings.TranslationLanguageCode = globalSettingsControl.GetSetting("TranslationLanguageCode");

                // Sniping
                _settings.SnipeAtPokestops = Convert.ToBoolean(snipingSettingsControl.GetSetting("SnipeAtPokestops"));
                _settings.SnipeLocationServer = snipingSettingsControl.GetSetting("SnipeLocationServer");
                _settings.SnipeLocationServerPort = Convert.ToInt16(snipingSettingsControl.GetSetting("SnipeLocationServerPort"));
                _settings.UseSnipeLocationServer = Convert.ToBoolean(snipingSettingsControl.GetSetting("UseSnipeLocationServer"));
                _settings.UseTransferIVForSnipe = Convert.ToBoolean(snipingSettingsControl.GetSetting("UseTransferIVForSnipe"));
                _settings.MinDelayBetweenSnipes = Convert.ToInt16(snipingSettingsControl.GetSetting("MinDelayBetweenSnipes"));
                _settings.MinPokeballsToSnipe = Convert.ToInt16(snipingSettingsControl.GetSetting("MinPokeballsToSnipe"));
                _settings.PokemonToSnipe.Locations = snipingSettingsControl.GetLocations();

                // Pokemon
                _settings.EvolveAboveIvValue = Convert.ToSingle(settingsEvolveAboveIvValue.Text);
                _settings.EvolveAllPokemonAboveIv = settingsEvolveAllPokemonAboveIv.Checked;
                _settings.EvolveAllPokemonWithEnoughCandy = settingsEvolveAllPokemonWithEnoughCandy.Checked;
                _settings.KeepMinCp = Convert.ToInt16(settingsKeepMinCp.Text);
                _settings.KeepMinDuplicatePokemon = Convert.ToInt16(settingsKeepMinDuplicatePokemon.Text);
                _settings.KeepMinIvPercentage = Convert.ToSingle(settingsKeepMinIvPercentage.Text);
                _settings.KeepPokemonsThatCanEvolve = settingsKeepPokemonsThatCanEvolve.Checked;
                _settings.PrioritizeIvOverCp = settingsPrioritizeIvOverCp.Checked;
                _settings.RenameAboveIv = settingsRenameAboveIv.Checked;
                _settings.TransferDuplicatePokemon = settingsTransferDuplicatePokemon.Checked;
                _settings.UsePokemonToNotCatchFilter = settingsUsePokemonToNotCatchFilter.Checked;

                // Items

                List<PokemonId> PokemonsNotToTransfer = new List<PokemonId>();
                List<PokemonId> PokemonsToEvolve = new List<PokemonId>();
                List<PokemonId> PokemonsToIgnore = new List<PokemonId>();
                Dictionary<PokemonId, TransferFilter> PokemonsTransferFilter = new Dictionary<PokemonId, TransferFilter>();
                List<PokemonId> PokemonsToSnipe = new List<PokemonId>();

                foreach (DataGridViewRow row in  dataPokemonSettings.Rows)
                {
                    // 6 = PokemonsNotToTransfer
                    if ((bool)row.Cells[6].Value == true)
                        PokemonsNotToTransfer.Add((PokemonId)row.Cells[0].Value);

                    // 7 = PokemonsToEvolve
                    if ((bool)row.Cells[7].Value == true)
                        PokemonsToEvolve.Add((PokemonId)row.Cells[0].Value);

                    // 8 = PokemonsToIgnore
                    if ((bool)row.Cells[8].Value == true)
                        PokemonsToIgnore.Add((PokemonId)row.Cells[0].Value);

                    // 9 = PokemonToSnipe
                    if ((bool)row.Cells[9].Value == true)
                        PokemonsToSnipe.Add((PokemonId)row.Cells[0].Value);

                    // 3 = KeepMinCp, 4 = KeepMinIV, 5 = KeepMinDuplicate
                    TransferFilter newFilter = new TransferFilter();
                    newFilter.KeepMinCp = Convert.ToInt16(row.Cells[3].Value);
                    newFilter.KeepMinIvPercentage = Convert.ToSingle(row.Cells[4].Value);
                    newFilter.KeepMinDuplicatePokemon = Convert.ToInt16(row.Cells[5].Value);
                    PokemonsTransferFilter.Add((PokemonId)row.Cells[0].Value, newFilter);
                }

                _settings.PokemonsNotToTransfer = PokemonsNotToTransfer;
                _settings.PokemonsToEvolve = PokemonsToEvolve;
                _settings.PokemonsToIgnore = PokemonsToIgnore;
                _settings.PokemonsTransferFilter = PokemonsTransferFilter;
                _settings.PokemonToSnipe.Pokemon = PokemonsToSnipe;

                List<KeyValuePair<ItemId, int>> ItemRecycleFilter = new List<KeyValuePair<ItemId, int>>();
                foreach (DataGridViewRow row in dataItemSettings.Rows)
                {
                    ItemRecycleFilter.Add(new KeyValuePair<ItemId, int>((ItemId)row.Cells[0].Value, Convert.ToInt16(row.Cells[3].Value)));
                }

                _settings.ItemRecycleFilter = ItemRecycleFilter;

                _settings.Save(_profilePath+"\\config\\config.json");


                if(_isStarted)
                {
                    MessageBox.Show("Profile has been saved, please restart bot to load new profile", "Profile saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _session = new Session(new ClientSettings(_settings), new LogicSettings(_settings));
                    _session.Client.ApiFailure = new ApiFailureStrategy(_session);
                    MessageBox.Show("Profile has been saved and has been loaded", "Profile saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Error while saving profile, check to make sure values are correct", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdStart_Click(object sender, EventArgs e)
        {
            StartBotting();
        }

        private async void cmdSnipeList_Click(object sender, EventArgs e)
        {
            _currentlySniping = true;
            Dictionary<PokemonId, PointLatLng> snipeList = new Dictionary<PokemonId, PointLatLng>();
            foreach (var line in textPokemonSnipeList.Lines)
            {
                try
                {
                    List<string> splitString = line.Split(' ').Select(s => s.Trim()).ToList();
                    double lat = 0.00;
                    double lng = 0.00;
                    string name = "";
                    int IV = 0;
                    List<string> coords = new List<string>();

                    switch (splitString.Count)
                    {
                        case 3:
                            //49.943352806097,-97.140605985523 Gengar 98IV
                            coords = splitString[0].Split(',').Select(s => s.Trim()).ToList();
                            lat = Convert.ToDouble(coords[0]);
                            lng = Convert.ToDouble(coords[1]);
                            name = splitString[1].ToLower();
                            splitString[2] = splitString[2].ToUpper();
                            IV = Convert.ToInt16(splitString[2].Replace('%', ' ').Replace("IV", " "));
                            break;

                        case 4:
                            //35.6897618668263,139.73255932331085 Dratini 95% IV
                            coords = splitString[0].Split(',').Select(s => s.Trim()).ToList();
                            lat = Convert.ToDouble(coords[0]);
                            lng = Convert.ToDouble(coords[1]);
                            name = splitString[1];
                            splitString[2] = splitString[2].ToUpper();
                            if (splitString[2].Replace('%', ' ').Replace("IV", " ").All(Char.IsDigit))
                            {
                                IV = Convert.ToInt16(splitString[2].Replace('%', ' ').Replace("IV", " "));
                            }
                            else
                            {
                                IV = Convert.ToInt16(splitString[3].Replace('%', ' ').Replace("IV", " "));
                            }

                             break;
                        case 5:
                            //35.62657903204875, 139.88984942436218 Dragonite 100 IV
                            lat = Convert.ToDouble(splitString[0].Replace(',',' '));
                            lng = Convert.ToDouble(splitString[1]);
                            name = splitString[2];
                            splitString[2] = splitString[3].ToUpper();
                            IV = Convert.ToInt16(splitString[3].Replace('%', ' ').Replace("IV", " "));
                            break;
                        case 13:
                            //[668 seconds remaining] 72% IV - Vaporeon at 28.416483312498,-16.542801388924 [ Moveset: WaterGunFast/AquaTail ]
                            coords = splitString[8].Split(',').Select(s => s.Trim()).ToList();
                            lat = Convert.ToDouble(coords[0]);
                            lng = Convert.ToDouble(coords[1]);
                            name = splitString[6];
                            splitString[2] = splitString[3].ToUpper();
                            IV = Convert.ToInt16(splitString[3].Replace('%', ' ').Replace("IV", " "));
                            break;
 
                        default:
                            continue;
                    }

                    // Parse all lower names
                    if(char.IsLower(name[0]))
                    {
                        TextInfo ti = new CultureInfo("en-US", false).TextInfo;
                        name = ti.ToTitleCase(name);
                    }

                    if(_isStarted)
                    {
                        if(radioSnipeGetAll.Checked)
                        {
                            snipeList.Add((PokemonId)Enum.Parse(typeof(PokemonId), name), new PointLatLng(lat, lng));
                        }
                        else
                        {
                            if (_settings.PokemonToSnipe.Pokemon.Where(p => p == (PokemonId)Enum.Parse(typeof(PokemonId), name)).ToList().Count > 0 && IV >= _settings.KeepMinIvPercentage)
                            {
                                snipeList.Add((PokemonId)Enum.Parse(typeof(PokemonId), name), new PointLatLng(lat, lng));
                            }
                        }
                    }

                }
                catch {
                    UpdateMyPokemons();
                    _session.EventDispatcher.Send(new ErrorEvent
                    {
                        Message = "Bad sniping syntax: " + line
                    });
                    continue;
                }
            }

            if(snipeList.Count > 0 && _isStarted)
            {
                _session.EventDispatcher.Send(new WarnEvent
                {
                    Message = "Waiting on last task to finish before we start sniping"
                });
                _session.isAwaitingPaused = true;
                while (_session.isAwaitingPaused == true)
                {
                    await Task.Delay(1000);
                }
                _session.EventDispatcher.Send(new WarnEvent
                {
                    Message = "Starting to snipe list"
                });
                await ManualSnipePokemon.SnipePokemonTask.AsyncStart(_session, snipeList, default(CancellationToken));
                _session.EventDispatcher.Send(new WarnEvent
                {
                    Message = "Done sniping"
                });
                _session.isPaused = false;
            }

            _currentlySniping = false;

            textPokemonSnipeList.Text = "";
        }

        private async void cmdTransferSelected_Click(object sender, EventArgs e)
        {
            Dictionary<ulong, PokemonData> pokemonsToTransfer = new Dictionary<ulong, PokemonData>();

            foreach (DataGridViewRow row in dataMyPokemons.Rows)
            {
                if (row.Selected == true)
                {
                    pokemonsToTransfer.Add((ulong)row.Cells[0].Value, _guiPokemons._pokemons[(ulong)row.Cells[0].Value]);
                }
            }

            if(pokemonsToTransfer.Count > 0 && _isStarted)
            {
                _session.EventDispatcher.Send(new WarnEvent
                {
                    Message = "Waiting on last task to finish before we start transfering"
                });
                _session.isAwaitingPaused = true;
                while (_session.isAwaitingPaused == true)
                {
                    await Task.Delay(1000);
                }
                _session.EventDispatcher.Send(new WarnEvent
                {
                    Message = "Starting to transfer pokemons"
                });
                await ManualTransferPokemon.TransferPokemonTask.AsyncStart(_session, pokemonsToTransfer, default(CancellationToken));
                foreach(var pokemon in pokemonsToTransfer)
                {
                    _guiPokemons.RemovePokemon(pokemon.Key);
                }
                
                UpdateMyPokemons();
                _session.EventDispatcher.Send(new WarnEvent
                {
                    Message = "Done transfering"
                });
                _session.isPaused = false;
            }
        }

        private async void cmdEvolveSelected_Click(object sender, EventArgs e)
        {
            Dictionary<ulong, PokemonData> pokemonsToTransfer = new Dictionary<ulong, PokemonData>();

            foreach (DataGridViewRow row in dataMyPokemons.Rows)
            {
                if (row.Selected == true)
                {
                    pokemonsToTransfer.Add((ulong)row.Cells[0].Value, _guiPokemons._pokemons[(ulong)row.Cells[0].Value]);
                }
            }

            if (pokemonsToTransfer.Count > 0 && _isStarted)
            {
                _session.EventDispatcher.Send(new WarnEvent
                {
                    Message = "Waiting on last task to finish before we start evolving"
                });
                _session.isAwaitingPaused = true;
                while (_session.isAwaitingPaused == true)
                {
                    await Task.Delay(1000);
                }
                _session.EventDispatcher.Send(new WarnEvent
                {
                    Message = "Starting to evolve pokemons"
                });
                await ManualEvovlePokemon.EvolvePokemonTask.AsyncStart(_session, pokemonsToTransfer, default(CancellationToken));
                foreach (var pokemon in pokemonsToTransfer)
                {
                    _guiPokemons.RemovePokemon(pokemon.Key);
                }

                UpdateMyPokemons();
                _session.EventDispatcher.Send(new WarnEvent
                {
                    Message = "Done evolving"
                });
                _session.isPaused = false;
            }

 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _session.isAwaitingPaused = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _session.isPaused = false;
        }

        private void GUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            _profileSettings.LastLat = _session.Client.CurrentLatitude;
            _profileSettings.LastLng = _session.Client.CurrentLongitude;
            _profileSettings.Save();
        }
    }
}
