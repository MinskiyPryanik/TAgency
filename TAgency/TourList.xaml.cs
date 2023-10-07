using System.Linq;
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
            TourSlide.ItemsSource = currentTours.ToList ();
        }

        private void BuyTour_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            Tour selectedTour = clickedButton.DataContext as Tour;
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateTours();
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTours();
        }
    }
}
