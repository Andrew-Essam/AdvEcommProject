using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileShop.Models
{
    public class Category
    {

        [Key]
        [Required(ErrorMessage = "ID is required")]
        public int CatID { get; set; } //pk

        public string CatName { get; set; }

        public List<Products> plist { get; set; }
    }
}
