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
        private readonly HRM_DB _context;

        public EmployeeViewModel(HRM_DB context)
        {
            _context = context;
        }
       
       
    }
}
