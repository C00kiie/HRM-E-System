using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRM_MVVM.Model
{
    public class Attendance
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttendanceId { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public DateTime Day { get; set; }
        [Required]
        public double Lat { get; set; }
        [Required]
        public double Long { get; set; }
    }
}
