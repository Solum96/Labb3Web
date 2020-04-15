using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb3Web.Data.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int SeatNumber { get; set; }
        public bool Booked { get; set; }
    }
}
