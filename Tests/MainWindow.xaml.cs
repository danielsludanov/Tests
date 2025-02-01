using System.Windows;
using Tests.Pages;

namespace Tests
{

    public partial class MainWindow : Window
    {
        private readonly int CurrentUserID;
        public bool isNav = false;
        public MainWindow()
        {
            InitializeComponent();
            CurrentUserID = ((App)Application.Current).CurrentUserID;

            FrameManager.MainFrame  = MainFrame;
            FrameManager.MainFrame.Navigate(new Test());
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (isNav)
            {
                return;
            }
            
            if(MessageBox.Show("Вы действительно хотите выйти из приложения?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
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
