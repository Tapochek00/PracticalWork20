using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace PracticalWork20
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

        ClientsOrderSomeStuffEntities db = ClientsOrderSomeStuffEntities.GetContext();
        private void mainWin_Loaded(object sender, RoutedEventArgs e)
        {
            db.View_1.Load();
            DataGrid1.ItemsSource = db.View_1.Local.ToBindingList();
        }

        private void ManageServices_Click(object sender, RoutedEventArgs e)
        {
            AddService add = new AddService();
            add.Owner = this;
            add.ShowDialog();
        }

        private void ManageClients_Click(object sender, RoutedEventArgs e)
        {
            AddClient add = new AddClient();
            add.Owner = this;
            add.ShowDialog();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OrdersCost_Click(object sender, RoutedEventArgs e)
        {
            CostSumForEachClient win = new CostSumForEachClient();
            win.Owner = this;
            win.ShowDialog();
        }

        private void CityClients_Click(object sender, RoutedEventArgs e)
        {
            ClientsInfo win = new ClientsInfo();
            win.Owner = this;
            win.ShowDialog();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            Search search = new Search();
            search.Owner = this;
            search.ShowDialog();

            for (int i = 0; i < DataGrid1.Items.Count; i++)
            {
                var row = (View_1)DataGrid1.Items[i];
                string find = row.ClientSurname;
                try
                {
                    if (find != null && find.Contains(Data.searchText))
                    {
                        object item = DataGrid1.Items[i];
                        DataGrid1.SelectedItem = item;
                        DataGrid1.ScrollIntoView(item);
                        DataGrid1.Focus();
                        break;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void AddRecord_Click(object sender, RoutedEventArgs e)
        {
            AddRecordMainForm add = new AddRecordMainForm();
            add.Owner = this;
            add.ShowDialog();

            OrderList order = new OrderList();

            int id = (from p in db.Orders select p.OrderId).ToList().Last();

            order.OrderId = id;
            order.ClientId = Data.clientId;
            order.OrderCost = Data.orderCost;

            try
            {
                db.OrderList.Add(order);
                db.SaveChanges();
                db.View_1.Load();
                DataGrid1.ItemsSource = db.View_1.Local.ToBindingList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}

        private void PaymentMethodNumber_Click(object sender, RoutedEventArgs e)
        {
            PaymentMethodNumber pay = new PaymentMethodNumber();
            pay.Owner = this;
            pay.ShowDialog();
        }

        private void WinterCost_Click(object sender, RoutedEventArgs e)
        {
            WinterCost win = new WinterCost();
            win.Owner = this;
            win.ShowDialog();
        }

        private void IncreaseCost_Click(object sender, RoutedEventArgs e)
        {
            db.Database.ExecuteSqlCommand("UPDATE Services SET ServiceCost = ServiceCost + ServiceCost/100*0.15");
        }

        private void Quantity_Click(object sender, RoutedEventArgs e)
        {
            QuantityOfOrders a = new QuantityOfOrders();
            a.Owner = this;
            a.ShowDialog();
        }

        private void LessThanAvg_Click(object sender, RoutedEventArgs e)
        {
            LessThanAvg less = new LessThanAvg();
            less.Owner = this;
            less.ShowDialog();
        }

        private void UpdateRecord_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = DataGrid1.SelectedIndex;
            if (indexRow != -1)
            {
                View_1 row = (View_1)DataGrid1.Items[indexRow];
                Data.recordId = row.OrderId;
                UpdateRecord win = new UpdateRecord();
                win.Owner = this;
                win.ShowDialog();

                OrderList order = db.OrderList.Find(row.OrderId);

                order.OrderCost = Data.orderCost;
                db.SaveChanges();
                db.View_1.Load();
                DataGrid1.ItemsSource = db.View_1.Local.ToBindingList();
            }
        }

        private void DeleteRecord_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = DataGrid1.SelectedIndex;
            if (indexRow != -1)
            {
                View_1 row = (View_1)DataGrid1.Items[indexRow];

                OrderList orderList = db.OrderList.Find(row.OrderId);
                Orders order = db.Orders.Find(row.OrderId);
                db.OrderList.Remove(orderList);
                db.Orders.Remove(order);
                
                db.SaveChanges();
                db.View_1.Load();
                DataGrid1.ItemsSource = db.View_1.Local.ToBindingList();
            }
        }
    }
}
