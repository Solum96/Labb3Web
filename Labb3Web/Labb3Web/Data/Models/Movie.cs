using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Labb3Web.Data.Models
{
    public class Movie
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }
    }
}
