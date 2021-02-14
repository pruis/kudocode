define(['httpCallService', 'navigationService'], function (HttpCall, nav) {

    var Save = function () {

        var data = {
            Id: viewModel.Result.Id(),
            'Name': viewModel.Result.Name(),
            "OpenDate": viewModel.Result.OpenDate()
        };

        HttpCall.Post("Save", "Portfolio", data, function (result) {
        });
    };

    var EditSummary = function (id) {
        nav.GoTo("Summary", "\\PortfolioTransactionsSummary\\Edit\\" + id);
    };

    var EditTransaction = function (portfolioId, id) {
        nav.GoTo("Transaction", "\\PortfolioTransaction\\Edit\\" + id + "\\" + portfolioId);
    };

    return {
        Save: Save,
        EditSummary: EditSummary,
        EditTransaction: EditTransaction
    };
});
