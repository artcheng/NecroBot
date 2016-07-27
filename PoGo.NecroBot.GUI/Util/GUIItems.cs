using System;
using System.Globalization;
using System.Linq;
using POGOProtos.Networking.Responses;
using System.Collections.Generic;
using POGOProtos.Data.Player;
using PoGo.NecroBot.Logic;
using POGOProtos.Enums;
using Google.Protobuf.Collections;
using POGOProtos.Inventory.Item;
using POGOProtos.Inventory;
using PoGo.NecroBot.Logic.State;
using POGOProtos.Settings.Master;

namespace GUI.Utils
{
    public delegate void GUIItemsDirtyDelegate();

    class GUIItems
    {
        public Dictionary<ItemId, int> _items = new Dictionary<ItemId, int>();
        public Dictionary<PokemonFamilyId, int> _candies = new Dictionary<PokemonFamilyId, int>();
        public IEnumerable<PokemonSettings> _pokemonSettings;

        public void SetItems(Inventory inventory)
        {
            var items = inventory.GetItems().Result;
            if(items != null)
            {
                foreach (var item in items)
                {
                    if (_items.ContainsKey(item.ItemId))
                        _items[item.ItemId] = item.Count;
                    else
                        _items.Add(item.ItemId, item.Count);
                }
            }

            var candies = inventory.GetPokemonFamilies().Result;
            if(candies != null)
            {
                foreach (var candy in candies)
                {
                    if (_candies.ContainsKey(candy.FamilyId))
                        _candies[candy.FamilyId] = candy.Candy;
                    else
                        _candies.Add(candy.FamilyId, candy.Candy);
                }
            }
        }

        public void UpdateItemByValue(ItemId itemId, int value)
        {
            if (_items.ContainsKey(itemId))
                _items[itemId] += value;
            else
                _items.Add(itemId, 1);

        }

        public void UpdateItemByCount(ItemId itemId, int count)
        {
            if (_items.ContainsKey(itemId))
                _items[itemId] = count;
            else
                _items.Add(itemId, count);
        }

        public async void UpdateCandyByValue(PokemonId pokemonid, int value, Context ctx)
        {
            if(_pokemonSettings == null)
                _pokemonSettings = await ctx.Inventory.GetPokemonSettings();

            var setting = _pokemonSettings.Single(q => q.PokemonId == pokemonid);

            if (_candies.ContainsKey(setting.FamilyId))
                _candies[setting.FamilyId] = value;
            else
                _candies.Add(setting.FamilyId, value);
        }

        public void UpdateItemByItemsString(string items)
        {
            string[] itemsList = Array.ConvertAll(items.Split(','), i => i.Trim());
            foreach(var item in itemsList)
            {
                ItemId itemId = (ItemId)Enum.Parse(typeof(ItemId), ((item.Substring(item.LastIndexOf(' ')))));
                int count = Convert.ToInt16(item.Substring(0, item.IndexOf(' ')));
                if (_items.ContainsKey(itemId))
                    _items[itemId] += count;
                else
                    _items.Add(itemId, count);
            }

        }

        public void Dirty(Inventory inventory)
        {
            DirtyEvent?.Invoke();
        }

        public event GUIItemsDirtyDelegate DirtyEvent;
    }
}
