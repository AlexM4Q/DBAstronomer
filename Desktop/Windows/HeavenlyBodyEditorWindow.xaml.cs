using System.Globalization;
using System.Windows;
using Database.Models;

namespace Desktop.Windows
{
    public partial class HeavenlyBodyEditorWindow
    {
        private readonly HeavenlyBody _body;

        public HeavenlyBodyEditorWindow(HeavenlyBody body)
        {
            InitializeComponent();

            _body = body;
            _nameTextBox.Text = body.Name;
            _typeTextBox.Text = body.Type;
            _distanceTextBox.Text = body.Distance.ToString(CultureInfo.InvariantCulture);
            _massTextBox.Text = body.Mass.ToString(CultureInfo.InvariantCulture);
            _radiusTextBox.Text = body.Radius.ToString(CultureInfo.InvariantCulture);
        }

        private void OkButton_OnClick(object sender, RoutedEventArgs e)
        {
            _body.Name = _nameTextBox.Text;
            _body.Type = _typeTextBox.Text;
            _body.Distance = double.Parse(_distanceTextBox.Text);
            _body.Mass = double.Parse(_massTextBox.Text);
            _body.Radius = double.Parse(_radiusTextBox.Text);

            DialogResult = true;
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}