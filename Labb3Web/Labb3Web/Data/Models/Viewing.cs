using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb3Web.Data.Models
{
    public class Viewing
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public Movie Movie { get; set; }
        public List<Ticket> BookedSeats { get; set; }
    }
}
