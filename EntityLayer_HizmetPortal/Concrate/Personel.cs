
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer_HizmetPortal.Concrate
{

    public class Personel
    {
        [Key]
        public int PersonelId { get; set; }
        [StringLength(30)]
        public string PersonelIsim { get; set; }
        [StringLength(30)]
        public string PersonelSoyisim { get; set; }
        [StringLength(30)]
        public string PersonelUnvan { get; set; }
        [StringLength(300)]
        public string PersonelImage { get; set; }
        [StringLength(7600)]
        public string PersonelCV { get; set; }
        public bool PersonelStatus { get; set; }
    }

}
