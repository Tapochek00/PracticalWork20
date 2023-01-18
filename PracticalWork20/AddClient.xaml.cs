using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PracticalWork20
{
    /// <summary>
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        public AddClient()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            Regex regex = new Regex("[^0-9]");
            MatchCollection matches = regex.Matches(Phone.Text);
            if (Surname.Text.Length == 0) errors.AppendLine("Введите фамилию");
            if (Phone.Text.Length == 0) errors.AppendLine("Введите номер телефона");
            if (matches.Count > 0) errors.AppendLine("Номер телефона может состоять только из цифр");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (client == null)
            {
                client = new Clients();
                client.ClientSurname = Surname.Text;
                client.ClientPhone = Phone.Text;
                if (Address.Text.Length != 0) client.ClientAddress = Address.Text;
                db.Clients.Add(client);
                db.SaveChanges();
                client = null;
                Surname.Text = "";
                Address.Text = "";
                Phone.Text = "";
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        ClientsOrderSomeStuffEntities db = ClientsOrderSomeStuffEntities.GetContext();
        Clients client;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.Clients.Load();
            dataGrid_Clients.ItemsSource = db.Clients.Local.ToBindingList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Clients row = (Clients)dataGrid_Clients.SelectedItems[0];
                    db.Clients.Remove(row);
                    db.SaveChanges();
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Выберите запись");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
