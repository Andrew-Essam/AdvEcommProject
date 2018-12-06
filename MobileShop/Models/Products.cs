using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MobileShop.Models
{
    public class Products
    {
        [Key]
        [Required(ErrorMessage = "ID is required")]
        public int PID { get; set; } // primary key

        public string PName { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public decimal Stock { get; set; }

        public List<Feedback> flist { get; set; }

        [Required(ErrorMessage = "ID is required")]
        public int CatID { get; set; } //fk
        public Category _category { get; set; }
        public Suppliers _suppliers { get; set; }
        public List<OrderDetails> odlist { get; set; }
        //public int PID { get; set; } //fk

        [Required(ErrorMessage = "ID is required")]
        public int oID { get; set; } //fk
        //el etnen el fo2 dol composite key
        
    }
}
