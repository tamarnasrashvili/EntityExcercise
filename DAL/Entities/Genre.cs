using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20,ErrorMessage ="Genre name must be at least 20 character")]
        public string Name { get; set; }
        public ICollection<MovieGenres> MovieGenres { get; set; }

    }
}
