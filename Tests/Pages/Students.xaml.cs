using System.Linq;
using System.Windows.Controls;

namespace Tests.Pages
{
    public partial class Students : Page
    {
        private readonly TestsEntities db;
        public Students()
        {
            InitializeComponent();
            db = new TestsEntities();
            DataGridsStudents.ItemsSource = db.students.ToList();
        }
    }
}
