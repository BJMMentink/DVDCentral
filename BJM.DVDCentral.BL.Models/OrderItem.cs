using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJM.DVDCentral.BL.Models
{
    internal class OrderItem
    {
        public int ID { get; set; }
        public int OrderId { get; set; }
        public int MovieId { get; set; }
        public int Quantity { get; set; }
        public float Cost { get; set; }
    }
}
