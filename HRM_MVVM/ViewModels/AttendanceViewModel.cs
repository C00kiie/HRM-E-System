using System;
using System.Collections.Generic;
using HRM_MVVM.Model;
using System.Device.Location;
using System.Linq;

namespace HRM_MVVM.ViewModels
{
    public class AttendanceViewModel 
    {
        public readonly HRM_DB _context;

        public AttendanceViewModel( HRM_DB context)
        {
            _context = context;
        }

        public  List<HolidayRequests> GetHolidaysByThisMonth(Employee employee, DateTime now)
        {
            var holidays =  _context.HolidayRequests.
                Where(p => p.EmployeeId == employee.Id
                      && p.RequestedDay.Month == now.Month).
                ToList();
            return holidays;
        }
        
        public  void RegisterAttendance(Employee employee)
        {
            GeoCoordinate coordinate = new GeoCoordinate();
            var attendence = new Attendance()
            {
                EmployeeId = employee.Id,
                Day = DateTime.Now,
                Lat = coordinate.Altitude,
                Long = coordinate.Longitude
            };
            _context.Attendances.Add(attendence);
            _context.SaveChangesAsync();

        }

        public  List<Attendance> GetAttendanceHistoryByThisMonth(Employee Employee, DateTime now)
        {
            return _context.Attendances.
                Where(p => p.EmployeeId == Employee.Id &&
                      p.Day.Month == now.Month).
                     ToList();
        }


    }
}
