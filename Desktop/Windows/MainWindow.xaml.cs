using System.Collections.ObjectModel;
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
        private ObservableCollection<HeavenlyBody> _bodies;

        public MainWindow()
        {
            InitializeComponent();

            _context = new AstronomerDbContext();
            _bodies = new ObservableCollection<HeavenlyBody>();

            _bodiesDataGrid.ItemsSource = _bodies;
        }

        private void SearchButton_OnClick(object sender, RoutedEventArgs e)
        {
            var searchQuery = _searchTextBox.Text;

            _bodies.Clear();
            switch (_fieldComboBox.SelectedIndex)
            {
                case 0:
                    _context.HeavenlyBodies
                        .Where(body => body.Name.Contains(searchQuery))
                        .ToList()
                        .ForEach(_bodies.Add);
                    break;
                case 1:
                    _context.HeavenlyBodies
                        .Where(body => body.Type.Contains(searchQuery))
                        .ToList()
                        .ForEach(_bodies.Add);
                    break;
                case 2:
                    if (double.TryParse(searchQuery, out var distance))
                    {
                        _context.HeavenlyBodies
                            .Where(body => body.Distance == distance)
                            .ToList()
                            .ForEach(_bodies.Add);
                    }

                    break;
                case 3:
                    if (double.TryParse(searchQuery, out var mass))
                    {
                        _context.HeavenlyBodies
                            .Where(body => body.Mass == mass)
                            .ToList()
                            .ForEach(_bodies.Add);
                    }

                    break;
                case 4:
                    if (double.TryParse(searchQuery, out var radius))
                    {
                        _context.HeavenlyBodies
                            .Where(body => body.Radius == radius)
                            .ToList()
                            .ForEach(_bodies.Add);
                    }

                    break;
            }
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            var body = new HeavenlyBody();
            var window = new HeavenlyBodyEditorWindow(body);
            if (window.ShowDialog() != true)
            {
                return;
            }

            _bodies.Add(body);
            _context.HeavenlyBodies.Add(body);
            _context.SaveChanges();
        }

        private void RemoveButton_OnClick(object sender, RoutedEventArgs e)
        {
            var selectedRow = _bodiesDataGrid.SelectedIndex;
            if (selectedRow < 0 || _bodies.Count <= selectedRow)
            {
                return;
            }

            var body = _bodies[selectedRow];
            _bodies.RemoveAt(selectedRow);
            _context.HeavenlyBodies.Remove(body);
            _context.SaveChanges();
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            _context.Dispose();
        }
    }
}