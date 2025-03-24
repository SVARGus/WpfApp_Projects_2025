﻿using ResumeEditor.Models;
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

namespace WPF_Examen_21_03_2025.Views
{
    /// <summary>
    /// Логика взаимодействия для ResumeDateEntryThree.xaml
    /// </summary>
    public partial class ResumeDateEntryThree : Window
    {
        UserWorker worker = new UserWorker();
        public ResumeDateEntryThree(UserWorker userWorker)
        {
            worker = userWorker;
            this.DataContext = worker;
            InitializeComponent();
        }
        private void Button_ClickBack(object sender, RoutedEventArgs e)
        {
            ResumeDateEntryTwo resumeDateEntryTwo = new ResumeDateEntryTwo(worker);
            resumeDateEntryTwo.Show();
            this.Close();
        }

        private void Button_ClickLater(object sender, RoutedEventArgs e)
        {
            ResumeDateEntryFour resumeDateEntryFour = new ResumeDateEntryFour(worker);
            resumeDateEntryFour.Show();
            this.Close();
        }
    }
}
