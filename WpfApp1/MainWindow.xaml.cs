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
        // MobileContext db;
        public MainWindow()
        {
            InitializeComponent();
           // db = new MobileContext();
            //db.Vopros.Load(); // загружаем данные
            //phonesGrid.ItemsSource = db.Vopros.Local.ToBindingList(); // устанавливаем привязку к кэшу

            this.Closing += MainWindow_Closing;
        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //db.Dispose();
        }
        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            //db.SaveChanges();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (phonesGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < phonesGrid.SelectedItems.Count; i++)
                {
                    Vopros phone = phonesGrid.SelectedItems[i] as Vopros;
                    if (phone != null)
                    {
                        //db.Vopros.Remove(phone);
                    }
                }
            }
            //db.SaveChanges();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Открытие формы Вы действительно хотите выйти -> да, выход
            //Организовать выход из приложения по нажатию этой кнопки
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //Добавление теста
            Dobavlenie_testa dobavlenie_Testa = new Dobavlenie_testa();
            dobavlenie_Testa.Show();
        }

        private void Registr(object sender, RoutedEventArgs e)
        {
            //Открытие формы регистрации
            Registrazia registrazia = new Registrazia();
            registrazia.Show();
        }
    }
}
