namespace KudoCode.Infrastructure.CodeGenerator
{
    public class RequestResponsePairSettings
    {
        public string Request { get; set; }
        public string Response { get; set; }
        public string Entity { get; set; }
        public string Folder { get; set; }
        public string ProjectFolder { get; set; }
        public string Bound { get; set; }
        public string Prefix { get; set; }
        public string ServiceDomain { get; private set; } = string.Empty;
        public string ServiceTest { get; private set; } = string.Empty;

        public RequestResponsePairSettings SetService(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                ServiceTest = "";
                ServiceDomain = "";
            }

            ServiceDomain = @$"Services\{name}Service\Domain\";
            ServiceTest = @$"Services\{name}Service\Tests\";
            return this;
        }
    }
}