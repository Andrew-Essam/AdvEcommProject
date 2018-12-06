using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileShop.Models
{
    public class Orders
    {
        [Key]
        [Required(ErrorMessage = "ID is required")]
        public int oID { get; set; } //pk

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string DeliveryStatus{ get; set; }

        public int CID { get; set; }
        public Customers clist { get; set; }

        public Feedback feedback { get; set; }

        public List<OrderDetails> odlist { get; set; }

        //public int paymentSerial { get; set; }
        //public Payment payment { get; set; }
    }
}
