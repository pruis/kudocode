using KudoCode.Contracts;
using System.Collections.Generic;

namespace KudoCode.Infrastructure.CodeGenerator
{
    public class CodeGenSettings : IGenSettings
    {
        public CodeGenSettings()
        {
        }
        public string TemplateName { get; set; }
        public List<string> Parameters { get; set; }
        public string OutputName { get; set; }
        public string OutputFolder { get; set; }
        public List<string> Properties { get; set; }
        public string TemplatePath { get; set; }
       public RequestResponsePairSettings Settings { get; set; }
    }

}