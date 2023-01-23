using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian.Models
{
    public class Menu
    {
        [Key]
        public int MenuID { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string Component { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public int FatherMenu { get; set; }
        public bool IsVisible { get; set; }
        public bool MenuStatus { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
