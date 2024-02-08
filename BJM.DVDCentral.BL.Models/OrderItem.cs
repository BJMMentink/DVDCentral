using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJM.DVDCentral.BL.Models
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        [DisplayName("Order #")]
        public Guid OrderId { get; set; }
        public Guid MovieId { get; set; }
        public int Quantity { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Cost { get; set; }

        [DisplayName("Movie Title")]
        public string MovieTitle { get; set; }

        public string ImagePath { get; set; }
    }
}
