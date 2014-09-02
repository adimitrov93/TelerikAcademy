function Solve(args) {
    var currentInput = args[0].split(' ');
    var rows = parseInt(currentInput[0]);
    var cols = parseInt(currentInput[1]);
    var pos = {
        row: rows - 1,
        col: cols - 1
    };

    var moves = args.slice(1);

    var directions = {
        '1': {
            row: -2,
            col: 1
        },
        '2': {
            row: -1,
            col: 2
        },
        '3': {
            row: 1,
            col: 2
        },
        '4': {
            row: 2,
            col: 1
        },
        '5': {
            row: 2,
            col: -1
        },
        '6': {
            row: 1,
            col: -2
        },
        '7': {
            row: -1,
            col: -2
        },
        '8': {
            row: -2,
            col: -1
        }
    };

    var field = [];

    for (var i = 0; i < rows; i++) {
        var newRow = [];
        newRow.push(Math.pow(2, i));

        for (var j = 1; j < cols; j++) {
            newRow.push(newRow[j - 1] - 1);
        }

        field.push(newRow);
    }

    var sum = 0;
    var jumps = 0;

    sum += field[pos.row][pos.col];
    field[pos.row][pos.col] = 'x';
    jumps++;

    pos.row += directions[moves[pos.row][pos.col]].row;
    pos.col += directions[moves[pos.row][pos.col]].col;

    while (true) {
        if (pos.row < 0 || pos.row >= rows || pos.col < 0 || pos.col >= cols) {
            return "Go go Horsy! Collected " + sum + " weeds";
        }
        else if (field[pos.row][pos.col] === 'x') {
            return 'Sadly the horse is doomed in ' + jumps + ' jumps';
        }
        else {
            sum += field[pos.row][pos.col];
            field[pos.row][pos.col] = 'x';
            jumps++;

            pos.row += directions[moves[pos.row][pos.col]].row;
            pos.col += directions[moves[pos.row][pos.col]].col;
        }
    }
}

var firstTest = [
    '3 5',
    '54561',
    '43328',
    '52388'
];

var secondTest = [
	'3 5',
    '54361',
    '43326',
    '52888'
];

console.log(Solve(firstTest));
console.log(Solve(secondTest));