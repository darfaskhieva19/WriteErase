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
        User user;
        List<Order> listFilter;
        public WindowOrder()
        {
            InitializeComponent();

            lvOrder.ItemsSource = DataBase.Base.Order.ToList();
            cbSort.SelectedIndex = 0;
            cbFilter.SelectedIndex = 0;
        }
        public void Filter()
        {
            listFilter = DataBase.Base.Order.ToList();

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
                //case 1:
                //    listFilter = listFilter.Where(x => x.ProductDiscountAmount > 0 && x.ProductDiscountAmount < 9.99).ToList();
                //    break;
                //case 2:
                //    listFilter = listFilter.Where(x => x.ProductDiscountAmount > 10 && x.ProductDiscountAmount < 14.99).ToList();
                //    break;
                //case 3:
                //    listFilter = listFilter.Where(x => x.ProductDiscountAmount > 15).ToList();
                //    break;
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

        }

        private void btnStatus_Click(object sender, RoutedEventArgs e)
        {
            //WindowStatus status = new WindowStatus();
            //status.ShowDialog();
        }
    }
}
