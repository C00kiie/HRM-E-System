using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
        public List<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
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
                Name = name,
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
        public async void RemoveEmployee(Employee employee)
        {
            var emp = await _context.Employees.FindAsync(employee.Id);
            var empLogin = await _context.Logins.FindAsync(employee.Id);
            var empInfo = await _context.EmployeeInfos.FindAsync(employee.Id);

            if (emp != null && empLogin != null && empInfo != null)
            {
                _context.Employees.Remove(emp);
                _context.Logins.Remove(empLogin);
                _context.EmployeeInfos.Remove(empInfo);
                await _context.SaveChangesAsync();
            }
        }
        public async void DeactivateUser(Employee employee)
        {
            var user = _context.Logins.FirstOrDefaultAsync(p => p.LoginId == employee.Id);
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

        public List<Department> GetDepartments()
        {
            return _context.Departments.ToList();
        }

        public void ChangeRole(Employee employee, Employee.MemberType type)
        {
            var emp = _context.Employees.FirstOrDefault(p => p.Id == employee.Id);
            emp.type = type;
            _context.SaveChanges();
        }
        public  void AssignEmployee(Employee employee, int departmentId)
        {
            var emp =  _context.Employees.FirstOrDefault(p => p.Id == employee.Id);
            var department = _context.Departments.FirstOrDefault(p => p.DepartmentId == departmentId);
            if (emp != null & department != null)
            {
                department.Members.Add(emp);
                _context.SaveChanges();
            }
        }
    }
}
