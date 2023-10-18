using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace TAgency
{
    public partial class TourList : Page
    {
        public TourList()
        {
            InitializeComponent();

            var allTypes = Manager.GetContext().Tour_Type.ToList();
            allTypes.Insert(0, new Tour_Type
            {
                tour_type_name = "Все типы"
            });
            ComboType.ItemsSource = allTypes;
            ComboType.SelectedIndex = 0;

            UpdateTours();
        }

        private void UpdateTours()
        {
        var currentTours = Manager.GetContext().Tour.ToList();
            if (ComboType.SelectedIndex > 0)
            {
                var parr = ComboType.SelectedItem as Tour_Type;
                var par = Manager.GetContext().Tour_Type.Where(p => p.tour_type_name == parr.tour_type_name).SingleOrDefault().tour_type_ID;
                //MessageBox.Show (par.ToString());
                currentTours = currentTours.Where(p => p.tour_type_ID==par).ToList();
            }
            currentTours = currentTours.Where(p => p.tour_name.ToLower().Contains(TbSearch.Text.ToLower())).ToList();
            TourSlide.ItemsSource = currentTours.ToList();
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateTours();
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTours();
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            Tour selectedTour = clickedButton.DataContext as Tour;
            Sale sale = new Sale();
            if (!Manager.GetContext().Sale.ToList().Exists(p => p.client_ID == Manager.ID && p.tour_ID == selectedTour.tour_ID) && selectedTour.count_tickets > 0)
            {
                sale.client_ID = Manager.ID;
                sale.tour_ID = selectedTour.tour_ID;
                sale.sale_date = System.DateTime.Today;
                Manager.GetContext().Sale.Add(sale);
                Manager.GetContext().SaveChanges();
                Manager.GetContext().Tour.Where(p => p.tour_ID == selectedTour.tour_ID).FirstOrDefault().count_tickets--;
                Manager.GetContext().SaveChanges();
                StringBuilder SaleInfo = new StringBuilder();
                SaleInfo.AppendLine("Код заказа: " + sale.sale_ID.ToString());
                SaleInfo.AppendLine("Логин: " + sale.Clients.user_login.ToString());
                SaleInfo.AppendLine("Имя: " + sale.Clients.first_name.ToString());
                SaleInfo.AppendLine("Фамилия : " + sale.Clients.last_name.ToString());
                SaleInfo.AppendLine("Отчество: " + sale.Clients.father_name.ToString());
                SaleInfo.AppendLine("Тур: " + sale.Tour.tour_name.ToString());
                SaleInfo.AppendLine("Цена тура: " + sale.Tour.price.ToString() + "РУБ.");
                SaleInfo.AppendLine("Отель: " + sale.Tour.Hotel.hotel_name.ToString());
                SaleInfo.AppendLine("Цена отеля: " + sale.Tour.Hotel.price.ToString() + "РУБ.");
                SaleInfo.AppendLine("Итого: " + (sale.Tour.price + sale.Tour.Hotel.price + "РУБ.").ToString());
                SaleInfo.AppendLine();
                MessageBox.Show("Куплено, информация о заказе загружена на ваш ПК!");
                using (FileStream stream = new FileStream($"C:\\Users\\Антон\\Desktop\\{sale.Clients.last_name + " " + sale.Tour.tour_name}.txt", FileMode.Create))
                {
                    byte[] buffer = Encoding.Default.GetBytes(SaleInfo.ToString());
                    stream.Write(buffer, 0, buffer.Length);
                }
            }
            else MessageBox.Show($"Вы уже купили {selectedTour.tour_name} или туров нет в наличии");
            if (Visibility == Visibility.Visible)
            {
                Manager.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                TourSlide.ItemsSource = Manager.GetContext().Tour.ToList();
            }
        }
    }
}
