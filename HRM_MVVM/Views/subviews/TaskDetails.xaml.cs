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

namespace HRM_MVVM.Views.subviews
{
    /// <summary>
    /// Interaction logic for TaskDetails.xaml
    /// </summary>
    public partial class TaskDetails : Window
    {
        private readonly EmployeeTasks task;
        public TaskDetails(EmployeeTasks task)
        {
            this.task = task;
            InitializeComponent();
        }

        private void TaskDetails_OnLoaded(object sender, RoutedEventArgs e)
        {
            @from.Content = task.StartingPoint.ToLongDateString();
            to.Content = task.EndPoint.ToLongDateString();
            priority.Content = task.Priority_.ToString();
            details.Content = task.Details.ToString();
        }
    }
}
