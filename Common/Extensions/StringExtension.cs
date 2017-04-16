namespace Common.Extensions
{
    public static class StringExtension
    {
        public static bool IsInteger(this string value)
        {
            int result;
            return int.TryParse(value, out result);
        }
    }
}
