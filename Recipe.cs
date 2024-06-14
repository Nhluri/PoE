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
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged();
                }
            }
        }

        public List<Ingredient> Ingredients
        {
            get => ingredients;
            set
            {
                if (ingredients != value)
                {
                    ingredients = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(TotalCalories));
                }
            }
        }

        public List<Step> Steps
        {
            get => steps;
            set
            {
                if (steps != value)
                {
                    steps = value;
                    OnPropertyChanged();
                }
            }
        }

        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            Steps = new List<Step>();
        }

        public int TotalCalories => Ingredients.Sum(ingredient => ingredient.Calories);

        public void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
            OnPropertyChanged(nameof(Ingredients));
            OnPropertyChanged(nameof(TotalCalories));
        }

        public void RemoveIngredient(Ingredient ingredient)
        {
            Ingredients.Remove(ingredient);
            OnPropertyChanged(nameof(Ingredients));
            OnPropertyChanged(nameof(TotalCalories));
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
        protected internal void OnPropertyChanged([CallerMemberName] string propertyName = null)
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
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsCompleted
        {
            get => isCompleted;
            set
            {
                if (isCompleted != value)
                {
                    isCompleted = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
