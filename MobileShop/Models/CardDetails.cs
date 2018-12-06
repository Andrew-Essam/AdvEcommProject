using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileShop.Models
{
    public class CardDetails
    {

        [Key]
        [Required(ErrorMessage = "ID is required")]
        public int cardNo { get; set; } //pk

        [DataType(DataType.Date)]
        public DateTime Exp_date { get; set; }

        public int cvv { get; set; }

        public List<Payment> Payment { get; set; }
    }
}
