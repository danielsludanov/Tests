using System;
using System.Windows;
using System.Windows.Controls;

namespace Tests.Pages
{
    public partial class AddTestPage : Page
    {
        private readonly TestsEntities db;
        private test currentTest;
        private question currentQuestion;
        public AddTestPage(test testToEdit = null, question questionToEdit = null)
        {
            InitializeComponent();
            db = new TestsEntities();
            if (testToEdit != null)
            {
                currentTest = testToEdit;
                
                NameTest.Text = testToEdit.test_name;
            }

            if (questionToEdit != null)
            {
                currentQuestion = questionToEdit;
                
                NameQuestion.Text = questionToEdit.question_text;
                Ans1.Text = questionToEdit.answer_1;
                Ans2.Text = questionToEdit.answer_2;
                Ans3.Text = questionToEdit.answer_3;
                Ans4.Text = questionToEdit.answer_4;
                CorrectAnswer.Text = questionToEdit.correct_answer.ToString();
            }

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string testName = NameTest.Text.Trim();
                if (string.IsNullOrEmpty(testName))
                {
                    MessageBox.Show("Введите название теста", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (currentTest == null)
                {
                    
                    currentTest = new test
                    {
                        test_name = testName,
                        test_date = DateTime.Now
                    };
                    db.tests.Add(currentTest);
                }
                else
                {
                    
                    currentTest.test_name = testName;
                }

                db.SaveChanges();


                if (currentQuestion != null)
                {
                    currentQuestion.question_text = NameQuestion.Text.Trim();
                    currentQuestion.answer_1 = Ans1.Text.Trim();
                    currentQuestion.answer_2 = Ans2.Text.Trim();
                    currentQuestion.answer_3 = Ans3.Text.Trim();
                    currentQuestion.answer_4 = Ans4.Text.Trim();
                    currentQuestion.correct_answer = int.Parse(CorrectAnswer.Text.Trim());
                }
                else
                {
                    
                    currentQuestion = new question
                    {
                        test_id = currentTest.test_id,
                        question_text = NameQuestion.Text.Trim(),
                        answer_1 = Ans1.Text.Trim(),
                        answer_2 = Ans2.Text.Trim(),
                        answer_3 = Ans3.Text.Trim(),
                        answer_4 = Ans4.Text.Trim(),
                        correct_answer = int.Parse(CorrectAnswer.Text.Trim())
                    };
                    db.questions.Add(currentQuestion);
                }

                db.SaveChanges();

                MessageBox.Show("Данные успешно сохранены", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddQuestionsToTest(int testId)
        {
            
            string questionText = NameQuestion.Text.Trim();
            string ans1 = Ans1.Text.Trim();
            string ans2 = Ans2.Text.Trim();
            string ans3 = Ans3.Text.Trim();
            string ans4 = Ans4.Text.Trim();
            int correctAnswer;

            
            if (string.IsNullOrEmpty(questionText) || string.IsNullOrEmpty(ans1) ||
                string.IsNullOrEmpty(ans2) || string.IsNullOrEmpty(ans3) || string.IsNullOrEmpty(ans4) ||
                !int.TryParse(CorrectAnswer.Text.Trim(), out correctAnswer) || correctAnswer < 1 || correctAnswer > 4)
            {
                MessageBox.Show("Все поля должны быть заполнены и правильный ответ должен быть от 1 до 4", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


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
            db.SaveChanges();
        }

        private void BtnAddQuestion_Click(object sender, RoutedEventArgs e)
        {
            if (currentTest == null)
            {
                MessageBox.Show("Сначала создайте или выберите тест", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                
                AddQuestionsToTest(currentTest.test_id);

                MessageBox.Show("Вопрос успешно добавлен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                
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
