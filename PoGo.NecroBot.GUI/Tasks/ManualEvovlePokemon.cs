using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PoGo.NecroBot.Logic.Event;
using PoGo.NecroBot.Logic.State;
using PoGo.NecroBot.Logic.Utils;
using POGOProtos.Enums;
using POGOProtos.Networking.Responses;
using System.Net.Sockets;
using System.Threading;
using PoGo.NecroBot.Logic.Tasks;
using PoGo.NecroBot.Logic;
using PoGo.NecroBot.Logic.PoGoUtils;
using POGOProtos.Data;

namespace PoGo.NecroBot.GUI.Tasks
{
    class ManualEvovlePokemon
    {
        public static class EvolvePokemonTask
        {
            public static Task AsyncStart(ISession session, Dictionary<ulong, PokemonData> pokemonList, CancellationToken cancellationToken)
            {
                return Task.Run(() => transfer(session, pokemonList, cancellationToken));
            }

            private static async Task transfer(ISession session, Dictionary<ulong, PokemonData> pokemonList, CancellationToken cancellationToken)
            {
                List<ulong> evolvedList = new List<ulong>();

                foreach (var pokemonToTransfer in pokemonList)
                {
                    var evolveResponse = await session.Client.Inventory.EvolvePokemon(pokemonToTransfer.Key);

                    session.EventDispatcher.Send(new PokemonEvolveEvent
                    {
                        Id = pokemonToTransfer.Value.PokemonId,
                        Exp = evolveResponse.ExperienceAwarded,
                        Result = evolveResponse.Result
                    });

                    await Task.Delay(1500, cancellationToken);

                    if (evolveResponse.Result == POGOProtos.Networking.Responses.EvolvePokemonResponse.Types.Result.Success)
                    {
                        evolvedList.Add(pokemonToTransfer.Key);
                    }
                }
                
            }

        }
    }
}
