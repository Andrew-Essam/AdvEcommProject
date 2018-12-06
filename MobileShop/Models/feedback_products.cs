using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileShop.Models
{
    public class feedback_products
    {
        [Required(ErrorMessage = "ID is required")]
        public int CID { get; set; }
        //FK
        [Required(ErrorMessage = "ID is required")]
        public int PID { get; set; }
        //FK
        //EL ETNEN EL fo2 dol m3 b3d composite key (pk)=fk+fk
        public Feedback _feedback { get; set; }
        public Products _products { get; set; }

    }
}
