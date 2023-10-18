using System.Windows.Controls;

namespace TAgency
{
    public class Manager
    {
        private static TourAgencyEntities _context;
        public static TourAgencyEntities GetContext()
        {
            if (_context == null)
                _context = new TourAgencyEntities();
            return _context;
        }
        public static Frame MainFrame { get; set; }
        public static int ID{ get; set; }
    }
}
