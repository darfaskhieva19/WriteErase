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
    /// Логика взаимодействия для WindowBasket.xaml
    /// </summary>
    public partial class WindowBasket : Window
    {
        double sum;
        double sumDiscount;
        List<ClassBasket> basket;

        public WindowBasket(List<ClassBasket> basket)
        {
            InitializeComponent();
            this.basket = basket;
            ListProd.ItemsSource = basket;
            cbPickPoint.SelectedIndex = 0;
            List<PickupPoint> pickupPoints = DataBase.Base.PickupPoint.ToList();
            for (int i = 0; i < pickupPoints.Count; i++)
            {
                cbPickPoint.Items.Add(pickupPoints[i].PostCode + ", " + pickupPoints[i].City1.CityName + ", " + pickupPoints[i].Street + ", " + pickupPoints[i].NumberHome);
            }
        }
        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string index = btn.Uid;
            if (MessageBox.Show("Вы действительно хотите удалить данный товар?", "Системное сообщение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                ClassBasket classBasket = basket.FirstOrDefault(z => z.product.ProductArticleNumber == index);
                basket.Remove(classBasket);
                if(basket.Count == 0)
                {
                    Close();
                }
                ListProd.Items.Refresh();
            }
        }
        private void tbKolvo_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            string index = tb.Uid;
            ClassBasket Prbasket = basket.FirstOrDefault(z => z.product.ProductArticleNumber == index);
            if (tb.Text.Replace(" ", "") == "")
            {
                Prbasket.count = 0;
            }
            else
            {
                Prbasket.count = Convert.ToInt32(tb.Text);
            }
            if (Prbasket.count == 0)
            {
                basket.Remove(Prbasket);
            }
            if (basket.Count == 0)
            {
                this.Close();
            }
            ListProd.Items.Refresh();
        }

        private void tbKolvo_PreviewTextInput(object sender, TextCompositionEventArgs e) //запрет символов
        {
            if (!(Char.IsDigit(e.Text, 0)))
            {
                e.Handled = true;
            }
        }
        private void btnCanel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
