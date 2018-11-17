using System;
using System.Collections.Generic;
using System.Data.Entity;
using HRM_MVVM.Model;
using System.Device.Location;
using System.Linq;
using System.Threading.Tasks;

namespace HRM_MVVM.ViewModels
{
    public class AttendanceViewModel 
    {
        public readonly HRM_DB _context;

        public AttendanceViewModel( HRM_DB context)
        {
            _context = context;
        }
        public async void RegisterAttendance(int EmployeeId)
        {
            GeoCoordinate coordinate = new GeoCoordinate();
            var attendence = new Attendance()
            {
                EmployeeId = EmployeeId,
                Day = DateTime.Now,
                Lat = coordinate.Altitude,
                Long = coordinate.Longitude
            };
            _context.Attendances.Add(attendence);
            await _context.SaveChangesAsync();

        }

        public async Task<List<Attendance>> GetAttendanceHistory(int EmployeeId)
        {
            return await Task.Run(() => _context.Attendances.Where(p => p.EmployeeId == EmployeeId).ToListAsync());
        }


    }
}
