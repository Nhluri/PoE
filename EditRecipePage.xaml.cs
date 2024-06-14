using System.Windows;
using System.Windows.Controls;

namespace RecipeAppWPF
{
    public partial class EditRecipePage : Page
    {
        private Recipe recipe;

        public EditRecipePage(Recipe recipe)
        {
            InitializeComponent();
            this.recipe = recipe;
            DataContext = this.recipe;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Save changes made in EditRecipePage

            // Notify ingredients collection changed
            recipe.OnPropertyChanged(nameof(recipe.Ingredients));
            recipe.OnPropertyChanged(nameof(recipe.TotalCalories));

            // Navigate back to RecipeDetailsPage
            NavigationService.GoBack();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            // Cancel editing and navigate back without saving changes
            NavigationService.GoBack();
        }
    }
}
