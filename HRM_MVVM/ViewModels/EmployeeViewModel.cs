using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HRM_MVVM.Model;

namespace HRM_MVVM.ViewModels
{
    public class EmployeeViewModel
    {
        public readonly HRM_DB _context;

        public  bool ViewUsersVisBool { get; set;}
        public EmployeeViewModel(HRM_DB context)
        {
            _context = context;
        }
       
       
    }
}
