using System.Collections.Generic;
using System.Windows;

namespace RecipeAppWPF
{
    public partial class MainWindow : Window
    {
        public static List<Recipe> Recipes { get; set; } = new List<Recipe>();

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new HomePage());
        }
    }
}


