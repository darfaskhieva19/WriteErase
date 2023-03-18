using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Runtime.CompilerServices;
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
        double sum; //сумма
        double sumDiscount; //скидка заказа
        double sD;
        List<ClassBasket> basket;
        User user;

        public WindowBasket(List<ClassBasket> basket, User user)
        {
            InitializeComponent();
            this.basket = basket;
            this.user = user;
            ListProd.ItemsSource = basket;
            List<PickupPoint> pickupPoints = DataBase.Base.PickupPoint.ToList();
            foreach (PickupPoint pickup in pickupPoints)
            {
                cbPickPoint.Items.Add(pickup.PostCode + ", " + pickup.City1.CityName + ", " + pickup.Street + ", " + pickup.NumberHome);
            }
            cbPickPoint.SelectedIndex = 0;
            if (user != null)
            {
                tbFIO.Text = " " + user.UserSurname + " " + user.UserName + " " + user.UserPatronymic;
            }
            calc();
            tbSum.Text = "Сумма заказа: " + string.Format("{0:N2}", sum) + " руб.";
            tbSumDiscount.Text = "Скидка: " + sumDiscount + "%";
        }     
        private void calc()
        {
            sum = 0; sumDiscount = 0; sD = 0;
            foreach (ClassBasket classBasket in basket)
            {
                sum += (double)classBasket.product.CostOrders;
                sD += (double)classBasket.product.ProductCost;
                sumDiscount = 100-100 * sum / sD;
            }           
        }
        
        private void tbKolvo_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            string index = tb.Uid;
            ClassBasket Prbasket = basket.FirstOrDefault(z => z.product.ProductArticleNumber == index);
            if (tb.Text == "0")
            {                
                basket.Remove(Prbasket);
                ListProd.Items.Refresh();
            }
            if (basket.Count == 0)
            {
                Close();
            }            
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
            //try
            //{
                int kolvoDay = 0; //количество дней на доставку   
                foreach (ClassBasket classBasket in basket)
                {
                    if (classBasket.product.ProductQuantityInStock < 3)
                    {
                        kolvoDay = 6;
                    }
                    else
                    {
                        kolvoDay = 3;
                    }
                }
                Order order = new Order(); //создание нового заказа 
                order.OrderStatus = DataBase.Base.OrderStatus.FirstOrDefault(x => x.OrderStatusName == "Новый").IDOrderStatus;
                List<Order> orderL = DataBase.Base.Order.OrderBy(x => x.OrderID).ToList();
                order.OrderID = orderL[orderL.Count - 1].OrderID + 1;
                order.OrderDeliveryDate = order.OrderDate.AddDays(kolvoDay);
                order.OrderPickupPoint = cbPickPoint.SelectedIndex + 1;
                order.OrderDate = DateTime.Now;
                if (user != null)
                {
                    order.OrderClient = user.UserID;
                }
                Random rnd = new Random();
                order.OrderCode = rnd.Next(100, 800); //генерация кода
                DataBase.Base.Order.Add(order);
                DataBase.Base.SaveChanges();
                foreach (ClassBasket clBasket in basket)
                {
                    OrderProduct orderP = new OrderProduct(); //создание новых данных таблицы Orderproduct
                    orderP.OrderID = order.OrderID;
                    orderP.ProductArticleNumber = clBasket.product.ProductArticleNumber;
                    orderP.ProductCount = clBasket.count;
                    DataBase.Base.OrderProduct.Add(orderP);
                }
                DataBase.Base.SaveChanges();
                MessageBox.Show("Успешное добавление заказа!");
                basket.Clear();
                Close();

            //}
            //catch
            //{
            //    MessageBox.Show("Что-то пошло не так..");
            //}
        }

        private void bDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить данный товар?", "Системное сообщение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Button btn = (Button)sender;
                string index = btn.Uid;
                ClassBasket classBasket = basket.FirstOrDefault(z => z.product.ProductArticleNumber == index);
                basket.Remove(classBasket);
                ListProd.Items.Refresh();
            }
        }
    }
}
