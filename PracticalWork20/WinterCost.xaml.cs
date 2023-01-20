using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
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

namespace PracticalWork20
{
    /// <summary>
    /// Логика взаимодействия для WinterCost.xaml
    /// </summary>
    public partial class WinterCost : Window
    {
        public WinterCost()
        {
            InitializeComponent();
        }

        ClientsOrderSomeStuffEntities db = ClientsOrderSomeStuffEntities.GetContext();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var iwannakillmyself = from p in db.Orders
                                   where p.OrderDate.Month == 12 ||
                                         p.OrderDate.Month == 1 ||
                                         p.OrderDate.Month == 2
                                   group p by p.OrderDate.Month into a
                                   select new { Month = a.Key, Cost = a.Sum(s => s.ServiceCost) };
            dataGrid_Clients.ItemsSource = iwannakillmyself.ToList();
        }
    }
}
