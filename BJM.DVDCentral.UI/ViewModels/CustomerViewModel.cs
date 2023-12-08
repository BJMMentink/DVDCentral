
using BJM.DVDCentral.BL.Models;

namespace BJM.DVDCentral.UI.ViewModels
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }
        public List<User> Users { get; set; }

        public CustomerViewModel()
        {
            Customer = new Customer(); 
            Users = new List<User>();
        }
    }
}
