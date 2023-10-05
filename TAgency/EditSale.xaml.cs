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

namespace TAgency
{
    /// <summary>
    /// Логика взаимодействия для EditSale.xaml
    /// </summary>
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
