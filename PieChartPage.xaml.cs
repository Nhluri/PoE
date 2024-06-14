using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace RecipeAppWPF
{
    public partial class PieChartPage : Page
    {
        private List<Recipe> recipes;

        public PieChartPage(List<Recipe> recipes)
        {
            InitializeComponent();
            this.recipes = recipes;
            LoadRecipes();
        }

        private void LoadRecipes()
        {
            RecipeListBox.ItemsSource = recipes.Select(r => r.Name).ToList();
        }

        private void RecipeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RecipeListBox.SelectedItem != null)
            {
                string selectedRecipeName = RecipeListBox.SelectedItem.ToString();
                var selectedRecipe = recipes.FirstOrDefault(r => r.Name == selectedRecipeName);

                if (selectedRecipe != null)
                {
                    SetPieChart(selectedRecipe);
                }
            }
        }

        private void SetPieChart(Recipe recipe)
        {
            var foodGroupCounts = GetFoodGroupCounts(recipe);
            var total = foodGroupCounts.Sum(item => item.Value);

            var chartData = foodGroupCounts
                .Select(g => new PieChartData
                {
                    Key = g.Key,
                    Value = g.Value,
                    Percentage = (double)g.Value / total,
                    Color = GetColorForFoodGroup(g.Key)
                })
                .ToList();

            PieChart.DataContext = chartData;
            PieChart.Visibility = Visibility.Visible;
        }

        private List<KeyValuePair<string, int>> GetFoodGroupCounts(Recipe recipe)
        {
            var foodGroupCounts = recipe.Ingredients
                .GroupBy(i => i.FoodGroup)
                .Select(g => new KeyValuePair<string, int>(g.Key, g.Count()))
                .ToList();

            return foodGroupCounts;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            // Navigate back to the previous page
            NavigationService.GoBack();
        }

        private Brush GetColorForFoodGroup(string foodGroup)
        {
            // Define bright colors for each food group
            switch (foodGroup)
            {
                case "Vegetable": return Brushes.GreenYellow;
                case "Fruits": return Brushes.Orange;
                case "whole Grains": return Brushes.Goldenrod;
                case "Protein": return Brushes.MediumPurple;
                case "Dairy": return Brushes.SkyBlue;
                case "refined grains": return Brushes.PeachPuff;
                case "lamiaceae family": return Brushes.Brown;
                case "spice": return Brushes.Red;
                case "Sweets": return Brushes.Yellow;
                case "FatsAndOils": return Brushes.Blue;
                case "Carbohydrates": return Brushes.Purple;
                case "Starchey": return Brushes.Cyan;
                 default: return Brushes.LightGray;
                    
            }
        }

        private class PieChartData
        {
            public string Key { get; set; }
            public int Value { get; set; }
            public double Percentage { get; set; }
            public Brush Color { get; set; }
        }
    }
}
