using Rocket.API;
using Rocket.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerInfo
{
    public class PlayerInfoConfiguration : IRocketPluginConfiguration
    {
        public bool UseRich;
        public void LoadDefaults()
        {
            UseRich = true;
        }
    }
}
