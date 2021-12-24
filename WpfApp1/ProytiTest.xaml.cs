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
    /// Логика взаимодействия для ProytiTest.xaml
    /// </summary>
    public partial class ProytiTest : Window
    {
        DBManager db;
        public ProytiTest()
        {
            InitializeComponent();
            //MobileContext db1 = new MobileContext();
            db = new DBManager();
            //Получение данных в лист из БД
            //List<Test> tests = db1.Tests.ToList();
            //По итогу выведутся все пользователи
            foreach (var i in db.GetTests())
                ListOfUsers.Items.Add(i);
            //ListOfUsers.ItemsSource = tests;
        }
        private void SamTest(object sender, RoutedEventArgs e)
        {
            SamTest test = new SamTest((Test)ListOfUsers.SelectedItem, 4, db);
            test.Show();
            //SamTest samTest = new SamTest();
            //samTest.Show();
            //Hide();
        }
        
    }
}
