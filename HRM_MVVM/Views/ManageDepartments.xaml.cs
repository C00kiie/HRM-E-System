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
    /// Interaction logic for ManageDepartments.xaml
    /// </summary>
    ///
    
    public partial class ManageDepartments : Window
    {
        private readonly Employee _employee;
        private readonly DepartmentViewModel _vm;
        private readonly  Dictionary<int, Department> Departments_list = new Dictionary<int, Department>();
        public ManageDepartments(Employee employee, DepartmentViewModel vm)
        {
            _vm = vm;
            _employee = employee;
            InitializeComponent();
        }


        private void back(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var view = new EmployeeView(_employee,new EmployeeViewModel(_vm._context));
            view.Show();
        }

        private void ViewDepartmentEmployees(object sender, RoutedEventArgs e)
        {
            var index = department_list_ui.SelectedIndex;
            if (index != -1)
            {
                var view = new ManageEmployeesView(_employee,new ViewEmployeesViewModel(_vm._context),1);
                view.Show();
            }
        }

        private void departmentList_loaded(object sender, RoutedEventArgs e)
        {
            var departments = _vm.GetDepartments();
            int i = 0;
            foreach (var department in departments)
            {
                Departments_list[i] = department;
                department_list_ui.Items.Add(department.DepartmentName);
                i++;
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.nameLabel.Visibility = Visibility.Visible;
            this.nametextbox.Visibility = Visibility.Visible;
            this.ChangeNameButton.Visibility = Visibility.Visible;
        }

        private void ChangeNameButton_OnClick(object sender, RoutedEventArgs e)
        {
            var index = department_list_ui.SelectedIndex;
            if (index != -1)
            {
                if (!string.IsNullOrWhiteSpace(this.nametextbox.Text))
                {
                    
                    Department department = Departments_list[index];
                    var result =  _vm.ChangeName(department, this.nametextbox.Text.Trim());
                    department_list_ui.Items.Remove(department_list_ui.SelectedItem);
                    department_list_ui.Items.Add(result.DepartmentName);
                    MessageBox.Show("Done");

                }
            }
            
        }
    }
}
