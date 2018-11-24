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
            bool hrcheck = permHR.IsChecked == true;
            bool employeeCheck = permEmployee.IsChecked == true;
            if (employeeCheck)
            {
                perms.Add(Employee.Permissions.Employee);
            }else if(adminCheck)
            {
                perms.Add(Employee.Permissions.Admin);
            }else if (hrcheck)
            {
                perms.Add(Employee.Permissions.HR);
            }
            
            // experience
            string selectedExperience = experienceDropList.SelectedItem.ToString();
            Employee.Experience_ experience = (Employee.Experience_) Enum.Parse(typeof(Employee.Experience_),selectedExperience);
            // name
            var name = Name.Text.Trim();
            // birthdate
            DateTime birthdate = this.birthdate.DisplayDate;
            // joined since
            DateTime joinedSince =  dateofjoining.DisplayDate;
            // email,
            var emailParam = this.email.Text.Trim();

            var passPhrase = Functions.Password.ComputeSha256Hash(this.password.Text.Trim());
            var departmentId = DepartmentsDroplist.SelectedIndex;

            try
            {
                var progress = _vm.AddEmployee(name, birthdate, joinedSince, passPhrase, emailParam, experience, perms, 1, departmentId);
                MessageBox.Show(progress);
            }
            catch (Exception exception)
            {
                // extra potato code, sorry Allah
                MessageBox.Show("All fields are required");
                throw;
            }
        }


        private void back(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var view = new MainWindow();
            view.Show();
        }
    }
}
