define(['navigationService'], function (nav) {

    var Edit = function (id) {
        nav.GoTo("Summary", "\\PortfolioTransactionsSummary\\Edit\\" + id);
    };

    return {
        Edit: Edit,
    };
});
