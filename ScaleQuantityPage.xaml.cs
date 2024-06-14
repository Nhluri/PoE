using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RecipeAppWPF
{
    public partial class ScaleQuantityPage : Page
    {
        public ScaleQuantityPage()
        {
            InitializeComponent();
            RecipeListBox.ItemsSource = MainWindow.Recipes.Select(r => r.Name).ToList();
        }

        private void ScaleButton_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a recipe.");
                return;
            }

            if (ScalingFactorComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a scaling factor.");
                return;
            }

            string selectedRecipeName = RecipeListBox.SelectedItem.ToString();
            double scalingFactor = double.Parse(((ComboBoxItem)ScalingFactorComboBox.SelectedItem).Content.ToString());

            Recipe recipeToScale = MainWindow.Recipes.FirstOrDefault(r => r.Name.Equals(selectedRecipeName, StringComparison.OrdinalIgnoreCase));
            if (recipeToScale != null)
            {
                foreach (var ingredient in recipeToScale.Ingredients)
                {
                    ingredient.Quantity *= scalingFactor;
                }
                MessageBox.Show("Recipe quantities scaled successfully.");
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Recipe not found.");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
