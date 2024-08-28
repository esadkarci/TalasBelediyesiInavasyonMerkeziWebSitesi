using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer_HizmetPortal.Concrate
{
    public class Galeri
    {
        [Key]
        public int GaleriId { get; set; }
        [StringLength(500)]
        public string GaleriImage { get; set; }
        public bool GaleriStatus { get; set; }
    }
}
