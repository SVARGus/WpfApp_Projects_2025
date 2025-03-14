using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_List_Task_HW
{
    public class SubTask
    {
        public SubTask()
        {
        }
        public SubTask(string name, bool isRady)
        {
            Name = name;
            IsRady = isRady;
        }
        public string Name { set; get; }
        public bool IsRady { get; set; }
    }
}
