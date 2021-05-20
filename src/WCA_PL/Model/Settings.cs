using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace WCA_PL.Model
{
    public class Settings
    {
        private readonly IConfiguration configuration;

        public Settings(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public int WorkersCount
        {
            get
            {
                return configuration.GetValue<int>("WorkerCount");
            }
        }

        public int RunInterval => configuration.GetValue<int>("RunInterval");

        public string ResultPath => configuration.GetValue<string>("ResultPath");

        public string InstanceName => configuration.GetValue<string>("name");
    }
}
