define(['httpCallService'], function (HttpCall) {

    var Edit = function (id) {
        window.location.href = "\\PortfolioTransactionsConsolidation\\Edit\\" + id;
    };

    return {
        Edit: Edit,
    };
});
