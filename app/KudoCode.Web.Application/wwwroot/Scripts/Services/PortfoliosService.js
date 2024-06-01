define(['navigationService'], function (nav) {

    var Edit = function (id) {
        nav.GoTo("Portfolio","\\Portfolio\\Edit\\" + id);
    };

    return {
        Edit: Edit,
    };
});
