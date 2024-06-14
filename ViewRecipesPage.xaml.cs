using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace RecipeAppWPF
{
    public partial class ViewRecipesPage : Page
    {
        public ViewRecipesPage()
        {
            InitializeComponent();
            LoadAndDisplayRecipes();
            ShowNoRecipesMessageBox();
        }

        private void LoadAndDisplayRecipes()
        {
            var sortedRecipes = MainWindow.Recipes.OrderBy(r => r.Name).ToList();
            RecipeListBox.ItemsSource = sortedRecipes;
        }

        private void RecipeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RecipeListBox.SelectedItem is Recipe selectedRecipe)
            {
                NavigationService.Navigate(new RecipeDetailsPage(selectedRecipe));
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void PieChart_Click(object sender, RoutedEventArgs e)
        {
            var pieChartPage = new PieChartPage(MainWindow.Recipes);
            NavigationService.Navigate(pieChartPage);
        }

        private void ShowNoRecipesMessageBox()
        {
            if (MainWindow.Recipes.Count == 0)
            {
                MessageBox.Show("No recipes added.", "No Recipes", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
