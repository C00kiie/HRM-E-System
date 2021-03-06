﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using HRM_MVVM.Model;
using HRM_MVVM.ViewModels;
using HRM_MVVM.Views.subviews;

namespace HRM_MVVM.Views
{
    /// <summary>
    /// Interaction logic for Tasks.xaml
    /// </summary>
    public partial class TasksView : Window
    {
        private readonly Employee _employee;
        private readonly TasksViewModel _vm;
        private Dictionary<int, EmployeeTasks> tasksDict = new Dictionary<int, EmployeeTasks>();

        private int RunMode = 0;
        // runmode is a param to specify the back button redirection, 
        // int runmode = 0 => default, don't do anything
        // int runmode = 1 => change back button to make it exist insteading of going back
        public TasksView(Employee employee, TasksViewModel vm, int runMode = 0)
        {
            RunMode = runMode;
            _vm = vm;
            _employee = employee; 
            InitializeComponent();
        }


        private void DataListLoaded(object sender, RoutedEventArgs e)
        {
            List<EmployeeTasks> tasks =  _vm.GetUserTasks(_employee.Id);
            if (tasks.Count > 0)
            {
                int i = 0;
                foreach (var task in tasks )
                {
                    tasksDict[i] = task;
                    string taskString = task.Priority_.ToString() + ": " + task.Details.ToString();
                    TasksList.Items.Add(taskString);
                    i++;
                }
            }
            else
            {
                MessageBox.Show("You have no assigned tasks");
            }

        }

        private void back(object sender, RoutedEventArgs e)
        {
            if (RunMode == 0)
            {
                this.Close();
                var view = new EmployeeView(_employee,new EmployeeViewModel(_vm._context));
                view.Show();
            }
            else
            {
                this.Close();
            }
        }

        private void TasksList_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selected_index = TasksList.SelectedIndex;
            var view = new TaskDetails(tasksDict[selected_index],_vm);
            view.Show();
        }
    }
}
