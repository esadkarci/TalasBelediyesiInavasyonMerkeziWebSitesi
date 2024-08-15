using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer_HizmetPortal.Concrate
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        [StringLength(100)]
        public string EventTitle { get; set; }
        [StringLength(1000)]
        public string EventDescription { get; set; }
        
        public int EventCapacity { get; set; }
        public bool EventStatues { get; set; }
        public DateTime EventDate { get; set; }
        
        // İlişkiler
        public ICollection<Reservation> Reservations { get; set; }
    }
}
