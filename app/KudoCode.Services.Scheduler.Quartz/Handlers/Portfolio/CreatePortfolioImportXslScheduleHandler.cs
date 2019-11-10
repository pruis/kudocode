using System.Collections.Generic;
using System.IO;
using KudoCode.LogicLayer.Dtos.ImportExcel;
using KudoCode.Services.Scheduler.Quartz.Infrastructure.Interfaces;
using KudoCode.Services.Scheduler.Quartz.Schedules;
using KudoCode.Services.Scheduler.Quartz.Infrastructure;
using KudoCode.Web.Api.Connector;

namespace KudoCode.Services.Scheduler.Quartz.Handlers.Portfolio
{
    public class CreatePortfolioImportXslScheduleHandler : ScheduleHandler
        //, IScheduleHandler<EveryTenMinSchedule>
        //, IScheduleHandler<EveryMinSchedule>
    {
        private readonly Connector _connector;

        public CreatePortfolioImportXslScheduleHandler(Connector connector)
        {
            _connector = connector;
        }

        protected override void Action()
        {
            string[] filePaths = Directory.GetFiles(@"C:\Projects\Imports\Portfolios\");


            foreach (var filePath in filePaths)
            {
                var response = _connector.EndPoint.Request<CreateImportXlsDto, int>(new CreateImportXlsDto()
                    {
                        FilePath = filePath,
                        Sheets = new List<string>() {"Report"}
                    }
                );

                var x = response.Result;
            }
        }
    }
}