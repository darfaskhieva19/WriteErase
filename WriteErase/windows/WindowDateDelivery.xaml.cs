using System;
using System.Collections.Generic;
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

namespace WriteErase
{
    /// <summary>
    /// Логика взаимодействия для WindowDateDelivery.xaml
    /// </summary>
    public partial class WindowDateDelivery : Window
    {
        Order order;
        public WindowDateDelivery(Order order)
        {
            InitializeComponent();
            this.order = order;
            dpDate.SelectedDate = order.OrderDeliveryDate;
        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void bEnter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                order.OrderDeliveryDate = (DateTime)dpDate.SelectedDate;
                DataBase.Base.SaveChanges();
                Close();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
