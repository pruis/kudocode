using System.Collections.Generic;

namespace KudoCode.LogicLayer.Plugin.Redis.Infrastructure
{

	public class RedisContext
    {
        public RedisContext()
        {
            Keys = new List<string>();
        }

        public List<string> Keys { get; }
    }
    
//    public static class Helper
//    {
//        public static string GetKey(string name, object obj)
//        {
//            return $"{name}_{ComputeSha256Hash(obj)}";
//        }
//
//        private static string ComputeSha256Hash(object obj)
//        {
//            using (var sha256Hash = SHA256.Create())
//            {
//                var rawData = JsonConvert.SerializeObject(obj, Formatting.None);
//                var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
//                var builder = new StringBuilder();
//                foreach (var t in bytes)
//                    builder.Append(t.ToString("x2"));
//                return builder.ToString();
//            }
//        }
//    }
}