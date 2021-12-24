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
using System.Windows.Shapes;
using WpfApp1.Modeles;
using MyLibrary;

using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для SamTest.xaml
    /// </summary>
    public partial class SamTest : Window
    {
        const int MAX_COUNT = 5;
        private RadioButton[] radioButtons;
        private Test CurrentTest;
        private DateTime StartTime;
        private DateTime EndTime;
        private int CurrentQuestionIndex;
        private Result Out;
        private bool IsActivate;
        private DBManager db;
        //Новое объявление таймера
        private DispatcherTimer timer;
        //private Timer timer;
        public SamTest(Test CurrentTest, int User_Id, DBManager db)
        {
            InitializeComponent();
            radioButtons = new RadioButton[] { answer1, answer2, answer3, answer4, answer5 };
            foreach (var i in radioButtons)
                i.Click += Check;
            this.CurrentTest = CurrentTest;
            StartTime = DateTime.Now;
            this.EndTime = StartTime;
            //На замену тому, что было про таймер
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0,0,1);
            timer.Tick += Timer_Tick;
            this.db = db;
            Out = new Result();
            //Тест доступен только для одного человека
            Out.StudentId = User_Id;
            Out.Test = CurrentTest;
            Out.StartTime = StartTime;
            CurrentQuestionIndex = -1;
            LoadQuestion();
            //Начало работы таймера
            timer.Start();
            IsActivate = false;
            Loaded += TestForm_Shown;
        }

        private void TestForm_Shown(object sender, EventArgs e)
        {
            IsActivate = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            EndTime = EndTime.AddSeconds(1);
            UpdateTimeLabel();
        }

        private void LoadQuestion()
        {
            CurrentQuestionIndex++;
            questionText.Content = CurrentTest.Questions.ElementAt(CurrentQuestionIndex).Vopros;
            foreach (var i in radioButtons)
            {
                i.Visibility=Visibility.Hidden;
            }
            int count = CurrentTest.Questions.ElementAt(CurrentQuestionIndex).Answers.Count;
            if (count > MAX_COUNT)
                throw new Exception("Число ответов не может быть больше " + MAX_COUNT.ToString() + ".");
            for (int i = 0; i < count; i++)
            {
                radioButtons[i].Content = CurrentTest.Questions.ElementAt(CurrentQuestionIndex).Answers.ElementAt(i).Title;
                radioButtons[i].Tag = CurrentTest.Questions.ElementAt(CurrentQuestionIndex).Answers.ElementAt(i).Id;
                radioButtons[i].Visibility=Visibility.Visible;
            }
            UpdateCountQuestionLabel();
        }

        private void UpdateCountQuestionLabel()
        {
            questionCountLabel.Content = "Вопрос: " + (CurrentQuestionIndex + 1).ToString() + "/" + CurrentTest.Questions.Count.ToString();
        }

        private void UpdateTimeLabel()
        {
            TimeSpan delta = EndTime - StartTime;
            timeLabel.Text = "Время: " + delta.ToString("mm\\:ss");
        }

        private void Check(object sender, EventArgs e)
        {
            if (!IsActivate)
                return;
            Pair pair = new Pair();
            pair.Result = Out;
            pair.Question = CurrentTest.Questions.ElementAt(CurrentQuestionIndex);
            pair.Answer = pair.Question.Answers.Single(i => i.Id == (int)((RadioButton)sender).Tag);
            Out.Pairs.Add(pair);
            if (CurrentQuestionIndex == CurrentTest.Questions.Count - 1)
            {
                timer.Stop();
                Out.EndTime = EndTime;
                db.AddResult(Out);
                MessageBox.Show("Тест пройден.");
                Close();
            }
            else
            {
                LoadQuestion();
            }
        }
    }
}
