using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace HRM_MVVM.Model
{
    public class Activity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActivityId { get; set; }
        [ForeignKey("Employee")]
        [Required] public int UserId;
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
