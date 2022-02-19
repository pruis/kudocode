using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace KudoCode.Helpers
{
    public static class StringExt
    {
        public static bool IsNumeric(this string text)
        {
            double test;
            return double.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out test);
        }
    }

    public static class Extentions
    {
        public static string CompareProperties(this object aObject, object bObject, string exclude = null)
        {
            var aList = new Dictionary<string, string>();
            var bList = new Dictionary<string, string>();

            GetProperties(aObject, aList);
            GetProperties(bObject, bList);

            var compare = aList
                .Where(entry => getValue(bList, entry) != entry.Value && getValue(bList, entry) != "skip")
                .ToDictionary(entry => entry.Key, entry => entry.Value);

            if (exclude != null)
                foreach (var s in exclude.Split(','))
                    compare.Remove(s);

            return compare.Any()
                ? compare.Select(a => a.Key).Aggregate((i, j) => i + $"{i} does not match, " + j)
                : null;
        }

        private static string getValue(Dictionary<string, string> bList, KeyValuePair<string, string> entry)
        {
            string value = string.Empty;
            var test = bList.TryGetValue(entry.Key, out value);

            if (test == false)
                return "skip";

            return value;
        }

        private static void GetProperties(object bObject, Dictionary<string, string> aList)
        {
            Type myType = bObject.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            foreach (PropertyInfo prop in props)
            {
                var value = string.Empty;

                if (prop.GetValue(bObject, null) != null)
                    value = prop.GetValue(bObject, null).ToString();

                aList.Add(prop.Name, value);
            }
        }

        public static bool IsType<T>(this object entity)
        {
            if (entity is T)
                return true;

            //var isType = entity.GetType().GetInterfaces().Any(x =>
            //    x.IsGenericType &&
            //    x.GetGenericTypeDefinition() == typeof(T));

            //   return isType;

            return false;
        }

        public static bool IsType(this object entity, Type typeA, Type typeB)
        {
            TypeInfo a = entity.GetType().GetTypeInfo();
            TypeInfo b = typeA.GetTypeInfo();
            TypeInfo c = typeB.GetTypeInfo();


            var xxx = entity.GetType();
            bool isType = entity.GetType().GetInterfaces().Any(x =>
                x.IsGenericType &&
                x.GetGenericTypeDefinition() == typeB);
            return isType;
        }


        public static DateTime ToDate(this String dateString)
        {
            //string format = "dd-MM-yyyy HH:mm";
            DateTime dateTime;
            DateTime.TryParse(dateString, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out dateTime);

            return dateTime;
        }
    }
}