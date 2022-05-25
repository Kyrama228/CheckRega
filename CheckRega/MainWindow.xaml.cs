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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CheckRega
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static RykobludEntities ent = new RykobludEntities();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            RegBtn.Visibility = Visibility.Hidden;
            if(String.IsNullOrWhiteSpace(LoginTxt.Text) || String.IsNullOrWhiteSpace(PassPb.Password))
            {
                MessageBox.Show("Неправильное заполнение данных");
                return;
            }
            else
            {
                User autPage = MainWindow.ent.User.ToList().Find(c => c.Login == LoginTxt.Text.Trim() && c.Password == PassPb.Password.Trim());
                if (autPage != null)
                {
                    Go.Content = new ProductsPage();
                }
                else
                {
                    MessageBox.Show("Проверьте данные");
                }
            }
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            RegBtn.Visibility = Visibility.Hidden;
            Go.Content = new RegPage();
        }
    }
}
