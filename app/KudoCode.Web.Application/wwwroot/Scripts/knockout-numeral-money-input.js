define(['knockout', 'numeral'], function (ko, numeral) {
    ko.bindingHandlers.moneyInput = {
        update: function (element, valueAccessor, allBindingsAccessor) {

            var currency = 'ZAR'; // https://www.currency-iso.org/dam/downloads/lists/list_one.xml

            element.addEventListener('focus', onFocus);
            element.addEventListener('blur', onBlur);

            var value = ko.utils.unwrapObservable(valueAccessor());
            onLoad(element, value);

            function localStringToNumber(s) {
                return Number(String(s).replace(/[^0-9.-]+/g, ""));
            }

            function onFocus(e) {
                var value = e.target.value;
                e.target.value = value ? localStringToNumber(value) : '';
            }

            function onBlur(e) {
                var value = e.target.value;

                var options = {
                    maximumFractionDigits: 2,
                    currency: currency,
                    style: "currency",
                    currencyDisplay: "symbol"
                };

                var x = value
                    ? localStringToNumber(value).toLocaleString(undefined, options)
                    : '';

                e.target.value = x.replace('ZAR', 'R');
            }

            function onLoad(element, value) {

                var options = {
                    maximumFractionDigits: 2,
                    currency: currency,
                    style: "currency",
                    currencyDisplay: "symbol"
                };


                var x = value
                    ? localStringToNumber(value).toLocaleString(undefined, options)
                    : '';

                x = x.replace('ZAR', 'R');

                $(element).val(x);
            }

        }
    };
});

