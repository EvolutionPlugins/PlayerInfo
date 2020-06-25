using Rocket.API.Collections;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using System;

namespace PlayerInfo
{
    public class PlayerInfo : RocketPlugin<PlayerInfoConfiguration>
    {
        public static PlayerInfo Instance;
        public PlayerInfoConfiguration Config;

        protected override void Load()
        {
            Instance = this;
            Config = Configuration.Instance;
            Logger.Log("Made with <3 by Evolution Plugins", ConsoleColor.Cyan);
            Logger.Log("https://vk.com/evolutionplugins", ConsoleColor.Cyan);
            Logger.Log("Discord: DiFFoZ#6745", ConsoleColor.Cyan);

            DefaultTranslations["Info_Player0"].Replace('[', '<').Replace(']', '>');
            DefaultTranslations["Info_Player1"].Replace('[', '<').Replace(']', '>');
            DefaultTranslations["Info_Player2"].Replace('[', '<').Replace(']', '>');
        }

        protected override void Unload()
        {
            Instance = null;
            Config = null;
        }

        public override TranslationList DefaultTranslations => new TranslationList
        {
            { "PlayerNotFound", "Player not found" },
            { "Info_Player0", "[color=green]Display name: {0}. Name in Steam: {1}. SteamID: {2}. SteamIDGroup: {3}. IP: {4}. Ping: {5}[/color]" },
            { "Info_Player1", "[color=green]Health: {0}. Hunger: {1}. Water: {2}. Virus: {3}[/color]" },
            { "Info_Player2", "[color=green]Stamina: {0}. Oxygen: {1}. Experience: {2}. Is Bleeding: {3}. Is Broken Legs: {4}[/color]" }
        };
    }
}
