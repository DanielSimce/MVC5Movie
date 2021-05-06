using MovieApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.ViewModel
{
    public class MovieVM
    {
        public int Id { get; set; }
        public List<Genre> Genres { get; set; }
        public string Name { get; set; }
        public DateTime DateRelease { get; set; }
        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        public string Title { get { return Id != 0 ? "Update" : "New"; }  }
        public string Btn { get { return Id != 0 ? "Update" : "New"; } }

    }
}
