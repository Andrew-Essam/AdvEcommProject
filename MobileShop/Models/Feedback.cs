using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileShop.Models
{
    public class Feedback
    {
        [Key]
        [Required(ErrorMessage = "ID is required")]
        public int fID { get; set; }

        //many to many relationship
        [Required(ErrorMessage = "ID is required")]
        public int CID { get; set; }
        //FK
        [Required(ErrorMessage = "ID is required")]
        public int PID { get; set; }
        //FK
        //EL ETNEN EL fo2 dol m3 b3d composite key (pk)=fk+fk
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public Customers _customers { get; set; }
        public List<Orders> olist { get; set; }
        public int oID { get; set; } //fk

        public Products product { get; set; }
    }
}
