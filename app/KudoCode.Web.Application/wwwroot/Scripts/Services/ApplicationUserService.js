define(['httpCallService'], function (HttpCall) {


	var Register = function () {
		HttpCall.PostViewModel("Register", "Authentication", function (data) {
			if (data() === undefined || data() === 0)
				return;
			viewModel.Result.Id(data());
		});
	};

	var Login = function () {
		HttpCall.PostViewModel('LoginAction', 'Authentication', function (data) {
			debugger;
			if (data() === undefined || data() === 0)
				return;
		});
	};

	return {
		Register: Register,
		Login: Login
	};

});