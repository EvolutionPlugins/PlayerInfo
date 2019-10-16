using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player_Info
{
    public class Pinfo : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "pinfo";

        public string Help => "Информация об игроке";

        public string Syntax => "/pinfo <nickname>";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string>() { "Pinfo" };

        public void Execute(IRocketPlayer caller, string[] arg)
        {
            UnturnedPlayer pl = (UnturnedPlayer)caller;
            if (arg.Length == 1)
            {
                UnturnedPlayer sp = UnturnedPlayer.FromName(arg[0]);
                if (sp != null)
                {
                    string nickname = sp.DisplayName;
                    string nicknameSteam = sp.SteamName;
                    ulong steam = sp.CSteamID.m_SteamID;
                    ulong steamgroup = sp.SteamGroupID.m_SteamID;
                    string IP = sp.IP;
                    float ping = sp.Ping;
                    byte health = sp.Health;
                    byte hungry = sp.Hunger;
                    byte water = sp.Thirst;
                    byte poison = sp.Infection;
                    byte energy = sp.Stamina;
                    byte oxygen = sp.Player.life.oxygen;
                    uint exp = sp.Experience;
                    bool bleeding = sp.Bleeding;
                    bool broken = sp.Broken;
                    UnturnedChat.Say(pl, Plugin.Instance.Translate("Info_Player0", nickname, nicknameSteam, steam, steamgroup, IP, ping), Color.magenta);
                    UnturnedChat.Say(pl, Plugin.Instance.Translate("Info_Player1", health, hungry, water, poison), Color.magenta);
                    UnturnedChat.Say(pl, Plugin.Instance.Translate("Info_Player2", energy, oxygen, exp, bleeding, broken), Color.magenta);
                    
                }
                else
                {
                    UnturnedChat.Say(pl, "Игрок не найден", Color.red);
                }
            }
            else
            {
                UnturnedChat.Say(caller, Syntax, Color.yellow);
                return;
            }
        }
    }
}
