namespace KudoCode.LogicLayer.Dtos.PortfolioAccounts.OutBound
{
    public class PortfolioAccountResponse
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string Name { get; set; }

        public decimal Units { get; set; }
        public decimal Amount { get; set; }
        public string Date { get; set; }
    }
}