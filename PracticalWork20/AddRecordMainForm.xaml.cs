using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для AddRecordMainForm.xaml
    /// </summary>
    public partial class AddRecordMainForm : Window
    {
        public AddRecordMainForm()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            /*try
            {*/
                Orders order = new Orders();
                //OrderList orderList = new OrderList();

                StringBuilder errors = new StringBuilder();
                if (combo.Text.Length == 0)
                    errors.AppendLine("Выберите фамилию");
                if (comboService.Text.Length == 0)
                    errors.AppendLine("Выберите услугу");
                if (paymentMethod.Text.Length == 0) errors.AppendLine("Выберите форму оплаты");
                if (orderDate.Text.Length == 0) errors.AppendLine("Выберите дату");

                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString());
                    return;
                }

                // Поиск клиента по фамилии
                string[] findText = combo.Text.Split(' ');
                Clients client = db.Clients.Find(int.Parse(findText[0]));

                // Поиск услуги по названию
                string[] findService = comboService.Text.Split(' ');
                Services service = db.Services.Find(int.Parse(findService[0]));

                order.OrderDate = orderDate.DisplayDate;
                order.ServiceId = service.ServiceId;
                order.ServiceCost = service.ServiceCost;
                order.PaymentMethod = paymentMethod.Text;



                /*Data.clientId = client.ClientId;
                Data.clientSurname = client.ClientSurname;
                Data.clientPhone = client.ClientPhone;
                Data.orderCost = service.ServiceCost;
                Data.serviceName = service.ServiceName;
                Data.orderDate = orderDate.DisplayDate;*/

                /*db.Database.ExecuteSqlCommand("INSERT INTO Orders(OrderDate, ServiceId, ServiceCost, PaymentMethod)" +
                    $" VALUES ('{orderDate.DisplayDate}', {service.ServiceId}, {service.ServiceCost}, '{paymentMethod.Text}')");*/
                db.Orders.Add(order);
                db.SaveChanges();
                Close();
            /*}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        ClientsOrderSomeStuffEntities db = ClientsOrderSomeStuffEntities.GetContext();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {            
            ComboBoxItem comboItem;

            foreach(var client in db.Clients)
            {
                comboItem = new ComboBoxItem();
                comboItem.Content = client.ClientId + " " + client.ClientSurname;
                combo.Items.Add(comboItem);
            }

            foreach (var service in db.Services)
            {
                comboItem = new ComboBoxItem();
                comboItem.Content = service.ServiceId + " " + service.ServiceName;
                comboService.Items.Add(comboItem);
            }

        }
    }
}
