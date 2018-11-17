using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRM_MVVM.Model;

namespace HRM_MVVM.ViewModels
{
    public class LoginViewModel 
    {
        private readonly HRM_DB _context;
        public LoginViewModel(HRM_DB context)
        {
            _context = context;
        }

        // return types explanation:
        // if null it means there isn't such user
        // if false it means the user has been deactivated,
        // if true it means the user is existent/activated at the same time. 
        public async Task<bool?> Login(string email, string password)
        {
            var user = await _context.Logins.FirstAsync(p=>p.Email == email);

           
            if (user != null && user.Email == email && user.Password == password)
            {
                if (user.IsActivated == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return null;
            }
        }


    }
}
