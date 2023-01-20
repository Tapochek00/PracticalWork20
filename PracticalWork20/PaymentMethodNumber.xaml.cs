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
using System.Windows.Shapes;

namespace PracticalWork20
{
    /// <summary>
    /// Логика взаимодействия для PaymentMethodNumber.xaml
    /// </summary>
    public partial class PaymentMethodNumber : Window
    {
        public PaymentMethodNumber()
        {
            InitializeComponent();
        }

        ClientsOrderSomeStuffEntities db = ClientsOrderSomeStuffEntities.GetContext();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.View_4.Load();
            dataGrid_Clients.ItemsSource = db.View_4.Local.ToBindingList();
        }
    }
}
