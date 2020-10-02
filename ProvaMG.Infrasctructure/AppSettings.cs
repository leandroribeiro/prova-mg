using System;
using System.Collections.Generic;
using System.Linq;

namespace ProvaMG.Infrasctructure
{
    public class AppSettings
    {

        public AppSettings()
        {
            
        }

        public AppSettings(string secret)
        {
            this.Secret = secret;
        }

        public string Secret { get; set; }
    }
}
