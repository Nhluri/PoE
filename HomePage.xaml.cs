using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace RecipeAppWPF
{
    public partial class HomePage : Page
    {
        private List<string> recentActivities = new List<string>();

        public HomePage()
        {
            InitializeComponent();
            UpdateRecentActivities();
        }

        // Method to add recent activity
        private void AddRecentActivity(string activity)
        {
            recentActivities.Insert(0, $"{DateTime.Now}: {activity}");
            UpdateRecentActivities();
        }

        // Method to update the RecentActivityTextBlock
        private void UpdateRecentActivities()
        {
            RecentActivityTextBlock.Text = string.Join("\n", recentActivities);
        }


        private void ViewRecipes_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ViewRecipesPage());
        }

        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddRecipePage());
            AddRecentActivity("Navigated to Add Recipe page");
        }

        private void ScaleQuantity_Click(object sender, RoutedEventArgs e)
        {
            if (!MainWindow.Recipes.Any())
            {
                MessageBox.Show("No recipes available to scale.");
                return;
            }

            NavigationService.Navigate(new ScaleQuantityPage());
            AddRecentActivity("Navigated to Scale Quantity page");
        }

        private void DeleteRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (!MainWindow.Recipes.Any())
            {
                MessageBox.Show("No recipes available to delete.");
                return;
            }

            var inputDialogPage = new DeletePage("Enter the name of the recipe to delete:", DeleteRecipe);
            NavigationService.Navigate(inputDialogPage);
            AddRecentActivity("Navigated to Delete Recipe page");
        }

        private void ResetQuantities_Click(object sender, RoutedEventArgs e)
        {
            if (!MainWindow.Recipes.Any())
            {
                MessageBox.Show("No recipes available to reset quantities.");
                return;
            }

            var inputPage = new DeletePage("Enter the name of the recipe to reset quantities:", ResetQuantities);
            NavigationService.Navigate(inputPage);
            AddRecentActivity("Navigated to Reset Quantities page");
        }

        private void ClearAllData_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Recipes.Clear();
            MessageBox.Show("All data cleared successfully.");
            AddRecentActivity("Cleared all data");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void DeleteRecipe(string recipeName)
        {
            var recipeToDelete = MainWindow.Recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipeToDelete != null)
            {
                MainWindow.Recipes.Remove(recipeToDelete);
                MessageBox.Show("Recipe deleted successfully.");
                AddRecentActivity($"Deleted recipe: {recipeToDelete.Name}");
            }
            else
            {
                MessageBox.Show("Recipe not found.");
            }
        }

        private void ResetQuantities(string recipeName)
        {
            var recipeToReset = MainWindow.Recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipeToReset != null)
            {
                foreach (var ingredient in recipeToReset.Ingredients)
                {
                    ingredient.Quantity = 0;
                }
                MessageBox.Show("Quantities reset successfully.");
                AddRecentActivity($"Reset quantities for recipe: {recipeToReset.Name}");
            }
            else
            {
                MessageBox.Show("Recipe not found.");
            }
        }
    }
}
