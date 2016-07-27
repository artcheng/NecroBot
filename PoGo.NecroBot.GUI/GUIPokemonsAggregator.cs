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

namespace PoGo.NecroBot.GUI
{
    class GUIPokemonsAggregator
    {
        private readonly GUIPokemons _guiPokemons;

        public GUIPokemonsAggregator(GUIPokemons pokemons)
        {
            _guiPokemons = pokemons;
        }

        public void HandleEvent(ProfileEvent evt, Context ctx)
        {
            _guiPokemons.SetPokemons(ctx.Inventory);
            _guiPokemons.Dirty(ctx.Inventory);
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
            //_guiPokemons.RemovePokemon(evt.UniqueIdBefore);
            //_guiPokemons.AddPokemon(evt.FullData);
            _guiPokemons.Dirty(ctx.Inventory);
        }

        public void HandleEvent(TransferPokemonEvent evt, Context ctx)
        {
            //_guiPokemons.RemovePokemon(evt.UniqueId);
            _guiPokemons.Dirty(ctx.Inventory);
        }

        public void HandleEvent(ItemRecycledEvent evt, Context ctx)
        {
 
        }

        public void HandleEvent(EggIncubatorStatusEvent evt, Context ctx)
        {

        }

        public void HandleEvent(FortUsedEvent evt, Context ctx)
        {

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
                //_guiPokemons.AddPokemon(evt.FullData);
                _guiPokemons.Dirty(ctx.Inventory);
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
