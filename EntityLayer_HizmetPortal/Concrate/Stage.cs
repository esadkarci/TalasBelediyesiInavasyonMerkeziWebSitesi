using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer_HizmetPortal.Concrate
{
    public class Stage
    {
        [Key]
        public int StageId { get; set; }
        [StringLength(20)]
        public string StageName { get; set; }
        public bool StageStatues { get; set; }
        public ICollection<Project> Projects { get; set; }

    }
}
