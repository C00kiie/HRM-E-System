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
        private readonly HRM_DB _context;

        public TasksViewModel(HRM_DB context)
        {
            _context = context;
        }

        public async Task<List<Tasks>> TasksByUser(int UserId)
        {
            return await Task.Run(() => _context.Tasks.Where(p => p.Id == UserId).ToListAsync());
        }

        public async void TaskProgress(int TaskId, Tasks.Status status)
        {
            var resultsFirst = _context.Tasks.First(p => p.TaskId == TaskId);
            if (resultsFirst != null)
            {
                resultsFirst.status_ = status;
            }

            await _context.SaveChangesAsync();

        }
        // here the return type represents
        public async void AddTask(int UserId, Tasks.Priority priority,
            DateTime startTime, DateTime endTime, Tasks.Status status, string details)
        {
            var Task = new Tasks()
            {
                Id =  UserId,
                Priority_ =  priority,
                status_ =  status,
                details =  details,
                StartingPoint = startTime,
                EndPoint =  endTime,
            };
            _context.Tasks.Add(Task);
            await _context.SaveChangesAsync();
        }

        public async void RemoveTask(int TaskId)
        {
            var task = _context.Tasks.First(p => p.TaskId == TaskId);
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }

    }
}
