using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoGo.NecroBot.Logic.Event;
using PoGo.NecroBot.Logic.Logging;
using PoGo.NecroBot.Logic.State;
using POGOProtos.Inventory.Item;
using POGOProtos.Networking.Responses;
using GUI.Utils;
using POGOProtos.Enums;
using PoGo.NecroBot.GUI.Util;
using GMap.NET;

namespace PoGo.NecroBot.GUI
{
    class GUILiveMapAggregator
    {
        private readonly GUILiveMap _guiLiveMap;

        public GUILiveMapAggregator(GUILiveMap livemap)
        {
            _guiLiveMap = livemap;
        }

        public void HandleEvent(ProfileEvent evt, Context ctx)
        {
 
        }

        public void HandleEvent(PokeStopListEvent evt, Context ctx)
        {

        }

        public void HandleEvent(UpdatePositionEvent evt, Context ctx)
        {
            _guiLiveMap.SetPosition(new PointLatLng(evt.Latitude, evt.Longitude));
            _guiLiveMap.UpdateMapObjects(ctx);
            _guiLiveMap.Dirty(ctx);
        }

        public void Listen(IEvent evt, Context ctx)
        {
            dynamic eve = evt;

            try
            {
                HandleEvent(eve, ctx);
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
            }
        }
    }
}
