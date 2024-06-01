define(['knockout', 'komapping', 'navigationService'], function (ko, komapping, nav) {
    ko.mapping = komapping;
    var Init = function (model, elementId, controller) {

        var vm = ko.mapping.fromJS(model, {'ignore': ["__proto__"]});
        var element = $("#" + elementId)[0];

        vm.Back = function () {
            nav.GoBack();
        };

        vm.GoTo = function (title, uri) {
            nav.GoTo(title, uri);
        };

        ko.cleanNode(element);
        ko.applyBindings(vm, element);

        return vm;
        //**
    };

    return {Init: Init};
});

