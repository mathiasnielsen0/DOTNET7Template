namespace Core.Extensions;

public static class StringExtensions
{
    public static string RemoveController(this string s)
    {
        return s.Replace("Controller", "");
    }
}