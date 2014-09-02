function Solve(args) {
    var currentInputElements = args[0].split(" ").map(Number);
    var rows = currentInputElements[0];
    var cols = currentInputElements[1];
    var field = [];
    var count = 1;

    for (var row = 0; row < rows; row++) {
        var currentRow = [];

        for (var col = 0; col < cols; col++) {
            currentRow.push(count++);
        }

        field.push(currentRow);
    }

    currentInputElements = args[1].split(" ").map(Number);
    var pos = { row: currentInputElements[0], col: currentInputElements[1] };
    var moves = [];

    for (var i = 0; i < rows; i++) {
        moves.push(args[i + 2]);
    }

    var movesCount = 0;
    var sum = 0;

    while (true) {
        if (pos.row < 0 || pos.row >= rows || pos.col < 0 || pos.col >= cols) {
            return "out " + sum;
        }
        else if (field[pos.row][pos.col] === 'X') {
            return "lost " + movesCount;
        }
        else {
            sum += field[pos.row][pos.col];
            field[pos.row][pos.col] = 'X';
            movesCount++;

            if (moves[pos.row][pos.col] === 'u') {
                pos.row -= 1;
            }
            else if (moves[pos.row][pos.col] === 'r') {
                pos.col += 1;
            }
            else if (moves[pos.row][pos.col] === 'd') {
                pos.row += 1;
            }
            else {
                pos.col -= 1;
            }
        }
    }
}

var firstTest = [
    "3 4",
    "1 3",
    "lrrd",
    "dlll",
    "rddd"
];

var secondTest = [
    "5 8",
    "0 0",
    "rrrrrrrd",
    "rludulrd",
    "durlddud",
    "urrrldud",
    "ulllllll"
];

var thirdTest = [
    "5 8",
    "0 0",
    "rrrrrrrd",
    "rludulrd",
    "lurlddud",
    "urrrldud",
    "ulllllll"
];

console.log(Solve(firstTest));
console.log(Solve(secondTest));
console.log(Solve(thirdTest));