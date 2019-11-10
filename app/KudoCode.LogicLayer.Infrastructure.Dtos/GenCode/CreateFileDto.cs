using System.Collections.Generic;
using KudoCode.LogicLayer.Infrastructure.Dtos.Requests.Interfaces;

namespace KudoCode.LogicLayer.Infrastructure.Dtos.GenCode
{
    public class CreateFileDto : IApiRequestDto
    {
        public string TemplateName { get; set; }
        public List<string> Parameters { get; set; }
        public string OutputFolder { get; set; }
        public string OutputName { get; set; }
    }

    public class FileDto
    {
        public string FileString { get; set; }
    }
}