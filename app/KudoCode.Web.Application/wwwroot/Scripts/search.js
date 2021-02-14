var binding = (function () {
    "use strict";

    return {
        prepare: function() {
            $("form")[0].reset();
        },

        bind: function (idNumber, person) {
            $("#IDNumber").val(idNumber);
            $("#FirstName").val(person.FirstName);
            $("#Surname").val(person.Surname);
            $("#AddressLine1").val(person.AddressLine1);
            $("#AddressLine2").val(person.AddressLine2);
            $("#AddressSuburb").val(person.AddressSuburb);
            $("#AddressPostCode").val(person.AddressPostCode);
            $("#AddressTownCity").val(person.AddressTownCity);
            $("#AddressProvince").val(person.AddressProvince);
        }
    };
})();


var apicall = (function () {
    "use strict";

    return {
        invoke: function (idNumber, successCallback, failureCallback) {
            var url = "/PeopleLookup/" + idNumber;
            $.get(url, function(response) {
                successCallback(response);
            })
            .error(function() {
                failureCallback();
            });
        }
    };
})();

var search = (function () {
    "use strict";

    return {
        find: function (idNumber) {
            apicall.invoke(idNumber, function (person) {
                binding.prepare();
                binding.bind(idNumber, person);
            }, function () {
                alert("failed to complete person lookup");
            });
        }
    };
})();

;(function () {
    "use strict";

    $("#search-button").on('click', function () {
        search.find($("#idNumber").val());
    });
})();