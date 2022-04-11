using prog6.Models;
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
    /// Логика взаимодействия для ListUsers.xaml
    /// </summary>
    public partial class ListUsers : Page
    {
        public ListUsers()
        {
            InitializeComponent();
            ListUser.ItemsSource = _services.GetAll().GetAwaiter().GetResult();
        }

        private readonly Services _services = new Services();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Pages/ListManager.xaml", UriKind.Relative));
        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            var selectUser = (Users)ListUser.SelectedItem;
            await _services.Delete(selectUser);
            ListUser.ItemsSource = await _services.GetAll();
        }

        private async void AddUser_Click(object sender, RoutedEventArgs e)
        {
            var user = new Users()
            {
                Surname = Surname.Text,
                Name = Name.Text,
                Lastname = Lastname.Text,
                Phone = Phone.Text,
                Date = DateTime.Now
            };
            await _services.Create(user);
            ListUser.ItemsSource = await _services.GetAll();
        }

        private async void SearchUser_Click(object sender, RoutedEventArgs e)
        {
            var user = await _services.SearchByName(SearchBox.Text);
            ListUser.ItemsSource = user.ToList();

        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ListUser.ItemsSource = await _services.GetAll();
        }
    }
}
