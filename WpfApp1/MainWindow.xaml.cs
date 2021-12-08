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
using System.Data.Entity;
using WpfApp1.Modeles;
using MyLibrary;
namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void Registr(object sender, RoutedEventArgs e)
        {
            //Открытие формы регистрации
            Registrazia registrazia = new Registrazia();
            registrazia.Show();
        }
        private void Voyti(object sender, RoutedEventArgs e)
        {
            string login = Text_login.Text.Trim();
            string password = Text_password.Password.Trim();
            //Проверка на правильность ввода
            if ((login.Length < 5) || (login.Length > 10))
            {
                //Подсказка при наведении мышкой на объект
                Text_login.ToolTip = "Логин должен представлять последовательность от 5 до 10 символов";
                Text_login.BorderBrush = Brushes.Red;
            }
            else if ((password.Length < 5) || (password.Length > 10))
            {
                Text_password.ToolTip = "Пароль должен представлять последовательность от 5 до 10 символов";
                Text_password.BorderBrush = Brushes.Red;
            }
            
            else
            {
                //На случай, если заполнено все верно, прозрачный фон у всех полей
                Text_login.ToolTip = "";
                Text_login.BorderBrush = Brushes.Black;
                Text_password.ToolTip = "";
                Text_password.BorderBrush = Brushes.Black;
                //Процесс авторизации
                Student autStudent = null;
                using (MobileContext db1 = new MobileContext())
                {
                    //Обращение к базе данных, поиск нужной строки
                    //Обращение к методу, которые вернет либо найденную строчку либо значение по умолчанию
                    autStudent = db1.Students.Where(b=>b.Login_student==login&&b.Password_student==password)
                        .FirstOrDefault();
                }
                //Смогли ли найти пользователя? Проверка
                if (autStudent != null)
                    //Всплывающее окно
                    MessageBox.Show("Вход выполнен");
                else
                    MessageBox.Show("Такого пользователя не существует");
            }
        }
    }
}
