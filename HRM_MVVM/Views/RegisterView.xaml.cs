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
    /// MemberTypeEnum type = type;
    /// int departmentId = 0
    /// </summary>
    public partial class RegisterView : Window
    {
        private readonly ViewModels.RegisterViewModel _vm;

        private int RunMode = 0;
        // runmode is a param to specify the back button redirection, 
        // int runmode = 0 => default, don't do anything
        // int runmode = 1 => change back button to make it exist insteading of going back
        public RegisterView(ViewModels.RegisterViewModel vbm, int runMode = 0)
        {
            RunMode = runMode;
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
           
            
            // experience
            string selectedExperience = experienceDropList.SelectedItem.ToString();
            Employee.Experience_ experience = (Employee.Experience_) Enum.Parse(typeof(Employee.Experience_),selectedExperience);
            // name
            var name = Name.Text.Trim();
            // birthdate
            DateTime birthdate = this.birthdate.SelectedDate.Value;
            // joined since
            DateTime joinedSince =  dateofjoining.SelectedDate.Value;
            // email,
            
            var passPhrase = Functions.Password.ComputeSha256Hash(this.password.Text.Trim());

            var departmentId = DepartmentsDroplist.SelectedIndex;
            var emailParam = this.email.Text.Trim();

            if (departmentRoleList.SelectedItem != null)
            {
                Employee.MemberType type = (Employee.MemberType)Enum.Parse(typeof(Employee.MemberType),
                    departmentRoleList.SelectedItem.ToString());
                try
                {
                    var progress = _vm.AddEmployee(name, birthdate, joinedSince, passPhrase, emailParam, experience, 1, type, departmentId);
                    MessageBox.Show(progress);
                }
                catch (Exception exception)
                {
                    // extra potato code, sorry Allah
                    MessageBox.Show("All fields are required");
                    MessageBox.Show(exception.ToString());
                }
            }
            else
            {
                MessageBox.Show("Select role");
            }
        }


        private void back(object sender, RoutedEventArgs e)
        {
            if (this.RunMode == 0)
            {
                this.Hide();
                var view = new MainWindow();
                view.Show();
            }
            else
            {
                this.Hide();
            }
        }

        private void rolesLoaded(object sender, RoutedEventArgs e)
        {
            var memberTypes = Enum
                .GetValues(typeof(Employee.MemberType))
                .Cast<Employee.MemberType>();
            foreach (var item in memberTypes)
            {
                departmentRoleList.Items.Add(item);
            }
        }
    }
}
