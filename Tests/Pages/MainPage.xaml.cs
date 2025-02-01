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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tests.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnAddTest_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new AllTests());
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
