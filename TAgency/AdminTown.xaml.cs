using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace TAgency
{
    public partial class AdminTown : Page
    {
        public AdminTown()
        {
            InitializeComponent();
        }


        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EditTown((sender as Button).DataContext as Town, false));
            Manager.MainFrame.Navigate(new EditTown(null, true));
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var Removing = MyGrid.SelectedItems.Cast<Town>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить {Removing.Count} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Manager.GetContext().Town.RemoveRange(Removing);
                    Manager.GetContext().SaveChanges();
                    MessageBox.Show("Успешно удалено");
                    MyGrid.ItemsSource = Manager.GetContext().Town.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EditTown((sender as Button).DataContext as Town, false));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Manager.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                MyGrid.ItemsSource = Manager.GetContext().Town.ToList();
            }
        }
    }
}