﻿using System.Linq;
using System.Windows.Controls;

namespace Tests.Pages
{
    
    public partial class Reports : Page
    {
        private readonly TestsEntities db;
        public Reports()
        {
            InitializeComponent();
            db = new TestsEntities();
            DataGridReports.ItemsSource = db.test_results.ToList();
        }
    }
}
