using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileShop.Models
{
    public class Customer_order
    {
        //model for many to many relationship

        
            
        [Required(ErrorMessage = "ID is required")]
        public int CID { get; set; }
        public Customers customer { get; set; }
        
        [Required(ErrorMessage = "ID is required")]
        public int oID { get; set; }
        public Orders orders { get; set; }
    }
}
