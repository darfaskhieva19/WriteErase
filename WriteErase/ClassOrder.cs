using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string FIOClient //вывод ФИО клиента
        {
            get
            {
                if (OrderClient != null)
                {
                    return "Клиент: " + OrderClient;
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
                List<OrderProduct> orderProducts = DataBase.Base.OrderProduct.Where(z => z.OrderID == OrderID).ToList();
                foreach (OrderProduct product in orderProducts)
                {
                    Product products = DataBase.Base.Product.FirstOrDefault(z => z.ProductArticleNumber == product.ProductArticleNumber);
                    //summa += product.CostOrders;
                }
                return sum;
            }
        }
    }
}
