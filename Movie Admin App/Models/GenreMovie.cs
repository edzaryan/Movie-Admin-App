﻿namespace Movie_Admin_App.Models
{
    public class GenreMovie
    {
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }

        public int MovieId { get; set; }
        public Movie? Movie { get; set; }
    }
}
