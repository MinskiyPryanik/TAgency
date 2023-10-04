using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace TAgency
{
    public partial class EditHotel : Page
    {
        private Hotel _currentHotel = new Hotel();
        bool _EditOrNot;
        public EditHotel(Hotel selectedHotel, bool EditOrNot)
        {
            InitializeComponent();
            _EditOrNot = EditOrNot;
            if (selectedHotel != null)
            {
                _currentHotel = selectedHotel;
            }
            DataContext = _currentHotel;
            TownSelect.ItemsSource = Manager.GetContext().Town.ToList();
            TownSelect.SelectedItem = Manager.GetContext().Town.Find(_currentHotel.town_ID);
            HotelTypeSelect.ItemsSource = Manager.GetContext().Type_Of_Allocation.ToList();
            HotelTypeSelect.SelectedItem = Manager.GetContext().Type_Of_Allocation.Find(_currentHotel.type_of_allocation_ID);

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrEmpty(HotelName.Text))
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
                    var CurrentT = TownSelect.SelectedItem as Town;
                    _currentHotel.town_ID = CurrentT.town_ID;
                    var CurrentH = HotelTypeSelect.SelectedItem as Type_Of_Allocation;
                    _currentHotel.type_of_allocation_ID = CurrentH.type_of_allocation_ID;
                    Manager.GetContext().Hotel.Add(_currentHotel);
                }
                else
                {
                    var CurrentT = TownSelect.SelectedItem as Town;
                    _currentHotel.town_ID = CurrentT.town_ID;
                    var CurrentH = HotelTypeSelect.SelectedItem as Type_Of_Allocation;
                    _currentHotel.type_of_allocation_ID = CurrentH.type_of_allocation_ID;
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