using Domian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Util.Helpers
{
    public static class Common
    {
        static Common() { }

        public static EntAppConfig getSettings(IConfiguration configuration)
        {

            EntAppConfig settings = new EntAppConfig();
            settings.SqlServerConnection = configuration.GetValue<string>("conexionSqlServer");
            settings.OracleConnection = configuration.GetValue<string>("conexionOracle");
            settings.MySqlConnection = configuration.GetValue<string>("conexionMySqlServer");
            settings.Mode = configuration.GetValue<string>("mode");
            //settings.Mode = Configuration.GetValue<string>("Logging:LogLevel:Default");
            return settings;

        }
    }
}
