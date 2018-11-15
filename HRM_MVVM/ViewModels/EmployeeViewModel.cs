using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using HRM_MVVM.Model;

namespace HRM_MVVM.ViewModels
{
    public class EmployeeViewModel
    {
        private readonly HRM_DB _context;

        public EmployeeViewModel(HRM_DB context)
        {
            _context = context;
        }
        public async void AddEmployee(
                    string name, 
                    DateTime birthDateTime, 
                    DateTime joinedSinceDateTime,  
                    string Password, 
                    string email,
                    Employee.Experience_ experience,
                    Employee.Permission_ permission, 
                    int departmentId, 
                    int isActivated)

        {
            var emp = new Employee()
            {
                Name = name,
                Birthdate =  birthDateTime,
                JoinedSince = joinedSinceDateTime,
                Email = email, 
                Password = Functions.password.ComputeSha256Hash(Password),
                Experience =  experience,
                Permission =  permission, 
                DepartmentId =  departmentId,
                IsActivated =  1
            };
            _context.Employees.Add(emp);
            await _context.SaveChangesAsync();

        }
        public async void UpdateEmployee( int userId,
            string name,
            DateTime birthDateTime,
            DateTime joinedSinceDateTime,
            string Password,
            string email,
            Employee.Experience_ experience,
            Employee.Permission_ permission,
            int departmentId,
            int isActivated)
        {
            var emp = await _context.Employees.FindAsync(userId);
            // updating all fields.
            emp.Name = name;
            emp.Birthdate = birthDateTime;
            emp.JoinedSince = joinedSinceDateTime;
            emp.Email = email;
            emp.Password = Functions.password.ComputeSha256Hash(Password);
            emp.Experience = experience;
            emp.Permission = permission;
            emp.DepartmentId = departmentId;
            emp.IsActivated = 1;
            // save changes
            await _context.SaveChangesAsync();

        }

        public async void RemoveEmployee(int employeeId)
        {
            var emp = await _context.Employees.FindAsync(employeeId);
            if (emp != null)
            {
                _context.Employees.Remove(emp);
                await _context.SaveChangesAsync();
            }
        }
        public async void DeactivateUser(int userId)
        {
            var user = _context.Employees.FirstOrDefaultAsync(p=> p.Id == userId);
            if (user != null)
            {
                user.Result.IsActivated = 0;
                await _context.SaveChangesAsync();
            }
        }
        public async void ActivateUser(int userId)
        {
            var user = _context.Employees.FirstOrDefaultAsync(p => p.Id == userId);
            if (user != null)
            {
                user.Result.IsActivated = 1;
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Employee> Employee_info(int userId)
        {
            return await _context.Employees.FirstOrDefaultAsync(p=> p.Id == userId);
        }
    }
}
