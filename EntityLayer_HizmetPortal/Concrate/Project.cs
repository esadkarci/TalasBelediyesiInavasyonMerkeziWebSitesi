using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer_HizmetPortal.Concrate
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [StringLength(100)]
        public string ProjectTitle { get; set; }
        [StringLength(1000)]
        public string ProjectDescription { get; set; }
        [StringLength(200)]
        public string ProjectImage { get; set; }
        public bool ProjectStatues { get; set; }
        public int StageId { get; set; }
        public virtual Stage Stage { get; set; }
    
    }
}
