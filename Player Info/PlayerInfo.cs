using Rocket.API.Collections;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using System;

namespace PlayerInfo
{
    public class PlayerInfo : RocketPlugin
    {
        public static PlayerInfo Instance;

        protected override void Load()
        {
            Instance = this;
            Logger.Log("Made with <3 by Evolution Plugins", ConsoleColor.Cyan);
            Logger.Log("https://vk.com/evolutionplugins", ConsoleColor.Cyan);
        }

        protected override void Unload()
        {
            Instance = null;
        }

        public override TranslationList DefaultTranslations => new TranslationList
        {
            {"PlayerNotFound", "Player not found" },
            { "Info_Player0", "Display name: {0}. Name in Steam: {1}. SteamID64: {2}. SteamID64Group: {3}. IP: {4}. Ping: {5}" },
            { "Info_Player1", "Health: {0}. Hunger: {1}. Water: {2}. Virus: {3}." },
            { "Info_Player2", "Stamina: {0}. Oxygen: {1}. Experience: {2}. Is Bleeding: {3}. Is Broken Legs: {4}" }
        };
    }
}
