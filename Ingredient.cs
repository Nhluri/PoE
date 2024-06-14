
using System.ComponentModel;
using System.Runtime.CompilerServices;

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
            if (name != value)
            {
                name = value;
                OnPropertyChanged();
            }
        }
    }

    public double Quantity
    {
        get => quantity;
        set
        {
            if (quantity != value)
            {
                quantity = value;
                OnPropertyChanged();
            }
        }
    }

    public string Unit
    {
        get => unit;
        set
        {
            if (unit != value)
            {
                unit = value;
                OnPropertyChanged();
            }
        }
    }

    public int Calories
    {
        get => calories;
        set
        {
            if (calories != value)
            {
                calories = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Calories));
            }
        }
    }

    public string FoodGroup
    {
        get => foodGroup;
        set
        {
            if (foodGroup != value)
            {
                foodGroup = value;
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
