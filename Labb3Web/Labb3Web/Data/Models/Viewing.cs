using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labb3Web.Data.Models
{
    public class Viewing
    {
        [Key]
        public string Id { get; set; }
        public string Time { get; set; }
        public string Movie { get; set; }
        public int TicketsLeft { get; set; }
    }
}
