using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRM_MVVM.Model
{
    public class attendance
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttendanceId { get; set; }
        [Required]
        public int userId { get; set; }
        [Required]
        public DateTime Day { get; set; }
        [Required]
        public double Lat { get; set; }
        [Required]
        public double Long { get; set; }
    }
}
