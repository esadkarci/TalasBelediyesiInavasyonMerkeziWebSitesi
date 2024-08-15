using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer_HizmetPortal.Concrate
{
    public class Haberler
    {
        [Key]
        public int HaberId { get; set; }
        [StringLength(150)]  
        public string HaberTitle { get; set; }
        [StringLength(2500)]
        public string HaberDescription { get; set; }
        [StringLength(400)]
        public string HaberImage { get; set; }
        
        public DateTime HaberDate { get; set; }
        
    }
}
