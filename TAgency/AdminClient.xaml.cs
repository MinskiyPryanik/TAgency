using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace TAgency
{
    public partial class AdminClient : Page
    {
        public AdminClient()
        {
            InitializeComponent();
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Manager.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                MyGrid.ItemsSource = Manager.GetContext().Clients.ToList();
            }
        }
    }
}
