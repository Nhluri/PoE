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

            UpdateTotalCalories();

            CurrentRecipe.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(CurrentRecipe.TotalCalories))
                {
                    UpdateTotalCalories();
                }
            };
        }

        private void UpdateTotalCalories()
        {
            int totalCalories = CurrentRecipe.TotalCalories;
            TotalCalories.Text = $"Total Calories: {totalCalories}";

            if (totalCalories > 300)
            {
                CaloriesWarning.Visibility = Visibility.Visible;
                MessageBox.Show("Total calories exceed 300!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                CaloriesWarning.Visibility = Visibility.Collapsed;
            }
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
