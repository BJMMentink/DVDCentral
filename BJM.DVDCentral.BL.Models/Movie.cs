using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJM.DVDCentral.BL.Models
{
    internal class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public float Cost { get; set; }
        public int RatingId { get; set; }
        public int FormatId { get; set; }
        public int DirectorId { get; set; }
        public int InStkQty { get; set; }
        public string ImagePath { get; set; } = string.Empty;
    }
}
