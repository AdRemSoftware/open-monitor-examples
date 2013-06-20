//Get current forex quotes
'use strict';

var debug = false;

var page = require('webpage').create(),
	url = 'http://www.investing.com/quotes/';

if (debug) {
	page.onConsoleMessage = function (msg) {
		console.log(msg);
	};

	page.onError = function (msg, trace) {
		console.log(msg);
		trace.forEach(function (item) {
			console.log('  ', item.file, ':', item.line);
		})
	};
}

function processPage() {
	var result = {"counters": {}}, rows = document.querySelectorAll('#cr1 tbody tr');

	Array.prototype.forEach.call(rows, function (row) {
		var columns = row.querySelectorAll('td'),
			counter = columns[1].textContent + ' x10,000',//NC doesn't yet support floating numbers in counters
			value = Number(columns[2].textContent) * 10000;

		result.counters[counter] = value;
	});
	return result;
}

page.open(url, function (status) {
	var data = page.evaluate(processPage);
	debug ? console.log(JSON.stringify(data, undefined, 2)) : console.log(JSON.stringify(data)); //print to standard output
	phantom.exit();
});