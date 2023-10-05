using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace TAgency
{
    public partial class AdminSale : Page
    {
        public AdminSale()
        {
            InitializeComponent();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EditSale((sender as Button).DataContext as Sale, false));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EditSale(null, true));
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var Removing = MyGrid.SelectedItems.Cast<Sale>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить {Removing.Count} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Manager.GetContext().Sale.RemoveRange(Removing);
                    Manager.GetContext().SaveChanges();
                    MessageBox.Show("Успешно удалено");
                    MyGrid.ItemsSource = Manager.GetContext().Sale.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Manager.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                MyGrid.ItemsSource = Manager.GetContext().Sale.ToList();
            }
        }
        private void MakeTxt_Click(object sender, RoutedEventArgs e)
        {
            var Otch = (sender as Button).DataContext as Sale;
            StringBuilder SaleInfo = new StringBuilder();
            SaleInfo.AppendLine("Код заказа: " + Otch.sale_ID.ToString());
            SaleInfo.AppendLine("Логин: " + Otch.Clients.user_login.ToString());
            SaleInfo.AppendLine("Имя: " + Otch.Clients.first_name.ToString());
            SaleInfo.AppendLine("Фамилия : " + Otch.Clients.last_name.ToString());
            SaleInfo.AppendLine("Отчество: " + Otch.Clients.father_name.ToString());
            SaleInfo.AppendLine("Тур: " + Otch.Tour.tour_name.ToString());
            SaleInfo.AppendLine("Цена тура: " + Otch.Tour.price.ToString() + "РУБ.");
            SaleInfo.AppendLine("Отель: " + Otch.Tour.Hotel.hotel_name.ToString());
            SaleInfo.AppendLine("Цена отеля: " + Otch.Tour.Hotel.price.ToString() + "РУБ.");
            SaleInfo.AppendLine("Итого: " + (Otch.Tour.price + Otch.Tour.Hotel.price + "РУБ.").ToString());
            SaleInfo.AppendLine();
            MessageBox.Show(SaleInfo.ToString());
            using (FileStream stream = new FileStream("C:\\Users\\Антон\\Desktop\\Ticket.txt", FileMode.Create))
            {
                byte[] buffer = Encoding.Default.GetBytes(SaleInfo.ToString());
                stream.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
