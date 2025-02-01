using System.Windows;
using System.Windows.Controls;

namespace Tests.Pages
{
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
            FrameManager.MainFrame.Navigate(new Students());
        }

        private void BtnReports_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new Reports());
        }
    }
}
