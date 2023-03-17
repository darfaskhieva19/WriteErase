using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WriteErase
{
    public partial class Product
    {
        public string Name 
        {
            get
            {
                return TitleProduct.TitleProduct1;
            }
        }
        public string Description 
        {
            get
            {
                return ProductDescription;
            }
        }
        public string Manufact 
        {
            get
            {
                return "Производитель: " + Manufacturer.ProductManufacturer;
            }
        }
        public SolidColorBrush ColorDiscount 
        {
            get
            {
                if (ProductDiscountMax > 15)
                {
                    SolidColorBrush solid = new SolidColorBrush(Color.FromRgb(127, 255, 0));
                    return solid;
                }
                else
                {
                    return Brushes.White;
                }
            }
        }
        public double Disc 
        {
            get
            {
                return (double)ProductDiscountAmount;
            }
        }
        public string Price 
        {
            get
            {
                return string.Format("{0:N2}", ProductCost) + " руб.";
            }
        }
        public string NewCost 
        {
            get
            {
                return (double)(Convert.ToDouble(ProductCost) - (Convert.ToDouble(ProductCost) * ProductDiscountAmount / 100)) + " руб.";
            }
        }
        public double CostOrders
        {
            get
            {
                if (ProductDiscountAmount > 0)
                {
                    double cost = (double)((double)ProductCost - (double)ProductCost * (ProductDiscountAmount / 100));
                    return cost;
                }
                else
                {
                    return (double)ProductCost;
                }
            }
        }
        public string Photo
        {
            get
            {
                if (ProductPhoto != null)
                {
                    return "\\images\\" + ProductPhoto;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
