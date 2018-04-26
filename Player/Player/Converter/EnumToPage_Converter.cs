using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Player
{
    public class EnumToPage_Converter : MarkupExtension, IValueConverter
    {
        public static EnumToPage_Converter Instance = null;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((ApplicationPages)value)
            {
                case ApplicationPages.first:
                    return new FirstPage();

                case ApplicationPages.VideoPlayer:
                    return new VideoDisplay();
                case ApplicationPages.Settings:
                    return new Settings_Controls();

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Instance = new EnumToPage_Converter();
        }
    }
}
