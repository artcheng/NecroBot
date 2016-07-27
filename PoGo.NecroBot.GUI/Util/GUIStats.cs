using System;
using System.Globalization;
using System.Linq;
using POGOProtos.Networking.Responses;
using System.Collections.Generic;
using POGOProtos.Data.Player;
using PoGo.NecroBot.Logic;
using POGOProtos.Enums;
using Google.Protobuf.Collections;

namespace GUI.Utils
{
    public delegate void GUIStatsDirtyDelegate();

    class GUIStats
    {
        private readonly DateTime _initSessionDateTime = DateTime.Now;
        public int _sessionExperience = 0;
        public int _sessionPokemon = 0;

        public string _playerName;
        public TeamColor _playerTeam;
        public int _playerLevel;
        public int _playerMaxBagSpace;
        public int _playerMaxPokemonSpace;
        public int _playerStardust;
        public int _playerPokecoins;

        public long _playerPrevLevelXp;
        public long _playerNextLevelXp;
        public long _playerExperience;

        public void SetProfile(GetPlayerResponse profile) {
            _playerName = profile.PlayerData.Username;
            _playerTeam = profile.PlayerData.Team;
            _playerMaxBagSpace = profile.PlayerData.MaxItemStorage;
            _playerMaxPokemonSpace = profile.PlayerData.MaxPokemonStorage;
            _playerStardust = profile.PlayerData.Currencies[1].Amount;
            _playerPokecoins = profile.PlayerData.Currencies[0].Amount;
        }

        public void SetStats(Inventory inventory)
        {
            var stats = inventory.GetPlayerStats().Result;
            var stat = stats.FirstOrDefault();
            if (stat != null)
            {
                _playerPrevLevelXp = stat.PrevLevelXp;
                _playerNextLevelXp = stat.NextLevelXp;
                _playerExperience = stat.Experience;
                _playerLevel = stat.Level;
            }
        }

        public void Dirty(Inventory inventory)
        {
            DirtyEvent?.Invoke();
        }

        public event GUIStatsDirtyDelegate DirtyEvent;

        private string FormatRuntime()
        {
            return (DateTime.Now - _initSessionDateTime).ToString(@"dd\.hh\:mm\:ss");
        }

        public double GetRuntime()
        {
            return (DateTime.Now - _initSessionDateTime).TotalSeconds / 3600;
        }

        public static int GetXpDiff(int level)
        {
            if (level > 0 && level <= 40)
            {
                int[] xpTable = { 0, 1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000,
                    10000, 10000, 10000, 10000, 15000, 20000, 20000, 20000, 25000, 25000,
                    50000, 75000, 100000, 125000, 150000, 190000, 200000, 250000, 300000, 350000,
                    500000, 500000, 750000, 1000000, 1250000, 1500000, 2000000, 2500000, 1000000, 1000000};
                return xpTable[level - 1];
            }
            return 0;
        }

        public override string ToString()
        {
            return
                $"{_playerName} - Lvl: {_playerLevel.ToString()} (Runtime: {FormatRuntime()})";
        }
    }
}
