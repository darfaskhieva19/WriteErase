using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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

namespace WriteErase
{
    /// <summary>
    /// Логика взаимодействия для WindowStatus.xaml
    /// </summary>
    public partial class WindowStatus : Window
    {
        Order Order;
        public WindowStatus(Order Order)
        {
            InitializeComponent();
            this.Order = Order;
            cbStatus.ItemsSource = DataBase.Base.OrderStatus.ToList();
            cbStatus.SelectedValuePath = "IDOrderStatus";
            cbStatus.DisplayMemberPath = "OrderStatusName";
            cbStatus.SelectedValue = Order.OrderStatus;
        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void bEnter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order.OrderStatus = cbStatus.SelectedIndex + 1;
                DataBase.Base.SaveChanges();
                MessageBox.Show("Статус заказа успешно изменен!");
                Close();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
