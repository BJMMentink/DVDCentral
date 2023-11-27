using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJM.DVDCentral.BL.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [DisplayName("Movie Title")]
        public string Title { get; set; } = string.Empty;

        [DisplayName("Movie Description")]
        public string Description { get; set; } = string.Empty;

        [DisplayName("Cost")]
        public float Cost { get; set; }

        [DisplayName("Rating ID")]
        public int RatingId { get; set; }

        [DisplayName("Format ID")]
        public int FormatId { get; set; }

        [DisplayName("Director ID")]
        public int DirectorId { get; set; }

        [DisplayName("Quantity")]
        public int InStkQty { get; set; }

        [DisplayName("Image")]
        public string ImagePath { get; set; } = string.Empty;

        [DisplayName("Rating")]
        public string RatingDescription { get; set; } = string.Empty;

        [DisplayName("Format")]
        public string FormatDescription { get; set; } = string.Empty;

        [DisplayName("Director Name")]
        public string DirectorName { get; set; } = string.Empty;

        public List<Genre> Genre { get; set; } = new List<Genre>();
    }
}
