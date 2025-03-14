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

namespace Wpf_List_Task_HW
{
    /// <summary>
    /// Логика взаимодействия для AddSubTuskWindow.xaml
    /// </summary>
    public partial class AddSubTuskWindow : Window
    {
        public SubTask NewSubTask { get; private set; }
        public AddSubTuskWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(SubTaskName.Text != null && !String.IsNullOrEmpty(SubTaskName.Text))
            {
                NewSubTask = new SubTask(SubTaskName.Text, false);
                DialogResult = true;
            }
            else
            {
                DialogResult = false;
            }
            Close();
        }
    }
}
