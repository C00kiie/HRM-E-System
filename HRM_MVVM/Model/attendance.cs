using System;
using System.ComponentModel.DataAnnotations;
namespace HRM_MVVM.Model
{
    public class attendance
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime Day { get; set; }
        [Required]
        public string Lat { get; set; }
        [Required]
        public string Long { get; set; }
    }
}
