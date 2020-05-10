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
            {"PlayerNotFound", "Игрок не найден" },
            { "Info_Player0", "Имя в игре: {0}. Имя в Steam: {1}. SteamID64: {2}. SteamID64Group: {3}. IP: {4}. Пинг: {5}" },
            { "Info_Player1", "Здоровье: {0}. Голод: {1}. Жажда: {2}. Радиация: {3}." },
            { "Info_Player2", "Энергия: {0}. Кислород: {1}. Опыт: {2}. Кровотечение?: {3}. Кость сломана?: {4}" }
        };
    }
}