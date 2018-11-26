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
        private  readonly  Employee _employee;
        private readonly EmployeeViewModel _vm;
        public EmployeeView(Employee employee, EmployeeViewModel vm)
        {
            _employee = employee;
            _vm = vm;
            InitializeComponent();
        }

        private void TasksView(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var view = new TasksView(_employee,new TasksViewModel(_vm._context));
            view.Show();
        }

        private void TaskManagement(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var view = new ManageTasks(_employee, new TasksViewModel(_vm._context));
            view.Show();
        }
    }
}
