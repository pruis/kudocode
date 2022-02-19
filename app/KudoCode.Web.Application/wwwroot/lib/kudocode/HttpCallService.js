define('httpCallService', ['knockout', 'httpErrorService', 'navigationService'], function (ko, HttpError, nav) {
    "use strict";

    //var selfHttpCall = this;

    var CallBackReference = function () {
    };

    var CallBackGeneric = function (data) {
        HttpError.Handle(data.Messages);
        var koData = ko.mapping.fromJS(data.Result, {'ignore': ["__proto__"]});
        CallBackReference(koData);
    };

    var Get = function (action, controller, id, callback) {
        CallBackReference = callback;
        var instance = this;
        self.CallBack = function (data) {
            CallBackGeneric(data);
        };

        var uri = "\\" + action + "\\" + id;
        if (controller !== undefined)
            uri = "\\" + controller + "\\" + action + "\\" + id;
        $.post(uri,
            function (data, status) {
                if (status === "success") {
                    self.CallBack(data);
                }
            });
    };

    var Post = function (action, controller, postData, callback) {
        CallBackReference = callback;
        var instance = this;
        self.CallBack = function (data) {
            CallBackGeneric(data);
        };

        var uri = "\\" + action;
        if (controller !== undefined)
            uri = "\\" + controller + "\\" + action;
        $.post(uri,
            postData,
            function (data, status) {
                //if (status === "success") {
                self.CallBack(data);
                //}
            });
    };

    var PostViewModel = function (action, controller, callback) {
        CallBackReference = callback;
        self.CallBack = function (data) {
            CallBackGeneric(data);
        };

        var unmapped = ko.mapping.toJS(viewModel.Result);
        var uri = "\\" + action;
        if (controller !== undefined)
            uri = "\\" + controller + "\\" + action;
        $.post(uri,
            unmapped,
            function (data, status) {
                if (status === "success") {
                    self.CallBack(data);
                    if (data.Redirect)
                        nav.GoTo(data.Redirect.Title, data.Redirect.ActionValue);
                }
            });
    };

    return {
        Get: Get,
        Post: Post,
        PostViewModel: PostViewModel,
    };

});