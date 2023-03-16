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
    /// Логика взаимодействия для WindowCaptcha.xaml
    /// </summary>
    public partial class WindowCaptcha : Window
    {
        string str = String.Empty;
        public WindowCaptcha()
        {
            InitializeComponent();
            Random random = new Random();
            string sym = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string[] ch = new string[4];
            for (int i = 0; i < 10; i++)
            {
                SolidColorBrush solidColor = new SolidColorBrush(Color.FromRgb((byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256)));
                Line l = new Line()
                {
                    X1 = random.Next((int)CCaptcha.Width),
                    Y1 = random.Next((int)CCaptcha.Height),
                    X2 = random.Next((int)CCaptcha.Width),
                    Y2 = random.Next((int)CCaptcha.Height),
                    Stroke = solidColor
                };
                CCaptcha.Children.Add(l);
            }
            for (int i = 0; i < 4; i++)
            {
                ch[i] = Convert.ToString(sym[random.Next(sym.Length)]);
                str += ch[i];
            }
            TextBlock txt1 = new TextBlock()
            {
                Text = (string)ch[0].ToString(),
                TextDecorations = TextDecorations.Strikethrough,
                FontSize = random.Next(18, 22),
                FontFamily = new FontFamily("Comic Sans MS"),
                FontWeight = FontWeights.Bold,
                FontStyle = FontStyles.Italic,
                Margin = new Thickness(10),
                Padding = new Thickness(25)
            };
            CCaptcha.Children.Add(txt1);
            TextBlock txt = new TextBlock()
            {
                Text = (string)ch[1].ToString(),
                FontSize = random.Next(14, 18),
                FontFamily = new FontFamily("Comic Sans MS"),
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(15),
                Padding = new Thickness(30)
            };
            CCaptcha.Children.Add(txt);
            TextBlock txt2 = new TextBlock()
            {
                Text = (string)ch[2].ToString(),
                TextDecorations = TextDecorations.Strikethrough,
                FontSize = random.Next(14, 18),
                FontFamily = new FontFamily("Comic Sans MS"),
                FontWeight = FontWeights.Bold,
                FontStyle = FontStyles.Italic,
                Margin = new Thickness(10),
                Padding = new Thickness(45)
            };
            CCaptcha.Children.Add(txt2);
            TextBlock txt3 = new TextBlock()
            {
                Text = (string)ch[3].ToString(),
                FontSize = random.Next(14, 18),
                FontFamily = new FontFamily("Comic Sans MS"),
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(15),
                Padding = new Thickness(65)
            };
            CCaptcha.Children.Add(txt3);
        }

        private void tbCaptcha_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbCaptcha.Text.Length == 4)
            {
                if (tbCaptcha.Text == str)
                {
                    MessageBox.Show("Успешно!", "Подтверждение");
                    ClassFrame.frameL.Navigate(new ListOfTovar());
                    Close();

                }
                else
                {
                    MessageBox.Show("CAPTCHA введена неверно!", "Ошибка");
                    ClassFrame.frameL.Navigate(new PageAuto(1));
                    Close();
                }
            }
        }
    }
}
