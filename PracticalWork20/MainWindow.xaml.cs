using System;
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
            db.OrderList.Load();
            var shit = from p in db.OrderList
                       join pain in db.Orders on p.OrderId equals pain.OrderId
                       join pain2 in db.Services on pain.ServiceId equals pain2.ServiceId
                       join pain3 in db.Clients on p.ClientId equals pain3.ClientId
                       select new 
                       { 
                           Id = p.OrderId,
                           Surname = pain3.ClientSurname,
                           Phone = pain3.ClientPhone,
                           SName = pain2.ServiceName,
                           Cost = p.OrderCost,
                           Date = pain.OrderDate
                       };
            DataGrid1.ItemsSource = shit.ToList();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddRecord add = new AddRecord();
            add.Owner = this;
            add.ShowDialog();
        }

        private void View_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FindAndDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void About_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
