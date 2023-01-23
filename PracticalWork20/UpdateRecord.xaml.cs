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
    public partial class UpdateRecord : Window
    {
        public UpdateRecord()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Orders order = new Orders();

                order = db.Orders.Find(Data.recordId);
                orderList = db.OrderList.Find(Data.recordId);
                client = db.Clients.Find(orderList.ClientId);
                serv = db.Services.Find(order.ServiceId);

                order.OrderDate = (DateTime)orderDate.SelectedDate;
                order.ServiceId = serv.ServiceId;
                order.ServiceCost = serv.ServiceCost;
                order.PaymentMethod = paymentMethod.Text;

                Data.clientId = client.ClientId;
                Data.orderCost = serv.ServiceCost;

                db.SaveChanges();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        ClientsOrderSomeStuffEntities db = ClientsOrderSomeStuffEntities.GetContext();
        Orders order;
        OrderList orderList;
        Clients client;
        Services serv;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBoxItem comboItem;
            order = db.Orders.Find(Data.recordId);
            serv = db.Services.Find(order.ServiceId);
            orderList = db.OrderList.Find(Data.recordId);
            client = db.Clients.Find(orderList.ClientId);

            combo.Text = client.ClientSurname;

            foreach (var service in db.Services)
            {
                comboItem = new ComboBoxItem();
                comboItem.Content = service.ServiceId + " " + service.ServiceName;
                comboService.Items.Add(comboItem);
                if (service.ServiceId == serv.ServiceId) comboItem.IsSelected = true;
            }

            if (order.PaymentMethod == "наличными") cash.IsSelected = true;
            else cashnt.IsSelected = true;
            orderDate.SelectedDate = order.OrderDate;
        }
    }
}
