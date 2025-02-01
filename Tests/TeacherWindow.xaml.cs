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
using Tests.Pages;

namespace Tests
{
    /// <summary>
    /// Логика взаимодействия для TeacherWindow.xaml
    /// </summary>
    public partial class TeacherWindow : Window
    {
        public TeacherWindow()
        {
            InitializeComponent();
            FrameManager.MainFrame = MainFrame;
        }

        private void BtnAddTest_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new AddTestPage());
        }

        private void BtnStudents_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnReports_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new Reports());
        }
    }
}
