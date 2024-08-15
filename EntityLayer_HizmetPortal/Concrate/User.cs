using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer_HizmetPortal.Concrate
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [StringLength(10)]
        public string UserName { get; set; }
        [StringLength(100)]
        public string UserSurName { get; set; }
        [StringLength(100)]
        public string UserPassword { get; set; }
        [StringLength(100)]
        public string UserEmail { get; set; }       
        public bool UserStatues { get; set; }

        [StringLength(1)]
        public string UserRank { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        
    }
}
