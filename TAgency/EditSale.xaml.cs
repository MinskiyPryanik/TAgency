using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace TAgency
{
    public partial class EditSale : Page
    {
        private Sale _currentSale = new Sale();
        bool _EditOrNot;
        public EditSale(Sale selectedSale, bool EditOrNot)
        {
            InitializeComponent();
            DateStart.SelectedDate = DateTime.Now;
            _EditOrNot = EditOrNot;
            if (selectedSale != null)
            {
                _currentSale = selectedSale;
            }
            DataContext = _currentSale;
            ClientSelect.ItemsSource = Manager.GetContext().Clients.ToList();
            ClientSelect.SelectedItem = Manager.GetContext().Clients.Find(_currentSale.client_ID);
            TourSelect.ItemsSource = Manager.GetContext().Tour.ToList();
            TourSelect.SelectedItem = Manager.GetContext().Tour.Find(_currentSale.tour_ID);
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_EditOrNot)
                {
                    var CurrentTypeC = ClientSelect.SelectedItem as Clients;
                    _currentSale.client_ID = CurrentTypeC.client_ID;
                    var CurrentTypeT = TourSelect.SelectedItem as Tour;
                    _currentSale.tour_ID = CurrentTypeT.tour_ID;
                    Manager.GetContext().Sale.Add(_currentSale);
                }
                else
                {
                    var CurrentTypeC = ClientSelect.SelectedItem as Clients;
                    _currentSale.client_ID = CurrentTypeC.client_ID;
                    var CurrentTypeT = TourSelect.SelectedItem as Tour;
                    _currentSale.tour_ID = CurrentTypeT.tour_ID;
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
