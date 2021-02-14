define(['knockout'], function (ko) {
    //http://eonasdan.github.io/bootstrap-datetimepicker/Installing/#knockout
    ko.bindingHandlers.dateTimePicker = {
        init: function (element, valueAccessor, allBindingsAccessor) {
            //initialize datepicker with some optional options
            var options = allBindingsAccessor().dateTimePickerOptions || {};

            if (!options.format) {
                if (options.allowTime)
                    options.format = model.Configuration.DateTimeFormat.toUpperCase();
                else
                    options.format = model.Configuration.DateFormat.toUpperCase();
            }
            delete options['allowTime'];

            $(element).datetimepicker(options);
            var v = allBindingsAccessor().value();
            //when a user changes the date, update the view model
            ko.utils.registerEventHandler(element, "dp.change", function (event) {
                if (ko.isObservable(allBindingsAccessor().value)) {
                    if (event.date != null && !(event.date instanceof Date)) {
                        allBindingsAccessor().value(event.date.format(options.format));
                    } else {
                        allBindingsAccessor().value(event.date);
                    }
                }
            });

            ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
                var picker = $(element).data("DateTimePicker");
                if (picker) {
                    picker.destroy();
                }
            });
        },
        update: function (element, valueAccessor, allBindings, viewModel, bindingContext) {

        }
    };
});