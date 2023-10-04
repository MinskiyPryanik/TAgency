using System;
using System.Windows;

namespace TAgency
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Manager.MainFrame = MyFrame;
            MyFrame.Navigate(new Authorization());
        }

        private void MyFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MyFrame.CanGoBack)
            {
                BtnBack.Visibility = Visibility.Visible;
            }
            else
            {
                BtnBack.Visibility = Visibility.Hidden;
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }
    }
}