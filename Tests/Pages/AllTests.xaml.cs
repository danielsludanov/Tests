﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tests.Pages
{
    /// <summary>
    /// Логика взаимодействия для AllTests.xaml
    /// </summary>
    
    public partial class AllTests : Page
    {
        private readonly TestsEntities db;
        public AllTests()
        {
            InitializeComponent();
            db = new TestsEntities();
            DataGridTests.ItemsSource = db.questions.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new AddTestPage());
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
