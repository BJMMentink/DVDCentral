
using BJM.DVDCentral.BL.Models;

namespace BJM.DVDCentral.UI.ViewModels
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; } = 0;
        public string CustomerName { get; set; }
        public List<Customer> Customers { get; set; }
        public int UserId { get; set; } = 0;
        public List<ShoppingCart> Cart { get; set; }

        public CustomerViewModel()
        {
            Customers = new List<Customer>();
            Cart = new List<ShoppingCart>();
        }
    }
}
