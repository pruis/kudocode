define('httpErrorService', ['underscore'], function (_) {
	"use strict";

	var Handle = function (messages) {
		if (messages === undefined || messages.length === 0)
			return;

		viewModel.Errors([]);
		viewModel.Messages([]);

		_.each(messages, function (message) {
			if (message.Type === 1)
				viewModel.Errors.push(message);
			else
				viewModel.Messages.push(message);
		});
	};

	return {
		Handle: Handle
	};

});