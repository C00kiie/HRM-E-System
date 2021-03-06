﻿using System;
using System.Linq;
using HRM_MVVM.Model;

namespace HRM_MVVM.ViewModels
{
    public class EmployeeViewModel
    {
        public readonly HRM_DB _context;

        public EmployeeViewModel(HRM_DB context)
        {
            _context = context;
        }
        public  void UpdateEmployee(int employeeId,
            string name,
            DateTime birthDateTime
        )
        {
            var emp =  _context.EmployeeInfos.FirstOrDefault(p => p.EmployeeInfoId == employeeId);
            if (emp != null)
            {
                // updating all fields 
                emp.Name = name;
                emp.Birthdate = birthDateTime;
                // save changes
                 _context.SaveChangesAsync();
            }

        }

        public  string RegisterAttendance(Employee employee)
        {
            var lastRecord = _context.Attendances.FirstOrDefault(p => p.EmployeeId == employee.Id
                                                                      && p.Day.Day == DateTime.Now.Day
                                                                      && p.Day.Month == DateTime.Now.Month
                                                                      && p.Day.Year == DateTime.Now.Year);
                            
            if (lastRecord == null)
            {

                // lat/long are manually set for the sake of proof-of-concept
                var attendance = new Attendance()
                {
                    EmployeeId = employee.Id,
                    Day = DateTime.Now,
                    Lat = 4.4444,
                    Long = 4.44444
                };
                var checkHoliday = _context.HolidayRequests.FirstOrDefault(
                    p =>  p.RequestedDay.Day == DateTime.Now.Day
                          && p.RequestedDay.Month == DateTime.Now.Month
                          && p.RequestedDay.Year == DateTime.Now.Year
                          && p.ReqStatus == HolidayRequests.RequestStatus.Accepted
                         );
                if (checkHoliday == null)
                {
                    _context.Attendances.Add(attendance);
                    _context.SaveChanges();
                    return "Done";
                }
                else
                {
                    return "You have a holiday on this day!";
                }
                
            }
            else
            {
                return "You've already registered";
            }
        }
        public bool EmailExists(string email)
        {
            var check = _context.Employees.FirstOrDefault(p => p.EmployeeLogin.Email == email);
            return check != null;
        }
        public  string UpdateEmployeeCredentials(string email, string password, string newPassword)
        {
            var emp = _context.Logins.FirstOrDefault(p => p.Email == email);
            if (emp != null)
            {
                    if (emp.Password == Functions.Password.ComputeSha256Hash(password))
                    {
                        emp.Email = email;
                        emp.Password = Functions.Password.ComputeSha256Hash(newPassword);
                        _context.SaveChanges();
                        return "Done";
                    }
                    else
                    {
                        return "Wrong password";
                    }
            }

            return "Null exception occured in the database; report the bug";
        }

    }
}
