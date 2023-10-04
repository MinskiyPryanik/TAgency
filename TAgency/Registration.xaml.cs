using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace TAgency
{
    public partial class Registration : Page
    {
        private Clients _currentUser = new Clients();
        public Registration()
        {
            InitializeComponent();
            GenderN.ItemsSource = Manager.GetContext().Gender.ToList();
            GenderN.SelectedItem = Manager.GetContext().Country.Find(_currentUser.gender_ID);
        }


        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder findError = new StringBuilder();
            if (Manager.GetContext().Clients.ToList().Exists(p => p.user_login == Login.Text))
                findError.AppendLine("Данный Логин занят другим пользователем, побробуйте другой");
            if (string.IsNullOrEmpty(Nname.Text) || string.IsNullOrEmpty(SecondName.Text) || string.IsNullOrEmpty(ThirdName.Text) || string.IsNullOrEmpty(Login.Text) || string.IsNullOrEmpty(Password.Text) || string.IsNullOrEmpty(PhoneNumber.Text))
                findError.AppendLine("Данные не были введены");
            if (GenderN.SelectedIndex == -1)
                findError.AppendLine("Введите ваш пол");
            if (BirthdayDate.SelectedDate == null)
                findError.AppendLine("Введите дату");
            if (PhoneNumber.Text.Length != 11)
                findError.AppendLine("Введите номер телефона правильно!");

            if (findError.Length > 0)
            {
                MessageBox.Show(findError.ToString());
                return;
            }
            try
            {
                _currentUser.first_name = SecondName.Text.ToString();
                _currentUser.last_name = Nname.Text.ToString();
                _currentUser.father_name = ThirdName.Text.ToString();
                _currentUser.phone_number = PhoneNumber.Text.ToString();
                var CurrentGender = GenderN.SelectedItem as Gender;
                _currentUser.gender_ID = CurrentGender.gender_ID;
                DateTime date = BirthdayDate.SelectedDate.Value;
                _currentUser.date_of_birthday = date.Date;
                var login = Login.Text.ToString();
                _currentUser.user_login = login;
                var crypt = System.Security.Cryptography.SHA256.Create();
                var final = crypt.ComputeHash(Encoding.UTF8.GetBytes(Password.Text.ToString()));
                _currentUser.user_pass = Convert.ToBase64String(final);
                Manager.GetContext().Clients.Add(_currentUser);
                Manager.GetContext().SaveChanges();
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + " " + ex.GetType() + " " + ex.StackTrace);
            }
        }
    }
}