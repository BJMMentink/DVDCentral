using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJM.DVDCentral.BL.Models
{
    public class Genre
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
