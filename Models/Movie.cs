using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Moviepro.Models
{
    public class Movie
    {
        public int Id { get; set; }


        public string Title { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        public string Genre { get; set; }

        public decimal Price { get; set; }

        //Navigation
        public int StudioId { get; set; }

        public virtual Studio Studio { get; set; }
    }
}
 