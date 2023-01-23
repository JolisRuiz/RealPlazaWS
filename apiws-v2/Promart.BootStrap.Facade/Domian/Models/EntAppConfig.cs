using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian.Models
{
    public class EntAppConfig
    {
        public string Mode { get; set; }
        public string OracleConnection { get; set; }
        public string MySqlConnection { get; set; }
        public string SqlServerConnection { get; set; }
    }
}
