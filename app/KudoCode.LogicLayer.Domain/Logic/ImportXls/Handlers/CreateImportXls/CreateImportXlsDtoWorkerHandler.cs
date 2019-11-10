using System;
using System.Globalization;
using System.IO;
using System.Linq;
using Autofac;
using AutoMapper;
using KudoCode.LogicLayer.Domain.Logic.ImportXls.Entities;
using KudoCode.LogicLayer.Dtos.ImportExcel;
using KudoCode.LogicLayer.Infrastructure;
using KudoCode.LogicLayer.Infrastructure.Domain.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;
using log4net;
using Microsoft.Extensions.Configuration;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;

namespace KudoCode.LogicLayer.Domain.Logic.ImportXls.Handlers.CreateImportXls
{
    public class CreateImportXlsDtoWorkerHandler
        : CommandHandler<CreateImportXlsDto, ImportXlsDocument, ImportXlsPipelineResponse>
    {
        private readonly ILog _logger;
        private readonly IConfiguration _configuration;

        public CreateImportXlsDtoWorkerHandler(
            IMapper mapper,
            IRepository repository,
            ILog logger,
            ILifetimeScope scope,
            IConfiguration configuration,
            IWorkerContext<ImportXlsPipelineResponse> context) : base(mapper, repository, scope, context)
        {
            _logger = logger;
            _configuration = configuration;
        }

        protected override void GetEntity()
        {
            Entity = new ImportXlsDocument();
        }

        protected override void Execute()
        {
            try
            {
                using (var fs = new FileStream(Request.FilePath, FileMode.Open, FileAccess.Read))
                {
                    IWorkbook book = new HSSFWorkbook(fs);
                    Entity.Name = Path.GetFileName(Request.FilePath);

                    foreach (var sheetName in Request.Sheets)
                    {
                        var sheet = book.GetSheet(sheetName);
                        Entity.Sheets.Add(new ImportXlsSheet(sheetName));

                        for (var r = 0; r < sheet.LastRowNum; r++)
                        {
                            var row = sheet.GetRow(r);

                            for (var c = 0; c < row.LastCellNum; c++)
                            {
                                var cell = row.GetCell(c);

                                if (cell != null
                                    //&& !string.IsNullOrEmpty(cell.ToString().Trim())
                                    //&& !cell.ToString().StartsWith("=" )
                                )
                                    Entity.Sheets.Last().Details.Add(new ImportXlsSheetDetail()
                                    {
                                        Column = c,
                                        Row = r,
                                        Value = GetCellValue(cell).Trim(),
                                    });
                            }
                        }
                    }
                }


                using (var scope =
                    ApplicationContext.Container.BeginLifetimeScope(
                        $"CreateImportXlsDtoWorkerHandler_scope_{Guid.NewGuid()}"))
                {
                    var dbContext = scope.Resolve<IRepository>();
                    {
                        Entity.Id = 0;
                        dbContext.Save(Entity);
                        dbContext.SaveChanges();
                        Context.Result = new ImportXlsPipelineResponse()
                        {
                            ImportXlsId = Entity.Id
                        };
                    }
                }
            }
            catch (Exception e)
            {
                _logger.Fatal($"{this.GetType().Name}", e);
                Context.AddMessage("E6",
                    $" {this.GetType().Name} Unable to create staging from import Sheet:{Request.Sheets} - File:{Request.FilePath}");
                //Debugger.Break();
            }
        }

        private string GetCellValue(ICell cell)
        {
            var cellValue = string.Empty;
            try
            {
                switch (cell.CellType)
                {
                    case CellType.Blank:
                        cellValue = string.Empty;
                        break;
                    case CellType.Boolean:
                        cellValue = cell.BooleanCellValue.ToString();
                        break;
                    case CellType.String:
                        cellValue = cell.StringCellValue;
                        break;
                    case CellType.Numeric:
                        cellValue = DateUtil.IsCellDateFormatted(cell)
                            ? cell.DateCellValue.ToString(_configuration["DateTimeFormat"])
                            : cell.NumericCellValue.ToString(CultureInfo.InvariantCulture);

                        break;
                    case CellType.Formula:
                        switch (cell.CachedFormulaResultType)
                        {
                            case CellType.Blank:
                                cellValue = string.Empty;
                                break;
                            case CellType.String:
                                cellValue = cell.StringCellValue;
                                break;
                            case CellType.Boolean:
                                cellValue = cell.BooleanCellValue.ToString();
                                break;
                            case CellType.Numeric:
                                cellValue = DateUtil.IsCellDateFormatted(cell)
                                    ? cell.DateCellValue.ToString(_configuration["DateTimeFormat"])
                                    : cell.NumericCellValue.ToString(CultureInfo.InvariantCulture);

                                break;
                        }

                        break;
                    default:
                        cellValue = cell.StringCellValue;
                        break;
                }
            }
            catch (Exception e)
            {
                _logger.Warn($"{this.GetType().Name} unable tp parse cell ", e);
                Console.WriteLine(e);
            }

            return cellValue;
        }
    }
}