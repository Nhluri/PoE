using System.Windows;
using System.Windows.Controls;

namespace RecipeAppWPF
{
    public partial class InputPage : Page
    {
        public string InputValue { get; set; }
        public string PromptText { get; set; }

        public InputPage(string promptText)
        {
            InitializeComponent();
            PromptText = promptText;
            DataContext = this;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            InputValue = InputTextBox.Text;
            NavigationService?.GoBack();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }
    }
}