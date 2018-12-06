using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileShop.Models
{
    public class Payment
    {
        [Key]
        [Required(ErrorMessage = "ID is required")]
        public int paymentSerial { get; set; }


        [Required(ErrorMessage = "ID is required")]
        public int oID { get; set; }
        
        public Orders Order { get; set; }


        [Required(ErrorMessage = "ID is required")]
        public int cardNo { get; set; }

        public CardDetails CardDetails { get; set; }
    }
}
