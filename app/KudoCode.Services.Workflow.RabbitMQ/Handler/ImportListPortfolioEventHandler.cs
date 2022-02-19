using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.ImportExcel;
using KudoCode.LogicLayer.Dtos.Portfolios.Inbound;
using KudoCode.Web.Api.Connector;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Core.Services.Workflow.RabbitMQ.Handler
{
	public class CreatePortfolioImportXslEventHandler : EventHandler<CreatePortfolioImportXslEventMessage>
    {
        private readonly Connector _connector;

        public CreatePortfolioImportXslEventHandler(Connector connector)
        {
            _connector = connector;
        }

        public override void Execute()
        {
            var filePaths = Directory.GetFiles(@"C:\Projects\Imports\Portfolios\");

            foreach (var filePath in filePaths)
            {
                Task.Run(() =>
                    _connector.EndPoint.Request<CreateImportXlsDto,int>(new CreateImportXlsDto()
                        {
                            FilePath = filePath,
                            Sheets = new List<string>() {"Report"}
                        }
                    )
                ).Wait(10000);
            }
        }
    }
}