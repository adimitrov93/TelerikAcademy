// This code is so ugly written, i'm very ashamed, but i simulate exam and I don't make it beautifull.

function Solve(args) {
    var currentLineElements = args[0].split(" ");
    var rows = currentLineElements[0];
    var cols = currentLineElements[1];
    var numberOfJumps = currentLineElements[2];
    currentLineElements = args[1].split(" ").map(Number);
    var pos = { row: currentLineElements[0], col: currentLineElements[1] };
    var field = [];
    var count = 1;

    for (var row = 0; row < rows; row++) {
        var currentRow = [];

        for (var col = 0; col < cols; col++) {
            currentRow.push(count++);
        }

        field.push(currentRow);
    }

    var jumps = [];

    for (var i = 0; i < numberOfJumps; i++) {
        currentLineElements = args[i + 2].split(" ").map(Number);
        var jump = { row: currentLineElements[0], col: currentLineElements[1] };
        jumps.push(jump);
    }

    var sum = 0;
    var JumpsCount = 0;
    var currentJump = 0;

    while (true) {
        if (pos.row < 0 || pos.row >= rows || pos.col < 0 || pos.col >= cols) {
            return "escaped " + sum;
        }
        else if (field[pos.row][pos.col] === 'X') {
            return "caught " + JumpsCount;
        }
        else {
            sum += field[pos.row][pos.col];
            field[pos.row][pos.col] = "X";
            JumpsCount++;
            pos.row += jumps[currentJump].row;
            pos.col += jumps[currentJump].col;

            currentJump++;

            if (currentJump >= jumps.length) {
                currentJump = 0;
            }
        }
    }
}

var firstTest = [
"6 7 3",
"0 0",
"2 2",
"-2 2",
"3 -1"
];

var secondTest = [
"4 4 2",
"0 0",
"-2 2",
"-2 -2"
];

console.log(Solve(firstTest));
console.log(Solve(secondTest));