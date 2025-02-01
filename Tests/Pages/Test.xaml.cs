﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Tests;

namespace Tests.Pages
{
    public partial class Test : Page
    {

        private readonly TestsEntities db;
        int CurrentUserID;
        int CurrentTestID;
        int CurrentQuestionID;
        double RightAnswer;
        int StudentMark;
        List<question> CurrentQuestions;
        public Test()
        {
            InitializeComponent();
            db = new TestsEntities();
            CurrentUserID = ((App)Application.Current).CurrentUserID;

            var user = db.students.FirstOrDefault(u => u.user_id == CurrentUserID);

            LoadTests();
        }
        private void LoadTests()
        {
            var tests = db.tests.ToList();
            TypeOfTest_Box.ItemsSource = tests;
            TypeOfTest_Box.DisplayMemberPath = "test_name";
            TypeOfTest_Box.SelectedValuePath = "test_id";
        }

        private RadioButton GetAnswer()
        {
            if (Answer1_Btn.IsChecked == true) return Answer1_Btn;
            if (Answer2_Btn.IsChecked == true) return Answer2_Btn;
            if (Answer3_Btn.IsChecked == true) return Answer3_Btn;
            if (Answer4_Btn.IsChecked == true) return Answer4_Btn;
            return null;
        }

        private void ShowQuestion(question question)
        {
            Question1_Box.Text = question.question_text;
            Answer1_Btn.Content = question.answer_1;
            Answer2_Btn.Content = question.answer_2;
            Answer3_Btn.Content = question.answer_3;
            Answer4_Btn.Content = question.answer_4;
        }

        private void StartTest_Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedAnswer = GetAnswer();

                if (selectedAnswer != null && (bool)selectedAnswer.Tag)
                {
                    RightAnswer++;
                }

                if (TypeOfTest_Box.SelectedValue != null)
                {
                    CurrentTestID = (int)TypeOfTest_Box.SelectedValue;
                    SP_Start.Visibility =  Visibility.Collapsed;
                    SP_Test.Visibility = Visibility.Visible;

                    var test = db.tests.FirstOrDefault(u => u.test_id == CurrentTestID);

                    if (test != null)
                    {
                        CurrentQuestions = test.questions.ToList();
                        if (CurrentQuestions.Count > 0)
                        {
                            CurrentQuestionID = 0;
                            ShowQuestion(CurrentQuestions[CurrentQuestionID]);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Выберите тест!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }

}