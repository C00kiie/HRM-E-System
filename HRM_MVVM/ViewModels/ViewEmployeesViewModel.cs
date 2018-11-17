using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRM_MVVM.Model;

namespace HRM_MVVM.ViewModels
{
    public class ViewEmployeesViewModel
    {
        private readonly HRM_DB _context;

        public ViewEmployeesViewModel(HRM_DB context)
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
                Permission = permission
            };
            int maxId = Int32.Parse(_context.Employees.SqlQuery("select max(Id) from Employees").ToString()) + 1;

            var empInfo = new EmployeeInfo()
            {
                Id =  maxId,
                Name = name,
                Experience = experience,
                Birthdate = birthDateTime,
                DepartmentId = departmentId,
                JoinedSince =  joinedSinceDateTime
            };

            var empLogin = new login()
            {
                Id =  maxId,
                Email = email,
                Password = Functions.password.ComputeSha256Hash(Password),
                IsActivated = 1
            };
            
            _context.Employees.Add(emp);
            _context.Logins.Add(empLogin);
            _context.EmployeeInfos.Add(empInfo);
            await _context.SaveChangesAsync();

        }


        public async void RemoveEmployee(int employeeId)
        {
            var emp = await _context.Employees.FindAsync(employeeId);
            var empLogin = await _context.Logins.FindAsync(employeeId);
            var empInfo = await _context.EmployeeInfos.FindAsync(employeeId);

            if (emp != null && empLogin != null && empInfo!=null)
            {
                _context.Employees.Remove(emp);
                _context.Logins.Remove(empLogin);
                _context.EmployeeInfos.Remove(empInfo);
                await _context.SaveChangesAsync();
            }
        }
        public async void DeactivateUser(int userId)
        {
            var user = _context.Logins.FirstOrDefaultAsync(p => p.Id == userId);
            if (user != null)
            {
                user.Result.IsActivated = 0;
                await _context.SaveChangesAsync();
            }
        }
        public async void ActivateUser(int userId)
        {
            var user = _context.Logins.FirstOrDefaultAsync(p => p.Id == userId);
            if (user != null)
            {
                user.Result.IsActivated = 1;
                await _context.SaveChangesAsync();
            }
        }
    }
}
