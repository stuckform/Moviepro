using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Moviepro.Models
{
    public class Studio
    {
        public int Id { get; set; }

        public string Name { get; set;}

        public string Location { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Founded Date")]
        public DateTime FoundedDate { get; set; }

        public decimal Revenue { get; set; }

        //parent needs to know who the children are
        public virtual ICollection<Movie>Movies { get; set; }

    }
}
