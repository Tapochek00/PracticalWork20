using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Policy;
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
    /// Логика взаимодействия для AddService.xaml
    /// </summary>
    public partial class AddService : Window
    {
        public AddService()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            Regex regex = new Regex("[^0-9],");
            MatchCollection matches = regex.Matches(Cost.Text);
            if (ServName.Text.Length == 0) errors.AppendLine("Введите название услуги");
            if (Cost.Text.Length == 0) errors.AppendLine("Введите стоимость услуги");
            if (matches.Count > 0) errors.AppendLine("Стоимость услуги может состоять только из цифр и запятой");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (service == null)
            {
                try
                {
                    service = new Services();
                    service.ServiceName = ServName.Text;
                    service.ServiceCost = Convert.ToDouble(Cost.Text);
                    db.Services.Add(service);
                    db.SaveChanges();
                    service = null;
                    ServName.Text = "";
                    Cost.Text = "";
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
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
                    Services row = (Services)dataGrid_Clients.SelectedItems[0];
                    db.Services.Remove(row);
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

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        ClientsOrderSomeStuffEntities db = ClientsOrderSomeStuffEntities.GetContext();
        Services service;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.Services.Load();
            dataGrid_Clients.ItemsSource = db.Services.Local.ToBindingList();
        }
    }
}
