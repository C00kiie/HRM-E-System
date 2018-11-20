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
        public readonly HRM_DB _context;

        public ViewEmployeesViewModel(HRM_DB context)
        {
            _context = context;
        }
        public async void AddEmployee(
            string name,
            DateTime birthDateTime,
            DateTime joinedSinceDateTime,
            string password,
            string email,
            Employee.Experience_ experience,
            List<Employee.Permissions> perms,
            int isActivated,
            int departmentId = 0
            )

        {
            var department = await _context.Departments.FirstOrDefaultAsync(p => p.DepartmentId == departmentId);
            var empInfo = new EmployeeInfo()
            {
                Birthdate = birthDateTime,
                Experience = experience,
                JoinedSince = joinedSinceDateTime,
                Name =  name,
            };
            var empLogin = new EmployeeLogin()
            {
                Email = email,
                IsActivated = isActivated,
                Password = password
            };
            var emp = new Employee()
            {
                EmployeeInfo = empInfo,
                EmployeeLogin = empLogin,
                Permission = perms,
                Department = department
            };

            // saving changes
            _context.Employees.Add(emp);
            _context.EmployeeInfos.Add(empInfo);
            _context.Logins.Add(empLogin);
            await _context.SaveChangesAsync();
        }

        public  List<EmployeeInfo> GetUsersInfo()
        {
            return  _context.EmployeeInfos.ToList();
        }
        public async void RemoveEmployee(int employeeId)
        {
            var emp = await _context.Employees.FindAsync(employeeId);
            var empLogin = await _context.Logins.FindAsync(employeeId);
            var empInfo = await _context.EmployeeInfos.FindAsync(employeeId);

            if (emp != null && empLogin != null && empInfo != null)
            {
                _context.Employees.Remove(emp);
                _context.Logins.Remove(empLogin);
                _context.EmployeeInfos.Remove(empInfo);
                await _context.SaveChangesAsync();
            }
        }
        public async void DeactivateUser(int userId)
        {
            var user = _context.Logins.FirstOrDefaultAsync(p => p.LoginId == userId);
            if (user != null)
            {
                user.Result.IsActivated = 0;
                await _context.SaveChangesAsync();
            }
        }
        public async void ActivateUser(int userId)
        {
            var user = _context.Logins.FirstOrDefaultAsync(p => p.LoginId == userId);
            if (user != null)
            {
                user.Result.IsActivated = 1;
                await _context.SaveChangesAsync();
            }
        }
    }
}
