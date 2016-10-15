namespace Bjss.ProductBasket.Core.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullEmptyOrWhiteSpace(this string source)
        {
            return string.IsNullOrWhiteSpace(source) || string.Empty == source;
        }

        public static string FormatWith(this string format, params object[] args)
        {
            return !string.IsNullOrEmpty(format) ? string.Format(format, args) : format;
        }
    }
}
