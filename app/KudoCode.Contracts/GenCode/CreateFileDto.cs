using System.Collections.Generic;

namespace KudoCode.Contracts
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