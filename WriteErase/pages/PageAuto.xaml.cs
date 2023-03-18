using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WriteErase
{
    /// <summary>
    /// Логика взаимодействия для PageAuto.xaml
    /// </summary>
    public partial class PageAuto : Page
    {
        DispatcherTimer timer = new DispatcherTimer();
        int time = 10;
        string str = String.Empty;
        public PageAuto()
        {
            InitializeComponent();
            tbLogin.Focus();
        }
        public PageAuto(int k)
        {
            InitializeComponent();
            tbLogin.Focus();
            CAPTCHA();
            spCaptcha.Visibility = Visibility.Visible;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            time--;
            tbTime.Text = "Вы сможете зайти через " + time + " секунд";
            if (time < 0)
            {
                timer.Stop();
                btAuto.IsEnabled = true;
                tbTime.Visibility = Visibility.Collapsed;
                ClassFrame.frameL.Navigate(new PageAuto(2));
            }
        }

        private void tbAuto_Click(object sender, RoutedEventArgs e)
        {
            if (tbLogin.Text == "" || tbPassword.Password == "")
            {
                MessageBox.Show("Не все обязательные поля заполнены!");
            }
            else
            {
                User user = DataBase.Base.User.FirstOrDefault(z => z.UserLogin == tbLogin.Text && z.UserPassword == tbPassword.Password);
                if (user == null)
                {
                    MessageBox.Show("Вы ввели данные неверно! Повторите вход!");
                    btAuto.IsEnabled = false;
                    tbLogin.Text = "";
                    tbPassword.Password = "";
                    CAPTCHA();
                    spCaptcha.Visibility = Visibility.Visible;
                }
                else
                {                    
                    switch (user.UserRole)
                    {
                        case 1: //клиент
                            ClassFrame.frameL.Navigate(new ListOfTovar(user));
                            break;
                        case 2: //администратор
                            ClassFrame.frameL.Navigate(new ListOfTovar(user));
                            break;
                        case 3: //менеджер
                            ClassFrame.frameL.Navigate(new ListOfTovar(user));
                            break;
                    }
                }
            }
        }

        public void CAPTCHA()
        {
            CCaptcha.Children.Clear();
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
                Padding = new Thickness(15)
            };
            CCaptcha.Children.Add(txt1);
            TextBlock txt = new TextBlock()
            {
                Text = (string)ch[1].ToString(),
                FontSize = random.Next(14, 18),
                FontFamily = new FontFamily("Comic Sans MS"),
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(17),
                Padding = new Thickness(23)
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
                Padding = new Thickness(35)
            };
            CCaptcha.Children.Add(txt2);
            TextBlock txt3 = new TextBlock()
            {
                Text = (string)ch[3].ToString(),
                FontSize = random.Next(14, 18),
                FontFamily = new FontFamily("Comic Sans MS"),
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(20),
                Padding = new Thickness(35)
            };
            CCaptcha.Children.Add(txt3);
        }

        private void tbGuest_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frameL.Navigate(new ListOfTovar());
        }

        private void tbCaptcha_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbCaptcha.Text.Length == 4)
            {
                if (tbCaptcha.Text == str)
                {
                    MessageBox.Show("Успешно!", "Подтверждение");
                    btAuto.IsEnabled = true;                    
                }
                else
                {
                    MessageBox.Show("CAPTCHA введена неверно!", "Ошибка");
                    btAuto.IsEnabled = false;
                    tbLogin.Text = "";
                    tbPassword.Password = "";
                    tbCaptcha.Text = "";
                    tbLogin.IsEnabled = false;
                    tbPassword.IsEnabled = false;
                    tbCaptcha.IsEnabled = false;
                    timer.Interval = new TimeSpan(0, 0, 1);
                    timer.Tick += new EventHandler(Timer_Tick);
                    timer.Start();
                    tbTime.Visibility = Visibility.Visible;
                    tbCaptcha.Visibility = Visibility.Visible;                    
                }
            }
        }
    }
}
