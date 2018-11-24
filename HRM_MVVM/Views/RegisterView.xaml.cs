using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HRM_MVVM.Model;

namespace HRM_MVVM.Views
{
    /// <summary>
    /// string name,
    /// DateTime birthDateTime,
    /// DateTime joinedSinceDateTime,
    /// string password,
    /// string email,
    /// Employee.Experience_ experience,
    /// List&lt;Employee.Permissions&gt; perms,
    /// int isActivated,
    /// int departmentId = 0
    /// </summary>
    public partial class RegisterView : Window
    {
        private readonly ViewModels.RegisterViewModel _vm;
        public RegisterView(ViewModels.RegisterViewModel vbm)
        {
            _vm = vbm;
            InitializeComponent();
        }

        private void Department_OnLoaded(object sender, RoutedEventArgs e)
        {
           
            var deparments =  _vm.LoadDepartments();
            foreach (var department in deparments)
            {
                DepartmentsDroplist.Items.Add(department.DepartmentName);
            }
        }


        private void GetExperienceList(object sender, RoutedEventArgs e)
        {
            var experienceList = Enum
                .GetValues(typeof(Employee.Experience_))
                .Cast<Employee.Experience_>();
            foreach (var item in experienceList)
            {
                experienceDropList.Items.Add(item);
            }
        }

       
        private void RegisterButton(object sender, RoutedEventArgs e)
        {
            // setting up perms
            // I am sorry Allah for this potato UI code ;-;
            List<Employee.Permissions> perms = new List<Employee.Permissions>();
            bool adminCheck = permAdmin.IsChecked == true;
            bool HRCheck = permHR.IsChecked == true;
            bool EmployeeCheck = permEmployee.IsChecked == true;
            if (EmployeeCheck)
            {
                perms.Add(Employee.Permissions.Employee);
            }else if(adminCheck)
            {
                perms.Add(Employee.Permissions.Admin);
            }else if (HRCheck)
            {
                perms.Add(Employee.Permissions.HR);
            }
            // experience
            string selectedExperience = experienceDropList.SelectedItem.ToString();
            Employee.Experience_ experience = (Employee.Experience_) Enum.Parse(typeof(Employee.Experience_),selectedExperience);
            // name
            var name = Name.Text.Trim();
            // birthdate
            var birthdate = this.birthdate.DisplayDate;
            // joined since
            DateTime joinedSince =  dateofjoining.DisplayDate;
            // email,
            var emailParam = this.email.Text.Trim();

            var passPhrase = Functions.Password.ComputeSha256Hash(this.password.Text.Trim());
            var departmentId = DepartmentsDroplist.SelectedIndex;

           
           _vm.AddEmployee(name,birthdate,joinedSince,passPhrase,emailParam, experience,perms,1,departmentId);
            
            
        }


        
    }
}
