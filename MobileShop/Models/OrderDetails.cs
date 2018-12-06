using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MobileShop.Models
{
    public class OrderDetails
    {
        [Key]
        [Required(ErrorMessage = "ID is required")]
        public int PID { get; set; } //fk

        [Key]
        [Required(ErrorMessage = "ID is required")]
        public int oID { get; set; } //fk
        //el etnen el fo2 dol composite key 


        public int Quantity { get; set; }
        public Products _products { get; set; }
        //public int oID { get; set; } //fk
        public Orders _orders { get; set; }
    }
}
