using System.Windows;
using System.Windows.Controls;

namespace RecipeAppWPF
{
    public partial class EditRecipePage : Page
    {
        public Recipe CurrentRecipe { get; set; }

        public EditRecipePage(Recipe recipe)
        {
            InitializeComponent();
            CurrentRecipe = recipe;
            DataContext = CurrentRecipe;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Save the changes (this could involve saving to a database or updating the main view)
            // For now, we simply navigate back
            NavigationService.GoBack();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            // Discard changes (navigate back without saving)
            NavigationService.GoBack();
        }
    }
}
