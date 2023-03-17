using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WriteErase
{
    public partial class Order
    {
        public string NumberOrder
        {
            get
            {
                return "Номер заказа: " + OrderID;
            }
        }
        public string OrderS
        {
            get
            {
                string str = "Состав заказа: ";
                List<OrderProduct> products = DataBase.Base.OrderProduct.Where(z => z.OrderID == OrderID).ToList();
                foreach (OrderProduct prod in products)
                {
                    Product product = DataBase.Base.Product.FirstOrDefault(z => z.ProductArticleNumber == prod.ProductArticleNumber);
                    str += product.ProductArticleNumber + " - " + product.TitleProduct.TitleProduct1;
                }
                return str.Substring(0, str.Length - 2);
            }
        }
        public string FIOClient
        {
            get
            {
                if (OrderClient != null)
                {
                    return "Заказчик: " + User.UserSurname + " " + User.UserName + " " + User.UserPatronymic;
                }
                else
                {
                    return null;
                }
            }
        }
        public string Summ
        {
            get
            {
                List<OrderProduct> orders = DataBase.Base.OrderProduct.Where(z => z.OrderID == OrderID).ToList();
                double sum = 0;
                foreach (OrderProduct product in orders)
                {
                    Product products = DataBase.Base.Product.FirstOrDefault(z => z.ProductArticleNumber == product.ProductArticleNumber);
                    sum += products.CostOrders;
                }
                return "Стоимость заказа: " + string.Format("{0:N2}", sum) + " руб.";
            }
        }
        public double SummaOrder
        {
            get
            {
                double sum = 0;
                List<OrderProduct> orderProducts = DataBase.Base.OrderProduct.Where(x => x.OrderID == OrderID).ToList();
                foreach (OrderProduct product in orderProducts)
                {
                    Product products = DataBase.Base.Product.FirstOrDefault(z => z.ProductArticleNumber == product.ProductArticleNumber);
                    sum += products.CostOrders;
                }
                return sum;
            }
        }

        public double DiscountOrder
        {
            get
            {
                double discount = 0;
                double sum = 0;
                double sumNew = 0;
                List<OrderProduct> orders = DataBase.Base.OrderProduct.Where(z => z.OrderID == OrderID).ToList();
                foreach (OrderProduct Pr in orders)
                {
                    Product product = DataBase.Base.Product.FirstOrDefault(z => z.ProductArticleNumber == Pr.ProductArticleNumber);
                    sum += (double)product.ProductCost;
                    sumNew += product.CostOrders;
                }
                discount = 100 - 100 * sumNew / sum;
                return discount;
            }
        }
        public string DiscountS
        {
            get
            {
                return "Общая скидка: " + string.Format("{0:N2}", DiscountOrder) + "%";
            }
        }


        public SolidColorBrush Color
        {
            get
            {
                bool z = true;
                List<OrderProduct> orderProducts = DataBase.Base.OrderProduct.Where(x => x.OrderID == OrderID).ToList();
                foreach (OrderProduct ordersP in orderProducts)
                {
                    Product product = DataBase.Base.Product.FirstOrDefault(x => x.ProductArticleNumber == ordersP.ProductArticleNumber);
                    if (product.ProductQuantityInStock > 3)
                    {
                        z = false;
                        break;
                    }
                }
                if (z)
                {
                    SolidColorBrush color = (SolidColorBrush)new BrushConverter().ConvertFromString("#20b2aa");
                    return color;
                }
                else
                {
                    SolidColorBrush color = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8c00");
                    return color;
                }
                return Brushes.White;
            }
        }
    }
}
