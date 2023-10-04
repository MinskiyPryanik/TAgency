using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace TAgency
{
    public partial class AdminTourType : Page
    {
        public AdminTourType()
        {
            InitializeComponent();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EditTourType((sender as Button).DataContext as Tour_Type, false));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EditTourType(null, true));
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var Removing = MyGrid.SelectedItems.Cast<Tour_Type>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить {Removing.Count} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Manager.GetContext().Tour_Type.RemoveRange(Removing);
                    Manager.GetContext().SaveChanges();
                    MessageBox.Show("Успешно удалено");
                    MyGrid.ItemsSource = Manager.GetContext().Tour_Type.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Manager.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                MyGrid.ItemsSource = Manager.GetContext().Tour_Type.ToList();
            }
        }
    }
}
