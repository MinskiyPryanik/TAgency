using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace TAgency
{
    public partial class EditTour : Page
    {
        private Tour _currentTour = new Tour();
        bool _EditOrNot;
        public EditTour(Tour selectedTour, bool EditOrNot)
        {
            InitializeComponent();
            _EditOrNot = EditOrNot;
            if (selectedTour != null)
            {
                _currentTour = selectedTour;
            }
            DataContext = _currentTour;
            TourTypeSelect.ItemsSource = Manager.GetContext().Tour_Type.ToList();
            TourTypeSelect.SelectedItem = Manager.GetContext().Tour_Type.Find(_currentTour.tour_type_ID);
            FoodTypeSelect.ItemsSource = Manager.GetContext().Food_Type.ToList();
            FoodTypeSelect.SelectedItem = Manager.GetContext().Food_Type.Find(_currentTour.food_type_ID);
            HotelSelect.ItemsSource = Manager.GetContext().Hotel.ToList();
            HotelSelect.SelectedItem = Manager.GetContext().Hotel.Find(_currentTour.hotel_ID);

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrEmpty(TourName.Text))
                error.AppendLine("Ошибка ввода, данные не были введены");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            try
            {
                if (_EditOrNot)
                {
                    var CurrentType = TourTypeSelect.SelectedItem as Tour_Type;
                    _currentTour.tour_type_ID = CurrentType.tour_type_ID;
                    var CurrentFood = FoodTypeSelect.SelectedItem as Food_Type;
                    _currentTour.food_type_ID = CurrentFood.food_type_ID;
                    var CurrentHotel = HotelSelect.SelectedItem as Hotel;
                    _currentTour.hotel_ID = CurrentHotel.hotel_ID;
                    Manager.GetContext().Tour.Add(_currentTour);
                }
                else
                {
                    var CurrentType = TourTypeSelect.SelectedItem as Tour_Type;
                    _currentTour.tour_type_ID = CurrentType.tour_type_ID;
                    var CurrentFood = FoodTypeSelect.SelectedItem as Food_Type;
                    _currentTour.food_type_ID = CurrentFood.food_type_ID;
                    var CurrentHotel = HotelSelect.SelectedItem as Hotel;
                    _currentTour.hotel_ID = CurrentHotel.hotel_ID;
                }
                Manager.GetContext().SaveChanges();
                MessageBox.Show("Успешно");
                Manager.MainFrame.GoBack();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + " " + ex.GetType() + " " + ex.StackTrace);
            }
        }
    }
}
