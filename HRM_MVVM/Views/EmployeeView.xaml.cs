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
using HRM_MVVM.ViewModels;

namespace HRM_MVVM.Views
{
    /// <summary>
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : Window
    {
        private readonly EmployeeViewModel _vm;
        private readonly login _currentUser;
        private Employee.Permission_ _permission;


        private void init()
        {
            DataContext = _vm;
            var permissions = _vm._context.Employees.First(temp => temp.Id == _currentUser.Id);
            this._permission = permissions.Permission;
        }

        private void ViewUsersPerm()
        {
            if (this._permission == Employee.Permission_.Employee)
            {
                _vm.ViewUsersVisBool = false;
            }
            else
            {
                _vm.ViewUsersVisBool = true;
            }

        }
        public EmployeeView(EmployeeViewModel employeeViewModel, login currentUser)
        {
            this._vm = employeeViewModel;
            this._currentUser = currentUser;
            InitializeComponent();
            init();
           
           
        }


        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            var view = new Views.ViewUsersView(new ViewEmployeesViewModel(_vm._context));
        }
    }
}
