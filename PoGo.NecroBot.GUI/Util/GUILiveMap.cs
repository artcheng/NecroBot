using GMap.NET;
using PoGo.NecroBot.Logic;
using PoGo.NecroBot.Logic.State;
using PoGo.NecroBot.Logic.Utils;
using POGOProtos.Map.Fort;
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

            //&&
            //            i.CooldownCompleteTimestampMs < DateTime.UtcNow.ToUnixTime() &&
            //            ( // Make sure PokeStop is within 40 meters or else it is pointless to hit it
            //                LocationUtils.CalculateDistanceInMeters(
            //                    session.Client.CurrentLatitude, session.Client.CurrentLongitude,
            //                    i.Latitude, i.Longitude) < 40) ||
            //            session.LogicSettings.MaxTravelDistanceInMeters == 0

            if (pokeStopsGyms != null)
            {
                foreach (var stopToRemove in _pokeStops)
                {
                    if (pokeStopsGyms.Where(p => p.Id == stopToRemove.Key && p.Type == FortType.Checkpoint).ToList().Count == 0)
                    {
                        _pokeStops.Remove(stopToRemove.Key);
                    }
                }

                foreach (var gymToRemove in _pokeStops)
                {
                    if (pokeStopsGyms.Where(p => p.Id == gymToRemove.Key && p.Type == FortType.Gym).ToList().Count == 0)
                    {
                        _pokeGyms.Remove(gymToRemove.Key);
                    }
                }

                foreach (var stop in pokeStopsGyms)
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

        public void SetPosition(PointLatLng position)
        {
            if(position != _currentPosition)
            {
                _positionUpdated = true;
                _lastPosition = _currentPosition;
                _currentPosition = position;
            }
        }

        public event GUILiveMapDirtyDelegate DirtyEvent;
    }
}
