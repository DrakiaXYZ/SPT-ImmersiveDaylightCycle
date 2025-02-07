﻿using BepInEx.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jehree.ImmersiveDaylightCycle.Helpers {
    internal class Settings
    {
        public static ConfigEntry<bool> modEnabled;
        public static ConfigEntry<int> raidExitTimeJump;
        public static ConfigEntry<float> daylightCycleRate;

        public static ConfigEntry<int> currentHour;
        public static ConfigEntry<int> currentMinute;
        public static ConfigEntry<int> currentSecond;

        public static ConfigEntry<bool> timeResetsOnDeath;
        public static ConfigEntry<bool> timeResetsOnDisconnect;
        public static ConfigEntry<int> resetHour;
        public static ConfigEntry<int> resetMinute;
        public static ConfigEntry<int> resetSecond;

        public static ConfigEntry<bool> factoryTimeAlwaysSelectable;

        public static void Init(ConfigFile Config)
        {
            modEnabled = Config.Bind(
                "1: Mod",
                "Mod Enabled",
                true,
                "Enables and disables the mod (wow woah crazy bro INSANE)."
            );

            raidExitTimeJump = Config.Bind(
                "2: Daylight Cycle",
                "Raid End Time Jump (hours)",
                1,
                "Number of hours to skip ahead in time when a raid ends."
            );

            daylightCycleRate = Config.Bind(
                "2: Daylight Cycle",
                "Cycle Rate",
                5f,
                "Rate at which the daylight cycle progresses. Vanilla default is 7."
            );

            currentHour = Config.Bind(
                "2: Daylight Cycle",
                "Current Out Of Raid Hour",
                8,
                new ConfigDescription(
                    "Current hour (updates at raid end) you may need to manually sync this with your friends if using Fika and playing on Factory to ensure the correct time selection is made",
                    new AcceptableValueRange<int>(0, 23)
                )
            );

            currentMinute = Config.Bind(
                "2: Daylight Cycle",
                "Current Out Of Raid Minute",
                0,
                new ConfigDescription(
                "Current minute (updates at raid end)",
                new AcceptableValueRange<int>(0, 59)
                )
            );

            currentSecond = Config.Bind(
                "2: Daylight Cycle",
                "Current Out Of Raid Second",
                0,
                new ConfigDescription(
                "Current second (updates at raid end)",
                new AcceptableValueRange<int>(0, 59)
                )
            );

            timeResetsOnDeath = Config.Bind(
                "2: Daylight Cycle",
                "Time Resets On Death",
                true,
                "Enable this to make the time reset to the time below on death."
            );

            timeResetsOnDisconnect = Config.Bind(
                "2: Daylight Cycle",
                "Time Resets On Disconnect",
                true,
                "Enable this to make the time reset to the time below on disconnect."
            );

            resetHour = Config.Bind(
                "2: Daylight Cycle",
                "Death Reset Hour",
                8,
                new ConfigDescription(
                    "Death reset hour, time will update to this time after death.",
                    new AcceptableValueRange<int>(0, 23)
                )
            );

            resetMinute = Config.Bind(
                "2: Daylight Cycle",
                "Death Reset Minute",
                0,
                new ConfigDescription(
                "Death reset minute, time will update to this time after death.",
                new AcceptableValueRange<int>(0, 59)
                )
            );

            resetSecond = Config.Bind(
                "2: Daylight Cycle",
                "Death Reset Second",
                0,
                new ConfigDescription(
                "Death reset second, time will update to this time after death.",
                new AcceptableValueRange<int>(0, 59)
                )
            );

            factoryTimeAlwaysSelectable = Config.Bind(
                "3: Factory",
                "Factory Time Always Selectable",
                false,
                "Enable this to make Factory always have selectable day or night time."
            );
        }

        public static DateTime GetSavedGameTime()
        {
            return new DateTime(2024, 6, 8, currentHour.Value, currentMinute.Value, currentSecond.Value);
        }

        public static DateTime GetResetGameTime()
        {
            return new DateTime(2024, 6, 8, resetHour.Value, resetMinute.Value, resetSecond.Value);
        }

        public static void SaveGameTime(int hour, int minute, int second)
        {
            currentHour.Value = hour;
            currentMinute.Value = minute;
            currentSecond.Value = second;
        }
    }
}
