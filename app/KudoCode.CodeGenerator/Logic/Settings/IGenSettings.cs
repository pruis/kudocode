using System.Collections.Generic;

namespace KudoCode.CodeGenerator.Logic.Settings
{
    public interface IGenSettings
    {
        string ProjectFolder { get; set; }
        string Folder { get; set; }
        string Request { get; set; }
        string Entity { get; set; }
        string Response { get; set; }
        string TemplateName { get; set; }
        List<string> Parameters { get; set; }
        string OutputName { get; set; }
        string OutputFolder { get; set; }
    }
}