using Autofac;
using AutoMapper;
using KudoCode.Contracts.Api;
using KudoCode.Contracts;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace KudoCode.Infrastructure.CodeGenerator.Logic.CodeGen.Handlers.Create
{
    public class UpdateFileDtoWorkerHandler : WorkerHandler<CreateFileDto, FileDto>
    {
        public UpdateFileDtoWorkerHandler(
            IMapper mapper,
            ILifetimeScope scope,
            IWorkerContext<FileDto> context) : base(mapper, scope, context)
        {
        }

        protected override void Execute()
        {
            var templateString = System.IO.File.ReadAllText(Request.OutputFolder + "/" + Request.OutputName);
            var propertyText = string.Empty;//Environment.NewLine;

            foreach (var prop in Request.Properties)
            {
                string status1 = Regex.Replace(prop, @"\s+", " ").Trim();
                var items = status1.Split(" ");
                if (items.Length < 2 || items.Length > 3)
                    continue;

                if (items.Length == 3)
                    propertyText += $"        public {items[0]} {items[1]} {items[2]}" + " { get; set; }" + Environment.NewLine;
                else

                    propertyText += $"        public {items[0]} {items[1]} " + " { get; set; }" + Environment.NewLine;
            }

            if (propertyText.Length > 4)
            {
                var index = templateString.LastIndexOf(Request.Settings.Get("propPlaceIndexString"));
                templateString = templateString.Insert(index, propertyText);
            }

            Context.Result = new FileDto() { FileString = templateString };
        }
    }
}