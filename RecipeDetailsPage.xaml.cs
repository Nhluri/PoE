using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace RecipeAppWPF
{
    public partial class RecipeDetailsPage : Page
    {
        public Recipe CurrentRecipe { get; set; }

        public RecipeDetailsPage(Recipe recipe)
        {
            InitializeComponent();
            CurrentRecipe = recipe;
            DataContext = CurrentRecipe;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the EditRecipePage and pass the current recipe
            NavigationService.Navigate(new EditRecipePage(CurrentRecipe));
        }
    }
}
