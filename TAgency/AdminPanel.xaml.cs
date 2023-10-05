using System.Windows;
using System.Windows.Controls;

namespace TAgency
{
    public partial class AdminPanel : Page
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void Country_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AdminCountry());
        }

        private void Town_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AdminTown());
        }

        private void Hotels_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AdminHotel());
        }

        private void Tour_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AdminTour());
        }

        private void Clients_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AdminClient());
        }

        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            //Manager.MainFrame.Navigate(new AdminList())
        }

        private void TourType_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AdminTourType());
        }

        private void Sales_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AdminSale());
        }

        private void TypeOfAllocation_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AdminTypeOfAllocation());
        }
    }
}