using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer_HizmetPortal.Concrate
{
    public class Duyurular
    {
        [Key]
        public int DuyurularId { get; set; }
        [StringLength(500)]
        public string DuyurularImage { get; set; }
        public bool DuyurularStatus {  get; set; } 
    }
}
