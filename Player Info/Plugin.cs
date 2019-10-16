using Rocket.API.Collections;
using Rocket.Core.Plugins;
using System;
using Rocket.Core.Logging;

namespace Player_Info
{
    /*
     * This project was made only for the Russian-speaking community
     * And also this project was made back in 2018-2019, when I started programming
     */
    public class Plugin : RocketPlugin
    {
        public static Plugin Instance;
        protected override void Load()
        {
            Instance = this;
            Logger.Log("Cubix".PadLeft(15), ConsoleColor.Cyan);
            Logger.Log("https://vk.com/cubixplugins", ConsoleColor.Cyan);
        }
        protected override void Unload()
        {
            Instance = null;
        }
        public override TranslationList DefaultTranslations => new TranslationList
        {
            { "Info_Player0", "Имя в игре: {0}. Имя в Steam: {1}. SteamID64: {2}. SteamID64Group: {3}. IP: {4}. Пинг: {5}" },
            { "Info_Player1", "Здоровье: {0}. Голод: {1}. Жажда: {2}. Радиация: {3}." },
            { "Info_Player2", "Энергия: {0}. Кислород: {1}. Опыт: {2}. Кровотечение?: {3}. Кость сломана?: {4}" }
        };
    }
}
