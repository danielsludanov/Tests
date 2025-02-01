using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Tests.Pages
{
    
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
            var testtoDelete = DataGridTests.SelectedItems.Cast<question>().Select(q => q.question_id).ToList();
            if (MessageBox.Show($"Вы точно хотите удалить {testtoDelete.Count()} тестов?", "Информация", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    var TestsToDelete = db.questions.Where(u => testtoDelete.Contains(u.question_id)).ToList();
                    db.questions.RemoveRange(TestsToDelete);
                    db.SaveChanges();
                    DataGridTests.ItemsSource = db.questions.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var questionToEdit = (sender as Button).DataContext as question;

            var testToEdit = db.tests.FirstOrDefault(t => t.test_id == questionToEdit.test_id);

            NavigationService.Navigate(new AddTestPage(testToEdit, questionToEdit));
        }

    }
}
