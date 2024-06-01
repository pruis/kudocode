using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Autofac;
using CodeGenerator.Service;
using KudoCode.Contracts.Api;
using KudoCode.Infrastructure.CodeGenerator;
using System.Xml.Linq;
using KudoCode.Contracts;

namespace CodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {


            // c:\temp\UML.xml
            var doc = XDocument.Load(@"C:\Users\Pruis\Downloads\Category.drawio (1).xml");

            var types = new List<string>()
                    {
                    {"Request"},
                    {"GenericTable"},
                    {"ViewModel"},
                    {"AutoMapper"},
                    {"VH"},
                    {"WH"},
                    {"Response"},
                    {"Entity"},
                    };

            foreach (var type in types)
            {
                var responses_xml = doc.Descendants("mxCell").Where(a => a.Attribute("value") != null).Where(a => a.Attribute("value").Value.EndsWith(type)).ToList();
                foreach (var response_xml in responses_xml)
                {
                    var parentId = response_xml.Attribute("id").Value;
                    var properties = doc.Descendants("mxCell").Where(a => a.Attribute("parent") != null).Where(a => a.Attribute("parent").Value.Equals(parentId)).Select(a => a.Attribute("value").Value).ToList();

                    var settings = new RequestResponsePairSettings()
                    {

                    };

                    var service = "Budget";
                    string path = @"C:\Projects\kudocode.budget.pvt";
                    settings.Set("ProjectFolder", @$"{path}\app");
                    settings.Set("Service", service);


                    if (response_xml.Attribute("value").Value.Split(" ").Length == 3)
                    {
                        var request = response_xml.Attribute("value").Value.Split(" ").First().Trim();
                        var entity = response_xml.Attribute("value").Value.Split(" ")[1].Trim();

                        var reqList = new List<string>() { "Save", "Delete", "List", "Get" };
                        var templateName = type;
                        if (type == "WH" && reqList.Contains(request))
                            templateName = $"{request}{type}";


                        var folderEntity = string.Empty;

                        if (entity.EndsWith('y'))
                            folderEntity = entity.Substring(0, entity.Length - 1) + "ies";
                        else if (entity.EndsWith('s'))
                            folderEntity = entity + "es";
                        else
                            folderEntity = $"{entity}s";



                        settings.Set("FolderEntity", $"{folderEntity}s");
                        settings.Set("Response", $"{request}{entity}Response");
                        settings.Set("Entity", entity);
                        settings.Set("Request", request);

                        settings.Set("DirViewModel", $@"<%projectfolder%>\KudoCode.LogicLayer.Dtos\{folderEntity}");
                        settings.Set("DirDto", $@"<%projectfolder%>\KudoCode.LogicLayer.Dtos\{folderEntity}\RequestReponse");
                        settings.Set("DirUnitTest", $@"<%projectfolder%>\APIs\{service}Service\Tests\KudoCode.Test.Unit\{folderEntity}\{request}");
                        settings.Set("DirHandler", $@"<%projectfolder%>\APIs\{service}Service\Domain\KudoCode.LogicLayer.Domain\Logic\{folderEntity}\Handlers\{request}");
                        settings.Set("DirEntity", $@"<%projectfolder%>\APIs\{service}Service\Domain\KudoCode.LogicLayer.Domain\Logic\{folderEntity}\Entities");
                        settings.Set("DirAutoMapper", $@"<%projectfolder%>\APIs\{service}Service\Domain\KudoCode.LogicLayer.Domain\Logic\{folderEntity}\AutoMapper");
                        settings.Set("DirGenericTable", $@"<%projectfolder%>\KudoCode.Web.Blazor.Application\Pages");
                        settings.Set("propPlaceIndexString", "\r\n    }");

                        settings.Parameters = new List<string>()
                        {
                            $"<%request%>:{settings.Get("Request")}",
                            $"<%entity%>:{settings.Get("Entity")}",
                            $"<%response%>:{settings.Get("Response")}",
                            $"<%service%>:{service}",
                            $"<%type%>:Worker",
                        };


                        if (System.IO.File.Exists($@"Logic\Templates\{request + templateName}.txt"))
                            ProgramHelpers.Go(settings, new List<string>() { { request + templateName } }, properties);
                        else
                            ProgramHelpers.Go(settings, new List<string>() { { templateName } }, properties);

                        if (System.IO.File.Exists($@"Logic\Templates\{request}WorkerUnitTest.txt"))
                            ProgramHelpers.Go(settings, new List<string>() { { request + "WorkerUnitTest" } }, new List<string>());
                        else
                            ProgramHelpers.Go(settings, new List<string>() { { "HandlerTest" } }, new List<string>());
                        ProgramHelpers.Go(settings, new List<string>() { { "ValidationUnitTest" } }, new List<string>());
                    }

                    else if (response_xml.Attribute("value").Value.Split(" ").Length == 2)
                    {
                        var entity = response_xml.Attribute("value").Value.Split(" ")[0].Trim();

                        var folderEntity = string.Empty;

                        if (entity.EndsWith('y'))
                            folderEntity = entity.Substring(0, entity.Length - 1) + "ies";
                        else if (entity.EndsWith('s'))
                            folderEntity = entity + "es";
                        else
                            folderEntity = $"{entity}s";


                        settings.Set("FolderEntity", $"{folderEntity}s");
                        settings.Set("Entity", entity);
                        settings.Set("DirViewModel", $@"<%projectfolder%>\KudoCode.LogicLayer.Dtos\{folderEntity}");
                        settings.Set("DirDto", $@"<%projectfolder%>\KudoCode.LogicLayer.Dtos\{folderEntity}\RequestReponse");
                        settings.Set("DirEntity", $@"<%projectfolder%>\APIs\{service}Service\Domain\KudoCode.LogicLayer.Domain\Logic\{folderEntity}\Entities");
                        settings.Set("DirAutoMapper", $@"<%projectfolder%>\APIs\{service}Service\Domain\KudoCode.LogicLayer.Domain\Logic\{folderEntity}\AutoMapper");
                        settings.Set("DirGenericTable", $@"<%projectfolder%>\KudoCode.Web.Blazor.Application\Pages");
                        settings.Set("propPlaceIndexString", "\r\n    }");

                        settings.Parameters = new List<string>()
                        {
                            $"<%request%>:{settings.Get("Request")}",
                            $"<%entity%>:{settings.Get("Entity")}",
                            $"<%response%>:{settings.Get("Response")}",
                            $"<%service%>:{service}",
                            $"<%type%>:Worker",
                        };


                        ProgramHelpers.Go(settings, new List<string>() { { type } }, properties);
                    }
                }
            }

            return;

            //var entity = "Category";
            //var requests = new List<string>() { "Save", "Delete", "List", "Get" };

            //foreach (var req in requests)
            //{
            //    var s = new List<string>()
            //        {
            //        {"GenericTable"},
            //        {"AutoMapper"},
            //        {"Entity"},
            //        {"Request"},
            //        {"ViewModel"},

            //        {"ValidationHandler"},
            //        {"ValidationUnitTest"},

            //        {$"{req}Handler"},
            //        {$"{req}WorkerUnitTest"},
            //        };

            //    if (req.Equals("List"))
            //        s.Add("ListResponse");
            //    else
            //        s.Add("Response");
            //    //ProgramHelpers.Go("Budget", req, entity, s);
            //}


            return;
            //ProgramHelpers.Go("Budget", "UpdateAccount", "TwitterTweetInsight",
            //    new Dictionary<string, bool>()
            //    {
            //        {"Entity", false},
            //        {"Request"},
            //        {"Response"},
            //        {"ViewModel", false},

            //        {"AuthorizationHandler", false},
            //        {"AuthorizationUnitTest", false},

            //        {"ValidationHandler"},
            //        {"ValidationUnitTest"},

            //        {"CommandHandler"},
            //        {"QueryHandler", false},

            //        {"WorkerUnitTest"},
            //    }
            //);
        }
    }
}