using System.Linq;
using HRM_MVVM.Model;

namespace HRM_MVVM.ViewModels
{
    public class LoginViewModel 
    {
        public readonly HRM_DB _context;
        public LoginViewModel(HRM_DB context)
        {
            _context = context;
        }

        public enum LoginCodes
        {
            SuccessfulAndActivated,
            SuccessfulAndNotActivated,
            WrongPasswordOrUsername,
            NotFound
        }

        public Employee LoadEmployee(string email)
        {
            return _context.Employees.First(p => p.EmployeeLogin.Email == email);
        }
        public LoginCodes Login(string email, string password)
        {
            var user = _context.Logins.FirstOrDefault(p => p.Email == email);

           
            if (user != null)
            {
                if (user.Password == Functions.Password.ComputeSha256Hash(password) && user.Email == email)
                {
                    if (user.IsActivated == 1)
                    {
                        return LoginCodes.SuccessfulAndActivated;
                    }
                    else
                    {
                        return LoginCodes.SuccessfulAndNotActivated;
                    }
                }
                else
                {
                    return LoginCodes.WrongPasswordOrUsername;
                }
            }
            else
            {
                return LoginCodes.NotFound;
            }
        }


    }
}
