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

namespace prog6.Pages
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Page
    {
        public Autorization()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var login = loginBox.Text;
            var pass = passBox.Password;

            var result = await Services.Verification(login, pass);
            if (result == 1) NavigationService.Navigate(new Uri("Pages/ListUsers.xaml", UriKind.Relative));
            else if (result == 2) MessageBox.Show("Неверный пароль");
            else MessageBox.Show("Пользователь не найден");
        }
    }
}
