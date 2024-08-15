using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer_HizmetPortal.Concrate
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }
        
        public DateTime ReservationDate { get; set; }

        public bool ReservationStatues { get; set; }


        // İlişkiler
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int? EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}
