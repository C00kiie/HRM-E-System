using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using HRM_MVVM.Model;
using System.Linq;
using System.Threading.Tasks;

namespace HRM_MVVM.ViewModels
{
    public class ActivityBoardViewModel
    {

        private readonly HRM_DB _context;
        public ActivityBoardViewModel(HRM_DB context)
        {
            _context = context;
        }

        public async void AddActivity(string title, string content)
        {
            var activity = new Activity()
            {
                Title = title,
                Content = content
            };
            _context.Activities.Add(activity);
            await _context.SaveChangesAsync();
        }

        public async void RemoveActivity(int id)
        {
            var activity = await _context.Activities.FindAsync(id);
            if (activity != null)
            {
                _context.Activities.Remove(activity);
            }
        }
        public async Task<List<Activity>> GetActivities()
        {
            var activities =  await _context.Activities.ToListAsync();
            return activities;
        }

        public async Task<List<Activity>> GetActivityByUser(int userId)
        {
            var ActivitiesList = await _context.Activities.Where(p=>p.ActivityId == userId).ToListAsync();
            return ActivitiesList;
        }
    }
}