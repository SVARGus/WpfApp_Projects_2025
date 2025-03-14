using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_List_Task_HW
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TaskListBox.ItemsSource = TaskRepository.GetTasks();
        }

        private void TaskListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedTask = TaskListBox.SelectedItem as Task;
            if(selectedTask != null)
            {
                TaskPanel.DataContext = selectedTask;
                SubTaskListBox.ItemsSource = selectedTask.subTasks;
            }
            else
            {
                TaskPanel.DataContext = null;
                SubTaskListBox.ItemsSource = null;
            }
        }

        private void Button_Click_NewSubTask(object sender, RoutedEventArgs e)
        {
            AddSubTuskWindow addSubTuskWindow = new AddSubTuskWindow();
            if(addSubTuskWindow.ShowDialog() == true)
            {
                var selectedTask = TaskListBox.SelectedItem as Task;
                if(selectedTask != null)
                {
                    selectedTask.subTasks.Add(addSubTuskWindow.NewSubTask);
                }
            }
        }

        private void Button_Click_NewTask(object sender, RoutedEventArgs e)
        {
            if(DateSet != null && 
                (SetNameTask.Text != null && !String.IsNullOrEmpty(SetNameTask.Text)) && 
                (DescriptionTask.Text != null && !String.IsNullOrEmpty(DescriptionTask.Text)))
            {
                Task newTask = new Task(SetNameTask.Text, DateSet.SelectedDate.Value, DescriptionTask.Text, new ObservableCollection<SubTask>());
                TaskRepository.AddTask(newTask);
                SetNameTask.Text = string.Empty;
                DescriptionTask.Text = string.Empty;
                DateSet.SelectedDate = null;
            }
            else
            {
                MessageBox.Show("Заполните все данные");
            }
        }

        private void Button_Click_Del_Task(object sender, RoutedEventArgs e)
        {
            if(TaskListBox.SelectedIndex >= 0)
            {
                TaskRepository.DellTask(TaskListBox.SelectedIndex);
            }
        }
    }
}
