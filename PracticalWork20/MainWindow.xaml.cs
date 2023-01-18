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
    }
}
