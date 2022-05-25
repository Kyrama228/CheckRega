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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(LoginTxt.Text) || String.IsNullOrWhiteSpace(PassPb.Password))
            {
                MessageBox.Show("Неправильное заполнение данных");
                return;
            }
            else
            {
                User user = new User();
                var autPage = MainWindow.ent.User.ToList().Find(c => c.Login == LoginTxt.Text.Trim());
                if (autPage != null)
                {
                    MessageBox.Show("Польвозатель уже зарегистрирован");
                }
                else
                {
                    user.Id_Role = 1;
                    user.Login = LoginTxt.Text.Trim();
                    user.Password = PassPb.Password.Trim();
                    MainWindow.ent.User.Add(user);
                    MainWindow.ent.SaveChanges();
                    MessageBox.Show("Вы успешно зарегистрировались");
                    NavigationService.Navigate( new ProductsPage());      
                }               
            }
        }
    }
}
