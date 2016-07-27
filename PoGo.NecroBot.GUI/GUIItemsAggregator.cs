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
    class GUIItemsAggregator
    {
        private readonly GUIItems _guiItems;

        public GUIItemsAggregator(GUIItems items)
        {
            _guiItems = items;
        }

        public void HandleEvent(ProfileEvent evt, Context ctx)
        {
            _guiItems.SetItems(ctx.Inventory);
            _guiItems.Dirty(ctx.Inventory);
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
            _guiItems.UpdateItemByValue(ItemId.ItemLuckyEgg, -1);
            _guiItems.Dirty(ctx.Inventory);
        }

        public void HandleEvent(PokemonEvolveEvent evt, Context ctx)
        {
            _guiItems.Dirty(ctx.Inventory);
        }

        public void HandleEvent(TransferPokemonEvent evt, Context ctx)
        {
            _guiItems.UpdateCandyByValue(evt.Id, evt.FamilyCandies, ctx);
            _guiItems.Dirty(ctx.Inventory);
        }

        public void HandleEvent(ItemRecycledEvent evt, Context ctx)
        {
            _guiItems.UpdateItemByValue(evt.Id, evt.Count*-1);
            _guiItems.Dirty(ctx.Inventory);
        }

        public void HandleEvent(EggIncubatorStatusEvent evt, Context ctx)
        {
  
        }

        public void HandleEvent(FortUsedEvent evt, Context ctx)
        {
            _guiItems.UpdateItemByItemsString(evt.Items);
            _guiItems.Dirty(ctx.Inventory);
        }

        public void HandleEvent(FortFailedEvent evt, Context ctx)
        {

        }

        public void HandleEvent(FortTargetEvent evt, Context ctx)
        {

        }

        public void HandleEvent(PokemonCaptureEvent evt, Context ctx)
        {
            _guiItems.UpdateItemByValue(evt.Pokeball, -1);
            _guiItems.UpdateCandyByValue(evt.Id, evt.FamilyCandies, ctx);
            _guiItems.Dirty(ctx.Inventory);
        }

        public void HandleEvent(NoPokeballEvent evt, Context ctx)
        {
        }

        public void HandleEvent(UseBerryEvent evt, Context ctx)
        {
            _guiItems.UpdateItemByValue(ItemId.ItemRazzBerry, -1);
            _guiItems.Dirty(ctx.Inventory);
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
