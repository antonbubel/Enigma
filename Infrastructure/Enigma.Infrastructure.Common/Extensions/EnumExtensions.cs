namespace Enigma.Infrastructure.Common.Extensions
{
    using System;
    using System.Linq;
    using System.ComponentModel;

    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var descriptionAttibute = value.GetType().GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .FirstOrDefault() as DescriptionAttribute;

            return descriptionAttibute?.Description;
        }

        public static TEnum DescriptionToEnum<TEnum>(this string value)
            where TEnum : struct, IConvertible
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException($"{nameof(TEnum)} must be an enumerated type");
            }

            var enumValue = Enum.GetValues(typeof(TEnum)).Cast<TEnum>()
                .FirstOrDefault(enumItem => GetDescription(enumItem as Enum) == value);

            return enumValue;
        }
    }
}
