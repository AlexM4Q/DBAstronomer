using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using Database;
using Database.Models;

namespace Desktop.Windows
{
    public partial class MainWindow
    {
        private readonly AstronomerDbContext _context;
        private IList<HeavenlyBody> _bodies;

        public MainWindow()
        {
            InitializeComponent();

            _context = new AstronomerDbContext();
            _bodies = new List<HeavenlyBody>();
        }

        private void SearchButton_OnClick(object sender, RoutedEventArgs e)
        {
            var searchQuery = _searchTextBox.Text;

            _bodiesDataGrid.ItemsSource = _context.HeavenlyBodies
                .Where(body => body.Name == searchQuery)
                .ToList();
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            var body = new HeavenlyBody();
            var window = new HeavenlyBodyEditorWindow(body);
            if (window.ShowDialog() != true)
            {
                return;
            }

            _bodiesDataGrid.Items.Add(body);
            _context.HeavenlyBodies.Add(body);
            _context.SaveChanges();
        }


        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            _context.Dispose();
        }
    }
}