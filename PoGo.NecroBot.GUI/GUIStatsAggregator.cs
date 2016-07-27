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

        public void HandleEvent(ProfileEvent evt, Context ctx)
        {
            _guiStats.SetProfile(evt.Profile);
            _guiStats.SetStats(ctx.Inventory);
            _guiStats.Dirty(ctx.Inventory);
        }

        public void HandleEvent(ErrorEvent evt, Context ctx)
        {
        }

        public void HandleEvent(NoticeEvent evt, Context ctx)
        {
        }

        public void HandleEvent(WarnEvent evt, Context ctx)
        {
        }

        public void HandleEvent(UseLuckyEggEvent evt, Context ctx)
        {
        }

        public void HandleEvent(PokemonEvolveEvent evt, Context ctx)
        {
            _guiStats._sessionExperience += evt.Exp;
            _guiStats._playerExperience += evt.Exp;
            _guiStats.Dirty(ctx.Inventory);
        }

        public void HandleEvent(TransferPokemonEvent evt, Context ctx)
        {
            _guiStats.Dirty(ctx.Inventory);
        }

        public void HandleEvent(ItemRecycledEvent evt, Context ctx)
        {
            _guiStats.Dirty(ctx.Inventory);
        }

        public void HandleEvent(EggIncubatorStatusEvent evt, Context ctx)
        {

        }

        public void HandleEvent(FortUsedEvent evt, Context ctx)
        {
            _guiStats._sessionExperience += evt.Exp;
            _guiStats._playerExperience += evt.Exp;
            _guiStats.Dirty(ctx.Inventory);
        }

        public void HandleEvent(FortFailedEvent evt, Context ctx)
        {
 
        }

        public void HandleEvent(FortTargetEvent evt, Context ctx)
        {
        }

        public void HandleEvent(PokemonCaptureEvent evt, Context ctx)
        {
            if (evt.Status == CatchPokemonResponse.Types.CatchStatus.CatchSuccess)
            {
                _guiStats._sessionExperience += evt.Exp;
                _guiStats._playerExperience += evt.Exp;
                _guiStats._sessionPokemon += 1;
                _guiStats._playerStardust = evt.Stardust;
                _guiStats.Dirty(ctx.Inventory);
            }
        }

        public void HandleEvent(NoPokeballEvent evt, Context ctx)
        {
        }

        public void HandleEvent(UseBerryEvent evt, Context ctx)
        {
        }

        public void HandleEvent(DisplayHighestsPokemonEvent evt, Context ctx)
        {
 
        }

        public void HandleEvent(UpdateEvent evt, Context ctx)
        {
            
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
