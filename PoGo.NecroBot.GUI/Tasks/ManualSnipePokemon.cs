using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PoGo.NecroBot.Logic.Event;
using PoGo.NecroBot.Logic.State;
using PoGo.NecroBot.Logic.Utils;
using POGOProtos.Enums;
using POGOProtos.Networking.Responses;
using System.Net.Sockets;
using System.Threading;
using PoGo.NecroBot.Logic.Tasks;
using PoGo.NecroBot.Logic;
using GMap.NET;

namespace PoGo.NecroBot.GUI.Tasks
{
    class ManualSnipePokemon
    {
        public static class SnipePokemonTask
        {
            public static Task AsyncStart(ISession session, Dictionary<PokemonId, PointLatLng> pokemonIdList, CancellationToken cancellationToken)
            {
                return Task.Run(() => snipe(session, pokemonIdList, cancellationToken));
            }

            private static async Task snipe(ISession session, Dictionary<PokemonId, PointLatLng> pokemonIdList, CancellationToken cancellationToken)
            {
                var currentLatitude = session.Client.CurrentLatitude;
                var currentLongitude = session.Client.CurrentLongitude;

                int snipingCount = 0;

                foreach(var pokemonToSnipe in pokemonIdList)
                {
                    session.EventDispatcher.Send(new SnipeScanEvent() { Bounds = new Location(pokemonToSnipe.Value.Lat, pokemonToSnipe.Value.Lng) });

                    await
                        session.Client.Player.UpdatePlayerLocation(pokemonToSnipe.Value.Lat,
                            pokemonToSnipe.Value.Lng, session.Client.CurrentAltitude);

                    session.EventDispatcher.Send(new UpdatePositionEvent()
                    {
                        Longitude = pokemonToSnipe.Value.Lat,
                        Latitude = pokemonToSnipe.Value.Lng
                    });

                    var mapObjects = session.Client.Map.GetMapObjects().Result;
                    var catchablePokemon =
                        mapObjects.MapCells.SelectMany(q => q.CatchablePokemons)
                            .Where(q => pokemonToSnipe.Key == q.PokemonId)
                            .ToList();

                    await session.Client.Player.UpdatePlayerLocation(currentLatitude, currentLongitude,
                                session.Client.CurrentAltitude);

                    snipingCount++;
                    session.EventDispatcher.Send(new WarnEvent
                    {
                        Message = "Sniping pokemon: " + snipingCount.ToString() + "/" + pokemonIdList.Count.ToString() + "(" + pokemonToSnipe.Key.ToString() + ")"
                    });

                    foreach (var pokemon in catchablePokemon)
                    {
                        cancellationToken.ThrowIfCancellationRequested();

                        await session.Client.Player.UpdatePlayerLocation(pokemonToSnipe.Value.Lat, pokemonToSnipe.Value.Lng, session.Client.CurrentAltitude);

                        var encounter = session.Client.Encounter.EncounterPokemon(pokemon.EncounterId, pokemon.SpawnPointId).Result;

                        await session.Client.Player.UpdatePlayerLocation(currentLatitude, currentLongitude, session.Client.CurrentAltitude);

                        if (encounter.Status == EncounterResponse.Types.Status.EncounterSuccess)
                        {
                            session.EventDispatcher.Send(new UpdatePositionEvent()
                            {
                                Latitude = currentLatitude,
                                Longitude = currentLongitude
                            });

                            await CatchPokemonTask.Execute(session, encounter, pokemon);
                        }
                        else if (encounter.Status == EncounterResponse.Types.Status.PokemonInventoryFull)
                        {
                            session.EventDispatcher.Send(new WarnEvent
                            {
                                Message =
                                    session.Translation.GetTranslation(
                                        Logic.Common.TranslationString.InvFullTransferManually)
                            });
                        }
                        else
                        {
                            session.EventDispatcher.Send(new WarnEvent
                            {
                                Message =
                                    session.Translation.GetTranslation(
                                        Logic.Common.TranslationString.EncounterProblem, encounter.Status)
                            });
                        }

                        if (
                            !Equals(catchablePokemon.ElementAtOrDefault(catchablePokemon.Count() - 1),
                                pokemon))
                        {
                            await Task.Delay(session.LogicSettings.DelayBetweenPokemonCatch, cancellationToken);
                        }
                    }

                    await Task.Delay(5000, cancellationToken);
                }
            }

            private static ScanResult SnipeScanForPokemon(Location location)
            {
                var formatter = new System.Globalization.NumberFormatInfo() { NumberDecimalSeparator = "." };
                var uri = $"https://pokevision.com/map/data/{location.Latitude.ToString(formatter)}/{location.Longitude.ToString(formatter)}";

                ScanResult scanResult;
                try
                {
                    var request = WebRequest.CreateHttp(uri);
                    request.Accept = "application/json";
                    request.Method = "GET";
                    request.Timeout = 1000;

                    var resp = request.GetResponse();
                    var reader = new StreamReader(resp.GetResponseStream());

                    scanResult = JsonConvert.DeserializeObject<ScanResult>(reader.ReadToEnd());
                }
                catch (Exception)
                {
                    scanResult = new ScanResult()
                    {
                        status = "fail",
                        pokemon = new List<PokemonLocation>()
                    };
                }
                return scanResult;
            }
        }
    }
}
