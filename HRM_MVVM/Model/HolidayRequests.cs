using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRM_MVVM.Model
{
    public class HolidayRequests
    {
        public enum RequestStatus
        {
            Accepted,
            Rejected,
            UnHandled
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int RequestId { get; set; }
        [Required]
        public DateTime RequestedDay { get; set; }
        [Required]
        public RequestStatus ReqStatus { get; set; }
        [Required]
        public Employee.Permissions HolidayPermissionsLevel { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; internal set; }

        public virtual Employee Employee { get; set; }
    }
}
