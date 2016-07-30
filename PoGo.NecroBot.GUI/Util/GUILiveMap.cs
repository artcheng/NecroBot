using GMap.NET;
using PoGo.NecroBot.Logic;
using PoGo.NecroBot.Logic.State;
using PoGo.NecroBot.Logic.Utils;
using POGOProtos.Map.Fort;
using POGOProtos.Map.Pokemon;
using PokemonGo.RocketAPI;
using PokemonGo.RocketAPI.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoGo.NecroBot.GUI.Util
{ 
    public delegate void GUILiveMapDirtyDelegate();

    class GUILiveMap
    {
        public PointLatLng _currentPosition = new PointLatLng();
        public PointLatLng _lastPosition = new PointLatLng();
        public bool _positionUpdated = false;

        public Dictionary<string, FortData> _pokeStops = new Dictionary<string, FortData>();
        public Dictionary<string, FortData> _pokeGyms = new Dictionary<string, FortData>();

        public Dictionary<ulong, MapPokemon> _mapPokemons = new Dictionary<ulong, MapPokemon>();

        public void Dirty(Session session)
        {
            DirtyEvent?.Invoke();
        }

        public async void UpdatePokeStopsGyms(Session session)
        {
            var mapObjects = await session.Client.Map.GetMapObjects();

            var pokeStopsGyms = mapObjects.MapCells.SelectMany(i => i.Forts)
                .Where(
                    i =>
                        (i.Type == FortType.Checkpoint || i.Type == FortType.Gym) 
                ).ToList();

            if (pokeStopsGyms != null)
            {
                foreach (var stopToRemove in _pokeStops.ToList())
                {
                    if (pokeStopsGyms.Where(p => p.Id == stopToRemove.Key && p.Type == FortType.Checkpoint).ToList().Count == 0)
                    {
                        _pokeStops.Remove(stopToRemove.Key);
                    }
                }

                foreach (var gymToRemove in _pokeStops.ToList())
                {
                    if (pokeStopsGyms.Where(p => p.Id == gymToRemove.Key && p.Type == FortType.Gym).ToList().Count == 0)
                    {
                        _pokeGyms.Remove(gymToRemove.Key);
                    }
                }

                foreach (var stop in pokeStopsGyms.ToList())
                {
                    if(stop.Type == FortType.Checkpoint)
                    {
                        if (_pokeStops.ContainsKey(stop.Id) == false)
                            _pokeStops.Add(stop.Id, stop);
                    }
                    else
                    {
                        if (_pokeGyms.ContainsKey(stop.Id) == false)
                            _pokeGyms.Add(stop.Id, stop);
                    }
                }
            }
        }

        public async void UpdateMapPokemons(Session session)
        {
            var mapObjects = await session.Client.Map.GetMapObjects();

            var catchablePokemonsObj = mapObjects.MapCells.Select(i => i.CatchablePokemons);
            Dictionary<ulong, MapPokemon> mapPokemonList = new Dictionary<ulong, MapPokemon>();
            if (catchablePokemonsObj != null)
            {
                // Make a list with catchable pokemons
                foreach (var pokemonList in catchablePokemonsObj.ToList())
                {
                    if (pokemonList.Count > 0)
                        foreach (var pokemon in pokemonList.ToList())
                        {
                            mapPokemonList.Add(pokemon.EncounterId, pokemon);
                        }
                }

                // Delete
                foreach (var pokemonToRemove in _mapPokemons.ToList())
                {
                    if (mapPokemonList.Where(p => p.Key == pokemonToRemove.Key).ToList().Count == 0)
                    {
                        _mapPokemons.Remove(pokemonToRemove.Key);
                    }
                }

                // Add
                foreach (var pokemon in mapPokemonList.ToList())
                {
                  if (_mapPokemons.ContainsKey(pokemon.Key) == false)
                        _mapPokemons.Add(pokemon.Key, pokemon.Value);
                }
            }
           
        }

        public void SetPosition(PointLatLng position, Session session)
        {
            if (position != _currentPosition)
            {
                //UpdateMapPokemons(session);
                _positionUpdated = true;
                _lastPosition = _currentPosition;
                _currentPosition = position;
            }
        }

        public event GUILiveMapDirtyDelegate DirtyEvent;
    }
}
