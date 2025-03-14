using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_List_Task_HW
{
    public static class TaskRepository
    {
        private static ObservableCollection<Task> tasks = new ObservableCollection<Task>();
        public static ObservableCollection<Task> GetTasks()
        {
            if(tasks.Count == 0)
            {
                SubTask subTask = new SubTask("Сделать ДЗ №1", true);
                SubTask subTask1 = new SubTask("Сделать ДЗ №2", false);
                SubTask subTask2 = new SubTask("Сделать ДЗ №3", false);
                ObservableCollection<SubTask> subTasks1 = new ObservableCollection<SubTask> { subTask, subTask1, subTask2 };
                subTask = new SubTask("Сделать ДЗ №1", true);
                subTask1 = new SubTask("Сделать ДЗ №2", false);
                subTask2 = new SubTask("Сделать ДЗ №3", false);
                ObservableCollection<SubTask> subTasks2 = new ObservableCollection<SubTask> { subTask, subTask1, subTask2 };
                tasks.Add(
                    new Task("Выполнить все ДЗ", DateTime.Now, "Мне нужно сдать все дз", subTasks1)
                    );
                tasks.Add(
                    new Task("Выполнить все ДЗ WPF", DateTime.Now, "Мне нужно сдать все дз WPF", subTasks2)
                    );
            }
            return tasks;
        }
        public static void AddTask(Task task)
        {
            tasks.Add(task);
        }
        public static void DellTask(int index)
        {
            tasks.RemoveAt(index);
        }
    }
}
