using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileShop.Models
{
    public class Suppliers
    {
        [Key]
        [Required(ErrorMessage = "ID is required")]
        public int SID { get; set; } //pk


        public string SName { get; set; }
        public string SPhone { get; set; }
        
        public string SAddress { get; set; }

        [Required(ErrorMessage = "ID is required")]
        public int PID { get; set; } //fk
        public List<Products> plist { get; set; }
    }
}
