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
using System.Windows.Shapes;
using System.Windows.Navigation;
using MyLibrary;
using WpfApp1.Modeles;
using System.Data.Entity;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Registrazia.xaml
    /// </summary>
    public partial class Registrazia : Window
    {
        MobileContext db1;
        public Registrazia()
        {
            InitializeComponent();
            db1 = new MobileContext();
        }

        private void Button_Click_Reg(object sender, RoutedEventArgs e)
        {
            string name = Text_name.Text.Trim();
            string login = Text_login.Text.Trim(); 
            string password = Text_password.Password.Trim();
            string data = datePicker1.Text.Trim();
            string familia = Text_familia.Text.Trim();
            string email = Text_email.Text.Trim();
            //Проверка на правильность ввода
            if ((login.Length < 5)||(login.Length > 10))
            {
                //Подсказка при наведении мышкой на объект
                Text_login.ToolTip = "Логин должен представлять последовательность от 5 до 10 символов";
                Text_login.BorderBrush =Brushes.Red;
            }
            else if ((password.Length < 5)||(password.Length > 10))
            {
                Text_password.ToolTip = "Пароль должен представлять последовательность от 5 до 10 символов";
                Text_password.BorderBrush = Brushes.Red;
            }
            else if (Text_email.Name.Contains("@"))
            {
                Text_email.ToolTip = "Адрес электронной почты должен содержать @";
                Text_email.BorderBrush = Brushes.Red;
            }
            else
            {
                //На случай, если заполнено все верно, прозрачный фон у всех полей
                Text_login.ToolTip = "";
                Text_login.BorderBrush = Brushes.Black;
                Text_name.ToolTip = "";
                Text_name.BorderBrush = Brushes.Black;
                Text_password.ToolTip = "";
                Text_password.BorderBrush = Brushes.Black;
                //Всплывающее окно
                MessageBox.Show("Регистрация прошла успешно");
                //Сам процесс регистрации
                Student students = new Student(name, familia, login, password, data,email);
                db1.Students.Add(students);
                db1.SaveChanges();
                //Если пользователь зарегистрировался, его необходимо перенаправить на страницу входа
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Hide();
            }
        }
    }
}
