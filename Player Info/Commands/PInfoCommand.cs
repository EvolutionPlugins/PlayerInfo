using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerInfo
{
    public class PInfoCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "pinfo";

        public string Help => "Информация об игроке";

        public string Syntax => "/pinfo <nickname>";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string> { "pinfo" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            var player = (UnturnedPlayer)caller;

            if (command.Length == 0)
            {
                UnturnedChat.Say(caller, Syntax, Color.yellow);
                return;
            }

            var plugin = PlayerInfo.Instance;

            var otherplayer = UnturnedPlayer.FromName(command[0]);
            if (otherplayer == null)
            {
                UnturnedChat.Say(player, plugin.Translate("PlayerNotFound"), Color.red);
                return;
            }

            #region Vars

            var nickname = otherplayer.DisplayName;
            var steamNmae = otherplayer.SteamName;
            var csteamId = otherplayer.CSteamID.m_SteamID;
            var steamGroup = otherplayer.SteamGroupID.m_SteamID;
            var ip = otherplayer.IP;
            var ping = otherplayer.Ping;
            var health = otherplayer.Health;
            var hungry = otherplayer.Hunger;
            var water = otherplayer.Thirst;
            var poison = otherplayer.Infection;
            var energy = otherplayer.Stamina;
            var oxygen = otherplayer.Player.life.oxygen;
            var experience = otherplayer.Experience;
            var isBleeding = otherplayer.Bleeding;
            var isBroken = otherplayer.Broken;

            #endregion Vars

            UnturnedChat.Say(player, plugin.Translate("Info_Player0", nickname, steamNmae, csteamId, steamGroup, ip, ping), Color.magenta);
            UnturnedChat.Say(player, plugin.Translate("Info_Player1", health, hungry, water, poison), Color.magenta);
            UnturnedChat.Say(player, plugin.Translate("Info_Player2", energy, oxygen, experience, isBleeding, isBroken), Color.magenta);
        }
    }
}