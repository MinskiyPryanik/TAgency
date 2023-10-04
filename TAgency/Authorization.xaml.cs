﻿using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace TAgency
{
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();

        }

        private void BtnRegOn_Click(object sender, RoutedEventArgs e)
        {
            if (Login.Text == "" || Password.Password == "")
                MessageBox.Show("Данные не были введены");
            else
            {
                var crypt = System.Security.Cryptography.SHA256.Create();
                var notfinal = crypt.ComputeHash(Encoding.UTF8.GetBytes(Password.Password));
                var final = Convert.ToBase64String(notfinal);
                Clients user = Manager.GetContext().Clients.FirstOrDefault(p => p.user_login == Login.Text && (p.user_pass.ToString() == final));
                if (user == null)
                {
                    MessageBox.Show("Неправильно введены данные или пользователя не существует");
                }
                else
                {
                    if (user.role_ID == 2)
                    {
                        Manager.Login = Login.Text;
                        Password.Password = "";
                        Login.Text = "";
                        Manager.MainFrame.Navigate(new TourList());
                        MessageBox.Show("Авторизация прошла успешно");
                    }
                    if (user.role_ID == 1)
                    {
                        MessageBox.Show("Добро пожаловать в админ панель");
                        Manager.MainFrame.Navigate(new AdminPanel());
                    }
                }
            }
        }

        private void BtnRegOff_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Registration());
        }

        private void AdminAuto_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AdminPanel());
        }
    }
}