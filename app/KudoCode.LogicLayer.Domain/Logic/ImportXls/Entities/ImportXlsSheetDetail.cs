using KudoCode.Contracts.Api;
using KudoCode.Contracts.Api;

namespace KudoCode.LogicLayer.Domain.Logic.ImportXls.Entities
{
    public class ImportXlsSheetDetail : IEntity
    {
        public ImportXlsSheetDetail()
        {
        }

        public int Id { get; set; }
        public int Row { get; set; }
        public string Value { get; set; }
        public int Column { get; set; }
        public int ImportXlsSheetId { get; set; }
        public int ColIndex { get; set; }
        public int RowIndex { get; set; }
    }
}