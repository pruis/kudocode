define(['httpCallService'], function (HttpCall) {

	var Save = function () {
		HttpCall.PostViewModel("Save", "LeadScheduledActivity", function (data) {
			if (data() === undefined || data() === 0)
				return;
			viewModel.Result.Id(data());
		});
	};

	return {
		Save: Save
	};
});
