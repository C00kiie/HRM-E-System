using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<List<EmployeeTasks>> TasksByUser(int EmployeeId)
        {
            return await Task.Run(() => _context.Tasks.Where(p => p.EmployeeId == EmployeeId).ToListAsync());
        }
        public async void TaskProgress(int TaskId, EmployeeTasks.Status status)
        {
            var resultsFirst = _context.Tasks.First(p => p.TaskId == TaskId);
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
            var task = _context.Tasks.First(p => p.TaskId == taskId);
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }

    }
}
