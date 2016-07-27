﻿using System;
using PoGo.NecroBot.Logic.Event;
using PoGo.NecroBot.Logic.Logging;
using PoGo.NecroBot.Logic.State;
using POGOProtos.Inventory.Item;
using POGOProtos.Networking.Responses;
using PoGo.NecroBot.Logic.Common;

namespace PoGo.NecroBot.GUI
{
    class GUIEventListener
    {
        public void HandleEvent(ProfileEvent evt, Context ctx)
        {
            Logger.Write($"Playing as {evt.Profile.PlayerData.Username ?? ""}");
        }

        public void HandleEvent(ErrorEvent evt, Context ctx)
        {
            Logger.Write(evt.ToString(), LogLevel.Error);
        }

        public void HandleEvent(NoticeEvent evt, Context ctx)
        {
            Logger.Write(evt.ToString());
        }

        public void HandleEvent(WarnEvent evt, Context ctx)
        {
            Logger.Write(evt.ToString(), LogLevel.Warning);
        }

        public void HandleEvent(UseLuckyEggEvent evt, Context ctx)
        {
            Logger.Write($"Used Lucky Egg, remaining: {evt.Count}", LogLevel.Egg);
        }

        public void HandleEvent(PokemonEvolveEvent evt, Context ctx)
        {
            Logger.Write(evt.Result == EvolvePokemonResponse.Types.Result.Success
                ? $"{evt.Id} successfully for {evt.Exp}xp"
                : $"Failed {evt.Id}. EvolvePokemonOutProto.Result was {evt.Result}, stopping evolving {evt.Id}",
                LogLevel.Evolve);
        }

        public void HandleEvent(TransferPokemonEvent evt, Context ctx)
        {
            Logger.Write(
                $"{evt.Id}\t- CP: {evt.Cp}  IV: {evt.Perfection.ToString("0.00")}%   [Best CP: {evt.BestCp}  IV: {evt.BestPerfection.ToString("0.00")}%] (Candies: {evt.FamilyCandies}) ",
                LogLevel.Transfer);
        }

        public void HandleEvent(ItemRecycledEvent evt, Context ctx)
        {
            Logger.Write($"{evt.Count}x {evt.Id}", LogLevel.Recycling);
        }

        public void HandleEvent(EggIncubatorStatusEvent evt, Context ctx)
        {
            Logger.Write(evt.WasAddedNow
                ? ctx.Translations.GetTranslation(TranslationString.IncubatorPuttingEgg, evt.KmRemaining)
                : ctx.Translations.GetTranslation(TranslationString.IncubatorStatusUpdate, evt.KmRemaining));
        }

        public void HandleEvent(FortUsedEvent evt, Context ctx)
        {
            Logger.Write($"XP: {evt.Exp}, Gems: {evt.Gems}, Items: {evt.Items}", LogLevel.Pokestop);
        }

        public void HandleEvent(FortFailedEvent evt, Context ctx)
        {
            Logger.Write(ctx.Translations.GetTranslation(TranslationString.EventFortFailed, evt.Retry, evt.Max),
                LogLevel.Pokestop, ConsoleColor.DarkRed);
        }

        public void HandleEvent(FortTargetEvent evt, Context ctx)
        {
            Logger.Write($"{evt.Name} in ({Math.Round(evt.Distance)}m)", LogLevel.Info, ConsoleColor.DarkRed);
        }

        public void HandleEvent(PokemonCaptureEvent evt, Context ctx)
        {
            Func<ItemId, string> returnRealBallName = a =>
            {
                switch (a)
                {
                    case ItemId.ItemPokeBall:
                        return "Poke";
                    case ItemId.ItemGreatBall:
                        return "Great";
                    case ItemId.ItemUltraBall:
                        return "Ultra";
                    case ItemId.ItemMasterBall:
                        return "Master";
                    default:
                        return "Unknown";
                }
            };

            var catchStatus = evt.Attempt > 1
                ? $"{evt.Status} Attempt #{evt.Attempt}"
                : $"{evt.Status}";

            var familyCandies = evt.FamilyCandies > 0
                ? $"Candies: {evt.FamilyCandies}"
                : "";

            Logger.Write(
                $"({catchStatus}) {evt.Id} Lvl: {evt.Level} CP: ({evt.Cp}/{evt.MaxCp}) IV: {evt.Perfection.ToString("0.00")}% | Chance: {evt.Probability}% | {Math.Round(evt.Distance)}m dist | with a {returnRealBallName(evt.Pokeball)}Ball. | {familyCandies}",
                LogLevel.Caught);
        }

        public void HandleEvent(NoPokeballEvent evt, Context ctx)
        {
            Logger.Write($"No Pokeballs - We missed a {evt.Id} with CP {evt.Cp}", LogLevel.Caught);
        }

        public void HandleEvent(UseBerryEvent evt, Context ctx)
        {
            Logger.Write($"Used, remaining: {evt.Count}", LogLevel.Berry);
        }

        public void HandleEvent(DisplayHighestsPokemonEvent evt, Context ctx)
        {
            string strHeader;
            //PokemonData | CP | IV | Level
            switch (evt.SortedBy)
            {
                case "Level":
                    strHeader = ctx.Translations.GetTranslation(TranslationString.DisplayHighestsLevelHeader);
                    break;
                case "IV":
                    strHeader = ctx.Translations.GetTranslation(TranslationString.DisplayHighestsPerfectHeader);
                    break;
                case "CP":
                    strHeader = ctx.Translations.GetTranslation(TranslationString.DisplayHighestsCpHeader);
                    break;
                default:
                    strHeader = ctx.Translations.GetTranslation(TranslationString.DisplayHighestsHeader);
                    break;
            }
            var strPerfect = ctx.Translations.GetTranslation(TranslationString.CommonWordPerfect);
            var strName = ctx.Translations.GetTranslation(TranslationString.CommonWordName).ToUpper();

            Logger.Write($"====== {strHeader} ======", LogLevel.Info, ConsoleColor.Yellow);
            foreach (var pokemon in evt.PokemonList)
                Logger.Write(
                    $"# CP {pokemon.Item1.Cp.ToString().PadLeft(4, ' ')}/{pokemon.Item2.ToString().PadLeft(4, ' ')} | ({pokemon.Item3.ToString("0.00")}% {strPerfect})\t| Lvl {pokemon.Item4.ToString("00")}\t {strName}: '{pokemon.Item1.PokemonId}'",
                    LogLevel.Info, ConsoleColor.Yellow);
        }

        public void HandleEvent(UpdateEvent evt, Context ctx)
        {
            Logger.Write(evt.ToString(), LogLevel.Update);
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
