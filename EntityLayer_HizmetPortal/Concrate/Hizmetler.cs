using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer_HizmetPortal.Concrate
{
    public class Hizmetler
    {
        [Key]
        public int HizmetId { get; set; }
        [StringLength(100)]
        public string HizmetName { get; set; }
        [StringLength(1000)]
        public string HizmetDescription { get; set; }
        [StringLength(200)]
        public string HizmetImage { get; set; }
        [StringLength(200)]
        public string HizmetIcon { get; set; }
        public bool HizmetStatus { get; set; }
    }
}
