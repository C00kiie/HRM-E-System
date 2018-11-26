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

namespace HRM_MVVM.Views.subviews
{
    /// <summary>
    /// Interaction logic for TaskDetails.xaml
    /// </summary>
    public partial class TaskDetails : Window
    {
        private readonly EmployeeTasks task;
        private readonly TasksViewModel _vm;
        public TaskDetails(EmployeeTasks task,TasksViewModel vm)
        {
            _vm = vm;
            this.task = task;
            InitializeComponent();
        }

        private void TaskDetails_OnLoaded(object sender, RoutedEventArgs e)
        {
            @from.Content = task.StartingPoint.ToLongDateString();
            to.Content = task.EndPoint.ToLongDateString();
            priority.Content = task.Priority_.ToString();
            details.Content = task.Details.ToString();
            status.Content = task.Status_.ToString();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void MarkAsUnderProgress(object sender, RoutedEventArgs e)
        {
            _vm.ChangeTaskProgress(task.TaskId,EmployeeTasks.Status.UnderProgress);
            status.Content = EmployeeTasks.Status.UnderProgress;
        }

        private void MarkAsDone(object sender, RoutedEventArgs e)
        {
            _vm.ChangeTaskProgress(task.TaskId, EmployeeTasks.Status.Done);
            status.Content = EmployeeTasks.Status.Done;
        }
    }
}
