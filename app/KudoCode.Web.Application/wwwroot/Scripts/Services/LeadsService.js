define(['httpCallService'], function (HttpCall) {


	var Search = function () {
		HttpCall.Post("SearchAction", "Leads", { 'Email': viewModel.Result.SearchText() }, function (data) {
			viewModel.Result.Leads(data());
		});
	};

	var Edit = function (id) {
		window.location.href = "\\Lead\\Edit\\" + id;
	};

	//viewModel.LeadsId = function (id) {
	//	return "leads_" + id;
	//}

	return {
		Search: Search,
		Edit: Edit
	};
});