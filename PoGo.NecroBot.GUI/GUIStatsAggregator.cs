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

namespace PoGo.NecroBot.GUI
{
    class GUIStatsAggregator
    {
        private readonly GUIStats _guiStats;

        public GUIStatsAggregator(GUIStats stats)
        {
            _guiStats = stats;
        }

        public void HandleEvent(ProfileEvent evt, Session session)
        {
            _guiStats.SetProfile(evt.Profile);
            _guiStats.SetStats(session.Inventory);
            _guiStats.Dirty(session.Inventory);
        }

        public void HandleEvent(ErrorEvent evt, Session session)
        {
        }

        public void HandleEvent(NoticeEvent evt, Session session)
        {
        }

        public void HandleEvent(WarnEvent evt, Session session)
        {
        }

        public void HandleEvent(UseLuckyEggEvent evt, Session session)
        {
        }

        public void HandleEvent(PokemonEvolveEvent evt, Session session)
        {
            _guiStats._sessionExperience += evt.Exp;
            _guiStats._playerExperience += evt.Exp;
            _guiStats.Dirty(session.Inventory);
        }

        public void HandleEvent(TransferPokemonEvent evt, Session session)
        {
            _guiStats.Dirty(session.Inventory);
        }

        public void HandleEvent(ItemRecycledEvent evt, Session session)
        {
            _guiStats.Dirty(session.Inventory);
        }

        public void HandleEvent(EggIncubatorStatusEvent evt, Session session)
        {

        }

        public void HandleEvent(FortUsedEvent evt, Session session)
        {
            _guiStats._sessionExperience += evt.Exp;
            _guiStats._playerExperience += evt.Exp;
            _guiStats.Dirty(session.Inventory);
        }

        public void HandleEvent(FortFailedEvent evt, Session session)
        {
 
        }

        public void HandleEvent(FortTargetEvent evt, Session session)
        {
        }

        public void HandleEvent(PokemonCaptureEvent evt, Session session)
        {
            if (evt.Status == CatchPokemonResponse.Types.CatchStatus.CatchSuccess)
            {
                _guiStats._sessionExperience += evt.Exp;
                _guiStats._playerExperience += evt.Exp;
                _guiStats._sessionPokemon += 1;
                _guiStats._playerStardust = evt.Stardust;
                _guiStats.Dirty(session.Inventory);
            }
        }

        public void HandleEvent(NoPokeballEvent evt, Session session)
        {
        }

        public void HandleEvent(UseBerryEvent evt, Session session)
        {
        }

        public void HandleEvent(DisplayHighestsPokemonEvent evt, Session session)
        {
 
        }

        public void HandleEvent(UpdateEvent evt, Session session)
        {
            
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
