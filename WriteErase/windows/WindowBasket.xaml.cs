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
        User user;

        public WindowBasket(List<ClassBasket> basket, User user)
        {
            InitializeComponent();
            this.basket = basket;
            this.user = user;
            ListProd.ItemsSource = basket;
            List<PickupPoint> pickupPoints = DataBase.Base.PickupPoint.ToList();
            for (int i = 0; i < pickupPoints.Count; i++)
            {
                cbPickPoint.Items.Add(pickupPoints[i].PostCode + ", " + pickupPoints[i].City1.CityName + ", " + pickupPoints[i].Street + ", " + pickupPoints[i].NumberHome);
            }
            cbPickPoint.SelectedIndex = 0;
            if (user != null)
            {
                tbFIO.Text = " " + user.UserSurname + " " + user.UserName + " " + user.UserPatronymic;
            }
            calculSumAndDiscount();
            tbSum.Text = "Сумма заказа: " + string.Format("{0:N2}", sum) + " руб.";
            tbSumDiscount.Text = "Скидка: " + sumDiscount + "%";
        }
        private void btDelete_Click(object sender, RoutedEventArgs e)
        {            
            if (MessageBox.Show("Вы действительно хотите удалить данный товар?", "Системное сообщение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Button btn = (Button)sender;
                string index = btn.Uid;
                ClassBasket classBasket = basket.FirstOrDefault(z => z.product.ProductArticleNumber == index);
                basket.Remove(classBasket);
                if (basket.Count == 0)
                {
                    Close();
                }
                ListProd.Items.Refresh();
                calculSumAndDiscount();
            }
        }
        private void calculSumAndDiscount()
        {
            sum = 0; sumDiscount = 0;
            foreach(ClassBasket classBasket in basket)
            {
                sum+= classBasket.count * classBasket.product.CostOrders;
                sumDiscount += classBasket.count * ((double)classBasket.product.ProductCost - classBasket.product.CostOrders);
            }
        } 
        private void tbKolvo_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            string index = tb.Uid;
            if (tb.Text == "0")
            {
                ClassBasket Prbasket = basket.FirstOrDefault(z => z.product.ProductArticleNumber == index);
                basket.Remove(Prbasket);
                ListProd.Items.Refresh();
            }

            //TextBox tb = (TextBox)sender;
            //string index = tb.Uid;
            //ClassBasket Prbasket = basket.FirstOrDefault(z => z.product.ProductArticleNumber == index);
            //if (tb.Text.Replace(" ", "") == "")
            //{
            //    Prbasket.count = 0;
            //}
            //else
            //{
            //    Prbasket.count = Convert.ToInt32(tb.Text);
            //}
            //if (Prbasket.count == 0)
            //{
            //    basket.Remove(Prbasket);
            //}
            //if (basket.Count == 0)
            //{
            //    this.Close();
            //}
            //ListProd.Items.Refresh();
            calculSumAndDiscount();
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
            try
            {
                Random rnd = new Random();
                bool three = true;
               
                foreach(ClassBasket classBasket in basket)
                {
                    if (classBasket.product.ProductQuantityInStock < 3)
                    {
                        three = false;
                    }
                }
                Order order = new Order();
                if (three == true)
                {
                    order.OrderDeliveryDate = DateTime.Now.AddDays(3);
                }
                else
                {
                    order.OrderDeliveryDate = DateTime.Now.AddDays(6);
                }
                if (cbPickPoint.SelectedIndex != 0)
                {
                    order.OrderPickupPoint = cbPickPoint.SelectedIndex;
                    order.OrderDate = DateTime.Now;
                    if (user != null)
                    {
                        order.OrderClient = user.UserID;
                    }
                    foreach (ClassBasket classB in basket)
                    {
                        OrderProduct orderProduct = new OrderProduct()
                        {
                            OrderID = order.OrderID,
                            ProductArticleNumber = classB.product.ProductArticleNumber,
                            ProductCount = classB.count
                        };
                        DataBase.Base.OrderProduct.Add(orderProduct);
                    }
                    DataBase.Base.SaveChanges();
                    MessageBox.Show("Успешное добавление заказа!");
                    basket.Clear();
                    Close();
                }
                else
                {
                    MessageBox.Show("Выберите из списка пункт выдачи!");
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так..");
            }
        }
    }
}
