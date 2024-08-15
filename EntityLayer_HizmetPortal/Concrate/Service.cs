using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer_HizmetPortal.Concrate
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }
        [StringLength(100)]
        public string ServiceTitle { get; set; }
        [StringLength(1000)]
        public string ServiceDescription { get; set; }       
        public bool ServiceStatues { get; set; }
        // İlişkiler
        public ICollection<Appointment> Appointments { get; set; }
    }
}
