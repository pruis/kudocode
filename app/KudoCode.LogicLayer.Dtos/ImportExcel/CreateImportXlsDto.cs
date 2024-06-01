using KudoCode.Contracts;
using System.Collections.Generic;

namespace KudoCode.LogicLayer.Dtos.ImportExcel
{
	//    public class CreatePortfolioTransactionsSummaryStg
	//    {
	//        public int DocumentId { get; set; }
	//    }
	//
	//    public class CreatePortfolioStg
	//    {
	//        public int DocumentId { get; set; }
	//    }


	public class CreateImportXlsDto : IApiRequestDto
    {
        public string FilePath { get; set; }
        public List<string> Sheets { get; set; }
    }


    public class ImportXlsPipelineResponse : IExecutionPipelineHandlerResponse
    {
        public int ImportXlsId { get; set; }
        public int PortfolioId { get; set; }
        public int PortfolioTransactionsSummaryId { get; set; }
    }
}