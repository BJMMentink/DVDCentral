using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJM.DVDCentral.BL.Models
{
    public class ShoppingCart
    {
        const double TAX_RATE = .055;

        public List<Movie> Items { get; set; } = new List<Movie>();
        public List<Customer> Customer { get; set; } = new List<Customer>();
        public int NumberOfItems
        {
            get { return Items.Count; }
        }

        [DisplayFormat(DataFormatString = "{0:C}")] // formats to currency
        public double SubTotal
        {
            get { return Items.Sum(item => item.Cost); }
        }

        [DisplayFormat(DataFormatString = "{0:C}")] // formats to currency
        public double Tax
        {
            get { return SubTotal * TAX_RATE; }
        }

        [DisplayFormat(DataFormatString = "{0:C}")] // formats to currency
        public double Total
        {
            get { return SubTotal + Tax; }
        }
    }
}
