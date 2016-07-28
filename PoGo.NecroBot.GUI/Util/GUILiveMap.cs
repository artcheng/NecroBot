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

        public void Dirty(Context ctx)
        {
            DirtyEvent?.Invoke();
        }

        public async void UpdateMapObjects(Context ctx)
        {
            //var mapObjects = await ctx.Client.Map.GetMapObjects();

            //// Wasn't sure how to make this pretty. Edit as needed.
            //var pokeStops = mapObjects.MapCells.SelectMany(i => i.Forts)
            //    .Where(
            //        i =>
            //            i.Type == FortType.Checkpoint &&
            //            i.CooldownCompleteTimestampMs < DateTime.UtcNow.ToUnixTime() &&
            //            ( // Make sure PokeStop is within 40 meters or else it is pointless to hit it
            //                LocationUtils.CalculateDistanceInMeters(
            //                    ctx.Client.CurrentLatitude, ctx.Client.CurrentLongitude,
            //                    i.Latitude, i.Longitude) < 40) ||
            //            ctx.LogicSettings.MaxTravelDistanceInMeters == 0
            //    ).ToList();

            


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
