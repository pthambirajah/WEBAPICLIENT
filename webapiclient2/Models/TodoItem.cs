using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webapiclient2.Models
{

        public class TodoItem
        {
        /* public long Id { get; set; }
         public string Name { get; set; }
         public bool IsComplete { get; set; }*/
        [Key]
        public int FlightNo { get; set; }

        [StringLength(50), MinLength(3)]
        public string Departure { get; set; }

        [StringLength(50), MinLength(3)]
        public string Destination { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public short? Seats { get; set; }

        public virtual ICollection<Booking> BookingSet { get; set; }
    }
    
}
