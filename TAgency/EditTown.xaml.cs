using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TAgency
{
    public partial class EditTown : Page
    {
        private Town _currentTown = new Town();
        bool _EditOrNot;
        public EditTown(Town selectedTown, bool EditOrNot)
        {
            InitializeComponent();
            _EditOrNot = EditOrNot;
            if (selectedTown != null)
            {
                _currentTown = selectedTown;
            }
            DataContext = _currentTown;
            CountrySelect.ItemsSource = Manager.GetContext().Country.ToList();
            CountrySelect.SelectedItem = Manager.GetContext().Country.Find(_currentTown.country_ID);
        }

        private void TownName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsValidRussianLetter(e.Text);
        }

        private bool IsValidRussianLetter(string text)
        {
            Regex regex = new Regex("^[а-яА-Я]+$");
            return regex.IsMatch(text);
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrEmpty(TownName.Text))
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
                    var Current = CountrySelect.SelectedItem as Country;
                    _currentTown.country_ID = Current.country_ID;
                    Manager.GetContext().Town.Add(_currentTown);
                }
                else
                {
                    var Current = CountrySelect.SelectedItem as Country;
                    _currentTown.country_ID = Current.country_ID;
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