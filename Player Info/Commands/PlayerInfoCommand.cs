using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerInfo
{
    public class PlayerInfoCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "pinfo";

        public string Help => "Shows information about a player";

        public string Syntax => "/pinfo <player>";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string> { "pinfo" };

        private PlayerInfo Instance => PlayerInfo.Instance;

        // Привет мир =D
        public void Execute(IRocketPlayer caller, string[] command)
        {
            var player = (UnturnedPlayer)caller;

            if (command.Length == 0)
            {
                UnturnedChat.Say(caller, $"Wrong command usage. Use correct: {Syntax}", Color.yellow);
                return;
            }

            var otherPlayer = UnturnedPlayer.FromName(string.Join(" ", command));
            if (otherPlayer == null)
            {
                UnturnedChat.Say(player, Instance.Translate("PlayerNotFound"), Color.red);
                return;
            }

            #region Vars

            var nickName = otherPlayer.DisplayName;
            var steamName = otherPlayer.SteamName;
            var csteamId = otherPlayer.CSteamID.m_SteamID;
            var steamGroup = otherPlayer.SteamGroupID.m_SteamID;
            var ip = SteamGameServerNetworking.GetP2PSessionState(otherPlayer.CSteamID, out var p2p) ? Parser.getIPFromUInt32(p2p.m_nRemoteIP) : "???";
            var ping = otherPlayer.Ping;
            var health = otherPlayer.Health;
            var hungry = otherPlayer.Hunger;
            var water = otherPlayer.Thirst;
            var virus = otherPlayer.Infection;
            var stamina = otherPlayer.Stamina;
            var oxygen = otherPlayer.Player.life.oxygen;
            var experience = otherPlayer.Experience;
            var isBleeding = otherPlayer.Bleeding;
            var isBroken = otherPlayer.Broken;

            #endregion Vars

            UnturnedChat.Say(player, Instance.Translate("Info_Player0", nickName, steamName, csteamId, steamGroup, ip, Mathf.Round(ping)), Color.magenta);
            UnturnedChat.Say(player, Instance.Translate("Info_Player1", health, hungry, water, virus), Color.magenta);
            UnturnedChat.Say(player, Instance.Translate("Info_Player2", stamina, oxygen, experience, isBleeding, isBroken), Color.magenta);
        }
    }
}