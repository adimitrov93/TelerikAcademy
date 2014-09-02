function Solve(args) {
    args = args.slice(1).map(Number);
    var maxSum = -2000000;
    var currentSum = 0;

    for (var i = 0; i < args.length; i++) {
        for (var j = i; j < args.length; j++) {
            currentSum += args[j];

            if (currentSum > maxSum) {
                maxSum = currentSum;
            }
        }

        currentSum = 0;
    }

    return maxSum;
}

var firstTest = [
    "8",
    "1",
    "6",
    "-9",
    "4",
    "4",
    "-2",
    "10",
    "-1"
];

var secondTest = [
    "6",
    "1",
    "3",
    "-5",
    "8",
    "7",
    "-6"
];

console.log(Solve(firstTest));
console.log(Solve(secondTest));