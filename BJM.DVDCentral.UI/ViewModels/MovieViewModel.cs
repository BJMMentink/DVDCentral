namespace BJM.DVDCentral.UI.ViewModels
{
    public class MovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Genre> Genre { get; set; } = new List<Genre>();
        public List<Director> Director { get; set; } = new List<Director>();
        public List<Rating> Rating { get; set; } = new List<Rating>();
        public List<Format> Format { get; set; } = new List<Format>();
        public IEnumerable<int> GenreId { get; set; }
        public IFormFile File { get; set; }
        public MovieViewModel()
        {
            Genre = GenreManager.Load();
            Director = DirectorManager.Load();
            Rating = RatingManager.Load();
            Format = FormatManager.Load();
        }
        public MovieViewModel(int id)
        {
            Genre = GenreManager.Load();
            Movie = MovieManager.LoadById(id);
            Director = DirectorManager.Load();
            Rating = RatingManager.Load();
            Format = FormatManager.Load();
            GenreId = Movie.Genre.Select(g => g.Id);
        }
    }
}
