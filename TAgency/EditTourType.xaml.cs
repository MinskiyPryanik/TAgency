using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TAgency
{
    public partial class EditTourType : Page
    {
        private Tour_Type _currenttourType = new Tour_Type();
        bool _EditOrNot;
        public EditTourType(Tour_Type selectedtourType, bool EditOrNot)
        {
            InitializeComponent();
            _EditOrNot = EditOrNot;
            if (selectedtourType != null)
            {
                _currenttourType = selectedtourType;
            }
            DataContext = _currenttourType;
        }


        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrEmpty(TourTypeName.Text))
                error.AppendLine("Ошибка ввода, данные не были введены");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            try
            {
                if (_EditOrNot)
                Manager.GetContext().Tour_Type.Add(_currenttourType);
                Manager.GetContext().SaveChanges();
                MessageBox.Show("Успешно");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + " " + ex.GetType() + " " + ex.StackTrace);
            }
        }

        private void CountryName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsValidRussianLetter(e.Text);
        }

        private bool IsValidRussianLetter(string text)
        {
            Regex regex = new Regex("^[а-яА-Я]+$");
            return regex.IsMatch(text);
        }
    }
}