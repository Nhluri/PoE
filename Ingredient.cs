using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RecipeAppWPF
{
    public class Ingredient : INotifyPropertyChanged
    {
        private string name;
        private double quantity;
        private string unit;
        private int calories;
        private string foodGroup;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public double Quantity
        {
            get => quantity;
            set
            {
                quantity = value;
                OnPropertyChanged();
            }
        }

        public string Unit
        {
            get => unit;
            set
            {
                unit = value;
                OnPropertyChanged();
            }
        }

        public int Calories
        {
            get => calories;
            set
            {
                calories = value;
                OnPropertyChanged();
            }
        }

        public string FoodGroup
        {
            get => foodGroup;
            set
            {
                foodGroup = value;
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