using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class MovieGenres
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int GenreId { get; set; }
        public Movie Movie { get; set; }
        public Genre Genre { get; set; }
    }
}
