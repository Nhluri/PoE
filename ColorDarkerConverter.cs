using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace RecipeAppWPF
{
    public class ColorDarkerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Color color)
            {
                // Darken the color by reducing each component
                byte r = (byte)(color.R * 0.8);
                byte g = (byte)(color.G * 0.8);
                byte b = (byte)(color.B * 0.8);
                return Color.FromRgb(r, g, b);
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

