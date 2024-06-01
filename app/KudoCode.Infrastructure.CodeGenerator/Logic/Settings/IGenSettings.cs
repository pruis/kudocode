using KudoCode.Contracts;
using System.Collections.Generic;

namespace KudoCode.Infrastructure.CodeGenerator
{
    public interface IGenSettings
    {
        string TemplateName { get; set; }
        List<string> Parameters { get; set; }
        string OutputName { get; set; }
        string OutputFolder { get; set; }
        List<string> Properties { get; set; }
        string TemplatePath { get; set; }
        RequestResponsePairSettings Settings { get; set; }
    }
}