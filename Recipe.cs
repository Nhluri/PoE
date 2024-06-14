using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace RecipeAppWPF
{
    public class Recipe : INotifyPropertyChanged
    {
        private string name;
        private List<Ingredient> ingredients;
        private List<Step> steps;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public List<Ingredient> Ingredients
        {
            get => ingredients;
            set
            {
                ingredients = value;
                OnPropertyChanged();
            }
        }

        public List<Step> Steps
        {
            get => steps;
            set
            {
                steps = value;
                OnPropertyChanged();
            }
        }

        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            Steps = new List<Step>();
        }

        public int CalculateTotalCalories()
        {
            return Ingredients.Sum(ingredient => ingredient.Calories);
        }

        public void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
            OnPropertyChanged(nameof(Ingredients));
        }

        public void RemoveIngredient(Ingredient ingredient)
        {
            Ingredients.Remove(ingredient);
            OnPropertyChanged(nameof(Ingredients));
        }

        public void AddStep(string description)
        {
            Steps.Add(new Step { Description = description });
            OnPropertyChanged(nameof(Steps));
        }

        public void RemoveStep(Step step)
        {
            Steps.Remove(step);
            OnPropertyChanged(nameof(Steps));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Step : INotifyPropertyChanged
    {
        private string description;
        private bool isCompleted;

        public string Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged();
            }
        }

        public bool IsCompleted
        {
            get => isCompleted;
            set
            {
                isCompleted = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
