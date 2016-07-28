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

        public void HandleEvent(ProfileEvent evt, Session session)
        {
            _guiItems.SetItems(session.Inventory);
            _guiItems.Dirty(session.Inventory);
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
            _guiItems.UpdateItemByValue(ItemId.ItemLuckyEgg, -1);
            _guiItems.Dirty(session.Inventory);
        }

        public void HandleEvent(PokemonEvolveEvent evt, Session session)
        {
            _guiItems.Dirty(session.Inventory);
        }

        public void HandleEvent(TransferPokemonEvent evt, Session session)
        {
            _guiItems.UpdateCandyByValue(evt.Id, evt.FamilyCandies, session);
            _guiItems.Dirty(session.Inventory);
        }

        public void HandleEvent(ItemRecycledEvent evt, Session session)
        {
            _guiItems.UpdateItemByValue(evt.Id, evt.Count*-1);
            _guiItems.Dirty(session.Inventory);
        }

        public void HandleEvent(EggIncubatorStatusEvent evt, Session session)
        {
  
        }

        public void HandleEvent(FortUsedEvent evt, Session session)
        {
            _guiItems.UpdateItemByItemsString(evt.Items);
            _guiItems.Dirty(session.Inventory);
        }

        public void HandleEvent(FortFailedEvent evt, Session session)
        {

        }

        public void HandleEvent(FortTargetEvent evt, Session session)
        {

        }

        public void HandleEvent(PokemonCaptureEvent evt, Session session)
        {
            _guiItems.UpdateItemByValue(evt.Pokeball, -1);
            _guiItems.UpdateCandyByValue(evt.Id, evt.FamilyCandies, session);
            _guiItems.Dirty(session.Inventory);
        }

        public void HandleEvent(NoPokeballEvent evt, Session session)
        {
        }

        public void HandleEvent(UseBerryEvent evt, Session session)
        {
            _guiItems.UpdateItemByValue(ItemId.ItemRazzBerry, -1);
            _guiItems.Dirty(session.Inventory);
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
