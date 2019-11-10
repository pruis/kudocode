using System;
using System.Globalization;
using System.Linq;

namespace KudoCode.Helpers
{
    public static class AutoMapperHelpers
    {
        public static decimal ToDecimalInvariant(this string input)
        {
            return decimal.Parse(input, NumberStyles.Any, CultureInfo.InvariantCulture);
        }

        public static string ToStringInvariant(this decimal input)
        {
            return input.ToString(CultureInfo.InvariantCulture);
        }

        public static string ToDecimal(this string input, string format)
        {
            var d = decimal.Parse(input, NumberStyles.Any, CultureInfo.InvariantCulture);
            return d.ToString(format, CultureInfo.InvariantCulture);
        }
    }

    public static class StaticHelpers
    {
        //TODO unit test
        public static Type GetBusinessDtoType(string typeName)
        {
            if (typeName.ToLower().Contains("system.int32"))
                return typeof(int);

            var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => a.FullName.Contains(".Dtos")).ToList();

            foreach (var assembly in assemblies)
            {
                var t = assembly.GetType(typeName, false);
                if (t != null)
                    return t;
            }

            throw new ArgumentException(
                "Type " + typeName + " doesn't exist in the current app domain");
        }
    }
}