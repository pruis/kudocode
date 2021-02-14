define(['httpCallService'], function (HttpCall) {

	var Save = function () {
		HttpCall.PostViewModel("Save", "Lead", function (data) {
			if (data() === undefined || data() === 0)
				return;
			viewModel.Result.Id(data());
		});
	};

	var EditActivity = function (id, leadId) {
		window.location.href = "\\LeadScheduledActivity\\Edit\\" + id + "\\" + leadId;
	};

	return {
		Save: Save,
		EditActivity: EditActivity
	};
});
