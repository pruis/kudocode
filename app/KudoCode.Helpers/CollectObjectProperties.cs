//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//
//namespace KudoCode.Helpers
//{
//    public class CollectObjectProperties
//    {
//        public List<string> Names { get; set; }
//
//        public List<string> ComplexPropertyInfo(object obj, string parentName = "")
//        {
//            foreach (var property in obj.GetType().GetProperties())
//            {
//                //for value types
//                if (property.PropertyType.IsPrimitive || property.PropertyType.IsValueType ||
//                    property.PropertyType == typeof(string))
//                {
//                }
//                //for complex types
//                else if (property.PropertyType.IsClass && !typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
//                {
//                    AddToList(property.Name, parentName);
//                    var propName = property.Name;
//                    if (!string.IsNullOrEmpty(parentName))
//                        propName = $"{parentName}.{propName}";
//                    var range = ComplexPropertyInfo(property.GetValue(obj), propName);
//                    Names = Names.Union(range).ToList();
//                }
//                //for Enumerables
//                else
//                {
//                    var enumerablePropObj1 = property.GetValue(obj) as IEnumerable;
//
//                    if (enumerablePropObj1 == null)
//                    {
//                        continue;
//                    }
//
//                    AddToList(property.Name, parentName);
//                    var objList = enumerablePropObj1.GetEnumerator();
//
//                    while (objList.MoveNext())
//                    {
//                        //objList.MoveNext();
//                        var propName = property.Name;
//                        if (!string.IsNullOrEmpty(parentName))
//                            propName = $"{parentName}.{propName}";
//                        Names.AddRange(ComplexPropertyInfo(objList.Current, propName));
//                    }
//                }
//            }
//
//            return Names;
//        }
//
//        private void AddToList(string name, string parentName)
//        {
//            var propName = name;
//            if (!string.IsNullOrEmpty(parentName))
//                propName = $"{parentName}.{propName}";
//
//            if (!Names.Any(a => a.Equals(propName)))
//                Names.Add(propName);
//        }
//    }
//}