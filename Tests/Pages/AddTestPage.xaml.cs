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
    /// Логика взаимодействия для AddTestPage.xaml
    /// </summary>
    public partial class AddTestPage : Page
    {
        private readonly TestsEntities db;
        public AddTestPage()
        {
            InitializeComponent();
            db = new TestsEntities();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Получаем название теста из поля ввода
                string testName = NameTest.Text.Trim();

                // Проверка на пустое имя теста
                if (string.IsNullOrEmpty(testName))
                {
                    MessageBox.Show("Введите название теста", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Создаем новый тест в базе данных
                var test = new test
                {
                    test_name = testName,
                    test_date = DateTime.Now // Пример: тест создается сегодня
                };

                db.tests.Add(test);
                db.SaveChanges(); // Сохраняем тест в БД

                // Теперь добавляем вопросы
                AddQuestionsToTest(test.test_id);

                MessageBox.Show("Тест успешно сохранен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddQuestionsToTest(int testId)
        {
            // Получаем данные для вопроса из полей ввода
            string questionText = NameQuestion.Text.Trim();
            string ans1 = Ans1.Text.Trim();
            string ans2 = Ans2.Text.Trim();
            string ans3 = Ans3.Text.Trim();
            string ans4 = Ans4.Text.Trim();
            int correctAnswer;

            // Проверка на пустые поля
            if (string.IsNullOrEmpty(questionText) || string.IsNullOrEmpty(ans1) ||
                string.IsNullOrEmpty(ans2) || string.IsNullOrEmpty(ans3) || string.IsNullOrEmpty(ans4) ||
                !int.TryParse(CorrectAnswer.Text.Trim(), out correctAnswer) || correctAnswer < 1 || correctAnswer > 4)
            {
                MessageBox.Show("Все поля должны быть заполнены и правильный ответ должен быть от 1 до 4", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Создаем новый вопрос
            var question = new question
            {
                test_id = testId,
                question_text = questionText,
                answer_1 = ans1,
                answer_2 = ans2,
                answer_3 = ans3,
                answer_4 = ans4,
                correct_answer = correctAnswer
            };

            db.questions.Add(question);
            db.SaveChanges(); // Сохраняем вопрос в БД
        }

        private void BtnAddQuestion_Click(object sender, RoutedEventArgs e)
        {
            // Получаем данные для вопроса из полей ввода
            string questionText = NameQuestion.Text.Trim();
            string ans1 = Ans1.Text.Trim();
            string ans2 = Ans2.Text.Trim();
            string ans3 = Ans3.Text.Trim();
            string ans4 = Ans4.Text.Trim();
            int correctAnswer;

            // Проверка на пустые поля
            if (string.IsNullOrEmpty(questionText) || string.IsNullOrEmpty(ans1) ||
                string.IsNullOrEmpty(ans2) || string.IsNullOrEmpty(ans3) || string.IsNullOrEmpty(ans4) ||
                !int.TryParse(CorrectAnswer.Text.Trim(), out correctAnswer) || correctAnswer < 1 || correctAnswer > 4)
            {
                MessageBox.Show("Все поля должны быть заполнены и правильный ответ должен быть от 1 до 4", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                // Добавляем вопрос в базу данных
                var question = new question
                {
                    test_id = 1, // Здесь можно указать нужный тест, если его ID уже есть, например, тест, для которого добавляются вопросы
                    question_text = questionText,
                    answer_1 = ans1,
                    answer_2 = ans2,
                    answer_3 = ans3,
                    answer_4 = ans4,
                    correct_answer = correctAnswer
                };

                db.questions.Add(question);
                db.SaveChanges(); // Сохраняем вопрос в БД

                MessageBox.Show("Вопрос успешно добавлен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                // Очищаем все поля для ввода нового вопроса
                NameQuestion.Clear();
                Ans1.Clear();
                Ans2.Clear();
                Ans3.Clear();
                Ans4.Clear();
                CorrectAnswer.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении вопроса: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
