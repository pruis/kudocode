define(['httpCallService','navigationService'], function (HttpCall, nav) {

    var Save = function () {
        
        HttpCall.PostViewModel("Save", "PortfolioTransaction", function (data) {
            if (data() === undefined || data() === 0)
                return;
            viewModel.Result.Id(data());
        });
    };

    return {
        Save: Save,
    };
});
