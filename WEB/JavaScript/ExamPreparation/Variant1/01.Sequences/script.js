function Solve(args) {
    var count = 1;

    args = args.slice(1).map(Number);

    for (var i = 1; i < args.length; i++) {
        if (args[i - 1] > args[i]) {
            count++;
        }
    }

    return count;
}

var firstTest = [
    "7",
    "1",
    "2",
    "-3",
    "4",
    "4",
    "0",
    "1"
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

var thirdTest = [
"9",
"1",
"8",
"8",
"7",
"6",
"5",
"7",
"7",
"6"
];

console.log(Solve(firstTest));
console.log(Solve(secondTest));
console.log(Solve(thirdTest));