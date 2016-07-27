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
using POGOProtos.Data;

namespace GUI.Utils
{
    public delegate void GUIPokemonsDirtyDelegate();

    class GUIPokemons
    {
        public Dictionary<ulong, PokemonData> _pokemons = new Dictionary<ulong, PokemonData>();

        public void SetPokemons(Inventory inventory)
        {
            if(inventory != null)
            {
                var pokemons = inventory.GetPokemons().Result;
                if (pokemons != null)
                {
                    foreach (var pokemonToRemove in _pokemons)
                    {
                        if (pokemons.Where(p => p.Id == pokemonToRemove.Key).ToList().Count == 0)
                        {
                            _pokemons.Remove(pokemonToRemove.Key);
                        }
                    }

                    foreach (var pokemon in pokemons)
                    {
                        if (_pokemons.ContainsKey(pokemon.Id))
                            _pokemons[pokemon.Id] = pokemon;
                        else
                            _pokemons.Add(pokemon.Id, pokemon);
                    }
                }

            }
        }

        public void AddPokemon(PokemonData pokemon)
        {
            if (_pokemons.TryGetValue(pokemon.Id,out pokemon) == false)
                _pokemons.Add(pokemon.Id, pokemon);
        }

        public void RemovePokemon(ulong uniqueId)
        {
            _pokemons.Remove(uniqueId);
        }

        public void Dirty(Inventory inventory)
        {
            DirtyEvent?.Invoke();
        }

        public event GUIPokemonsDirtyDelegate DirtyEvent;
    }
}
