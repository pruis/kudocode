define(['knockout', 'numeral'], function (ko, numeral) {
    ko.bindingHandlers.money = {
        update: function (element, valueAccessor, allBindingsAccessor) {
            var format = allBindingsAccessor().format || "$ 00,000.00";
            var value = ko.utils.unwrapObservable(valueAccessor());
            $(element).text(numeral(value).format(format));
        }
    };
});