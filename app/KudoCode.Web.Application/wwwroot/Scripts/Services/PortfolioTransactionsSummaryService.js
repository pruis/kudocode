define(['httpCallService'], function (HttpCall) {

    var Save = function () {
        HttpCall.PostViewModel("Save", "PortfolioTransactionsSummary", function (data) {
            if (data() === undefined || data() === 0)
                return;
            viewModel.Result.Id(data());
        });
    };

    var GoToSummaries = function (portfolioId) {
        window.location.href = "\\PortfolioTransactionsSummaries\\Index\\" + portfolioId;
    };

    return {
        Save: Save,
        GoToSummaries: GoToSummaries,
    };
});
