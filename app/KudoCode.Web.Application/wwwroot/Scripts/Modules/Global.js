define('global', [
	'jquery',
	'knockout',
	'komapping',
	'underscore'
], function ($, ko, komapping, _) {
	ko.mapping = komapping;
	return result =
		{
			$: $,
			ko: ko,
			_: _
		};
});
