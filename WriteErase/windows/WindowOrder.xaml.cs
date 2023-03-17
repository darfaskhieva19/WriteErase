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
    /// Логика взаимодействия для WindowOrder.xaml
    /// </summary>
    public partial class WindowOrder : Window
    {
        public WindowOrder()
        {
            InitializeComponent();
            lvOrder.ItemsSource = DataBase.Base.Order.ToList();
            cbSort.SelectedIndex = 0;
            cbFilter.SelectedIndex = 0;
        }
        public void Filter()
        {
            List<Order> listFilter = DataBase.Base.Order.ToList();

            //сортировка
            switch (cbSort.SelectedIndex)
            {
                case 1:
                    listFilter.Sort((x, y) => x.Summ.CompareTo(y.Summ));
                    break;
                case 2:
                    listFilter.Sort((x, y) => x.Summ.CompareTo(y.Summ));
                    listFilter.Reverse();
                    break;
            }

            //фильтр
            switch (cbFilter.SelectedIndex)
            {
                case 1:
                    listFilter = listFilter.Where(x => x.DiscountOrder < 11).ToList();
                    break;
                case 2:
                    listFilter = listFilter.Where(x => x.DiscountOrder > 10 && x.DiscountOrder < 15).ToList();
                    break;
                case 3:
                    listFilter = listFilter.Where(x => x.DiscountOrder > 15).ToList();
                    break;
            }
            lvOrder.ItemsSource = listFilter;
            if (listFilter.Count == 0)
            {
                MessageBox.Show("Нет записей");
            }
        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void cbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnUpDate_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int index = Convert.ToInt32(btn.Uid);
            Order order = DataBase.Base.Order.FirstOrDefault(z => z.OrderID == index);
            WindowDateDelivery dateDelivery = new WindowDateDelivery(order);
            dateDelivery.ShowDialog();
        }

        private void btnStatus_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int index = Convert.ToInt32(btn.Uid);
            Order order = DataBase.Base.Order.FirstOrDefault(z=>z.OrderID==index);
            WindowStatus windowStatus = new WindowStatus(order);
            windowStatus.ShowDialog();
        }
    }
}
