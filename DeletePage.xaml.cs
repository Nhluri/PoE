using System;
using System.Windows;
using System.Windows.Controls;

namespace RecipeAppWPF
{
    public partial class DeletePage : Page
    {
        private Action<string> _callback;

        public DeletePage(string prompt, Action<string> callback)
        {
            InitializeComponent();
            PromptText.Text = prompt;
            _callback = callback;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            _callback?.Invoke(InputTextBox.Text);
            NavigationService.GoBack();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}

