function Solve(args) {
	var money = parseInt(args[0]);
	var cakes = args.slice(1).map(Number);
	var result = 0;
	var maxSum = 0;

	for (var i = 0; i < 100; i++) {
	    for (var j = 0; j < 100; j++) {
	        for (var k = 0; k < 100; k++) {
	            result = cakes[0] * i + cakes[1] * j + cakes[2] * k;
	            if (result > maxSum && result <= money) {
	                maxSum = result;
	            }

	            result = 0;
	        }
	    }
	}

	return maxSum;
}

var firstTest = [
	'110',
	'13',
	'15',
	'17'
];

var secondTest = [
	'20',
	'11',
	'200',
	'300'
];

var thirdTest = [
	'110',
	'19',
	'29',
	'39'
];

console.log(Solve(firstTest));
console.log(Solve(secondTest));
console.log(Solve(thirdTest));