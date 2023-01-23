using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian.Models
{
    public class Usuario
    {
        [Key]
        public int user_id { get; set; }
        public int company_id { get; set; }
        public int person_id { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public string search { get; set; }
        public int created_by { get; set; }
        public DateTime created_date { get; set; }
        public int updated_by { get; set; }
        public DateTime updated_date { get; set; }
        public int user_status { get; set; }


    }
}
