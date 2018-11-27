using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using HRM_MVVM.Model;

namespace HRM_MVVM.ViewModels
{
    public class TasksViewModel
    {
        public readonly HRM_DB _context;

        public TasksViewModel(HRM_DB context)
        {
            _context = context;
        }


        public string LoadEmployeeName(int employeeId)
        {
            return _context.EmployeeInfos.First(p=>p.EmployeeInfoId == employeeId).Name;
        }
        public List<Employee> GetEmployeesByDepartment(int departmentId)
        {
            var Employees = from temp in _context.Employees
                where temp.Department.DepartmentId == departmentId
                select temp;
            return Employees.ToList();
        }
        public List<EmployeeTasks> GetDepartmentEmployeesTasks(int departmentId)
        {
            // filter by employee department, and employee role
            var listofTasks = _context.Tasks.Where(p => p.Employee.Department.DepartmentId == departmentId && p.Employee.type == Employee.MemberType.Employee).ToList();
            return listofTasks;
        }
        public List<EmployeeTasks> GetUserTasks(int employeeId)
        {
            return _context.Tasks.Where(p => p.EmployeeId == employeeId).ToList();
        }
        public async void ChangeTaskProgress(int TaskId, EmployeeTasks.Status status)
        {
            var resultsFirst = await _context.Tasks.FirstOrDefaultAsync(p => p.TaskId == TaskId);
            if (resultsFirst != null)
            {
                resultsFirst.Status_ = status;
            }

            await _context.SaveChangesAsync();

        }
        public async void AddTask(int UserId, EmployeeTasks.Priority priority,
            DateTime startTime, DateTime endTime, EmployeeTasks.Status status, string details)
        {
            var employeeTask = new EmployeeTasks()
            {
                EmployeeId =  UserId,
                Priority_  =  priority,
                Status_    =  status,
                Details    =  details,
                StartingPoint = startTime,
                EndPoint =  endTime,
            };
            _context.Tasks.Add(employeeTask);
            await _context.SaveChangesAsync();
        }
        public async void RemoveTask(int taskId)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(p => p.TaskId == taskId);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }

    }
}
