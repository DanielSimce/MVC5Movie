using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateRelease { get; set; }
        [Display(Name = "Genre")]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }


    }
}
