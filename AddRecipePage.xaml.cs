using System.Windows;
using System.Windows.Controls;

namespace RecipeAppWPF
{
    public partial class AddRecipePage : Page
    {
        private Recipe newRecipe;

        public AddRecipePage()
        {
            InitializeComponent();
            newRecipe = new Recipe
            {
                Ingredients = new System.Collections.Generic.List<Ingredient>(),
                Steps = new System.Collections.Generic.List<Step>() // Change this to List<Step>
            };
        }

        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(IngredientQuantity.Text, out double quantity) &&
                int.TryParse(IngredientCalories.Text, out int calories))
            {
                var ingredient = new Ingredient
                {
                    Name = IngredientName.Text,
                    Quantity = quantity,
                    Unit = IngredientUnit.Text,
                    Calories = calories,
                    FoodGroup = (IngredientFoodGroup.SelectedItem as ComboBoxItem)?.Content?.ToString() // Get the selected item content as a string
                };
                newRecipe.Ingredients.Add(ingredient);
                MessageBox.Show("Ingredient added successfully.");
                IngredientName.Clear();
                IngredientQuantity.Clear();
                IngredientUnit.Clear();
                IngredientCalories.Clear();
                IngredientFoodGroup.SelectedItem = null; // Clear the selected item
            }
            else
            {
                MessageBox.Show("Invalid input for quantity or calories.");
            }
        }

        private void AddStep_Click(object sender, RoutedEventArgs e)
        {
            // Add the step as a Step object
            newRecipe.Steps.Add(new Step { Description = StepDescription.Text, IsCompleted = false });
            MessageBox.Show("Step added successfully.");
            StepDescription.Clear();
        }

        private void SaveRecipe_Click(object sender, RoutedEventArgs e)
        {
            newRecipe.Name = RecipeName.Text;
            MainWindow.Recipes.Add(newRecipe);
            MessageBox.Show("Recipe saved successfully.");
            NavigationService.GoBack();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
