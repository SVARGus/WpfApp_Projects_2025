using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_List_Task_HW
{
    public class Task
    {
        public Task()
        {
        }
        public Task(string title, DateTime dateTime, string description, ObservableCollection<SubTask> subTasks)
        {
            Title = title;
            DateTime = dateTime;
            Description = description;
            this.subTasks = subTasks;
        }
        public string Title { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public ObservableCollection<SubTask> subTasks { get; set; } = new ObservableCollection<SubTask>();
    }
}
