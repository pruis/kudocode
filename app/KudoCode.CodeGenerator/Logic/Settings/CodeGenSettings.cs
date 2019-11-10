using System.Collections.Generic;
using KudoCode.CodeGenerator.Service;

namespace KudoCode.CodeGenerator.Logic.Settings
{
    public class CodeGenSettings : IGenSettings
    {
        public CodeGenSettings(RequestResponsePairSettings settings)
        {
            Entity = settings.Entity;
            Folder = settings.Folder;
            Request = settings.Request;
            Response = settings.Response;
            ProjectFolder = settings.ProjectFolder;

        }

        public string ProjectFolder { get; set; }
        public string Folder { get; set; }
        public string Request { get; set; }
        public string Entity { get; set; }
        public string Response { get; set; }
        public string TemplateName { get; set; }
        public List<string> Parameters { get; set; }
        public string OutputName { get; set; }
        public string OutputFolder { get; set; }
    }
    
}