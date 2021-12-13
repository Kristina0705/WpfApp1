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
using WpfApp1.Modeles;
using MyLibrary;
namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Lichny_kabinet.xaml
    /// </summary>
    public partial class Lichny_kabinet : Window
    {
        public Lichny_kabinet()
        {
            InitializeComponent();
            MobileContext db1 = new MobileContext();
            //Получение данных в лист из БД
            List<Student> students = db1.Students.ToList();
            //По итогу выведутся все пользователи
            ListOfUsers.ItemsSource = students;

            //Вывод приветствия
            var user= App.Current.Resources["User"];
            Student autStudent1 = null;
            using (db1)
            {
                //Обращение к базе данных, поиск нужной строки
                //Обращение к методу, которые вернет либо найденную строчку либо значение по умолчанию
                autStudent1 = db1.Students.Where(b => b.Login_student == user)
                    .FirstOrDefault();
            }
            //User1.Content = "Здравствуйте, "+App.Current.Resources["User"];
            User1.Content = "Здравствуйте, " + autStudent1.Name_student;
        }

        private void ProytiTest(object sender, RoutedEventArgs e)
        {
            ProytiTest proytiTest = new ProytiTest();
            proytiTest.Show();
            Hide();

        }
    }
}
