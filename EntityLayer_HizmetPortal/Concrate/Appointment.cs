using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer_HizmetPortal.Concrate
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime AppointmentStartTime { get; set; }
        
        public bool AppointmentStatues { get; set; }
        // İlişkiler
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int? ServiceId { get; set; }
        public virtual Service Service { get; set; }
    }
}
