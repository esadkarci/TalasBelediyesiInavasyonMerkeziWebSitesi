using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer_HizmetPortal.Concrate
{
    public class Lesson
    {
        [Key]
        public int LessonId { get; set; }
        [StringLength(100)]
        public string LessonTitle { get; set; }
        [StringLength(1000)]
        public string LessonDescription { get; set; }
        [StringLength(200)]
        public string LessonImage { get; set; }
        public bool LessonStatues { get; set; }
    }
}
