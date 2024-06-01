using System.Collections.Generic;

namespace KudoCode.Contracts
{
    public class RequestResponsePairSettings
    {
        public Dictionary<string, string> Settings { get; set; }
        public List<string> Parameters { get; set; }
        public RequestResponsePairSettings()
        {
            Settings = new Dictionary<string, string>();
        }

        public string Get(string key)
        {
            string x;
            if (Settings.TryGetValue(key, out x))
                return x;

            return "";
        }

        public void Set(string key, string value)
        {
            Settings.Add(key, value);
        }

    }

    public class CreateFileDto : IApiRequestDto
    {
        public CreateFileDto()
        {
            Properties = new List<string>();
            Settings = new RequestResponsePairSettings { };
        }

        public string TemplateName { get; set; }
        public List<string> Parameters { get; set; }
        public string OutputFolder { get; set; }
        public string OutputName { get; set; }
        public List<string> Properties { get; set; }
        public string TemplatePath { get; set; }
        public RequestResponsePairSettings Settings { get; set; }
    }

    //public class UpdateFileDto : IApiRequestDto
    //{
    //    public string TemplateName { get; set; }
    //    public List<string> Parameters { get; set; }
    //    public string OutputFolder { get; set; }
    //    public string OutputName { get; set; }
    //}

    public class FileDto
    {
        public string FileString { get; set; }
    }
}