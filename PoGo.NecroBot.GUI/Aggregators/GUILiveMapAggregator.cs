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

namespace PoGo.NecroBot.GUI.Aggregators
{
    class GUILiveMapAggregator
    {
        private readonly GUILiveMap _guiLiveMap;

        public GUILiveMapAggregator(GUILiveMap livemap)
        {
            _guiLiveMap = livemap;
        }

        public void HandleEvent(ProfileEvent evt, Session session)
        {
 
        }

        public void HandleEvent(PokeStopListEvent evt, Session session)
        {
            _guiLiveMap.UpdatePokeStopsGyms(session);
            _guiLiveMap.Dirty(session);
        }

        public void HandleEvent(UpdatePositionEvent evt, Session session)
        {
            _guiLiveMap.SetPosition(new PointLatLng(evt.Latitude, evt.Longitude));
            _guiLiveMap.Dirty(session);
        }

        public void Listen(IEvent evt, Session session)
        {
            dynamic eve = evt;

            try
            {
                HandleEvent(eve, session);
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
            }
        }
    }
}
