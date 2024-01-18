using System;
using System.Collections.Generic;

namespace BJM.DVDCentral.PL2.Entities;

public class tblMovie
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public double Cost { get; set; }

    public Guid RatingId { get; set; }

    public Guid FormatId { get; set; }

    public Guid DirectorId { get; set; }
    public int Quantity { get; set; }

    public string ImagePath { get; set; } = null!;
    public virtual ICollection<tblMovieGenre> tblMovieGenres { get; set; } = new List<tblMovieGenre>();
    public virtual tblRating Rating { get; set; } = new tblRating();
    public virtual tblDirector Director { get; set; } = new tblDirector();
    public virtual tblFormat Format { get; set; } = new tblFormat();
}
