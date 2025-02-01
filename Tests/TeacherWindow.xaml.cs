using System.Windows;
using Tests.Pages;

namespace Tests
{

    public partial class TeacherWindow : Window
    {
        public bool isNav = false;
        public TeacherWindow()
        {
            InitializeComponent();
            FrameManager.MainFrame = MainFrame;
            FrameManager.MainFrame.Navigate(new MainPage());
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (isNav)
            {
                return;
            }

            if (MessageBox.Show("Вы действительно хотите выйти из приложения?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void goBackButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                MainFrame.GoBack();
            }
        }
    }
}
