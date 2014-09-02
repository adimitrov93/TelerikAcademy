function Solve(args) {
    var lines = args.map(function (item) {
        item = item.trim();

        if (item.indexOf('def ') === 0) {
            item = item.slice(4);
        }
        else {
            item = 'final ' + item;
        }

        return item.trim();
    });
    var variables = {};

    for (var i = 0; i < lines.length; i++) {
        var currentLine = lines[i];
        var currentString = '';
        var currentVarName = '';
        var currentFunc = '';
        var currentNumber = '';
        var operands = [];
        
        var inWord = true;

        for (var j = 0; j < currentLine.length; j++) {
            var currentSymbol = currentLine[j];

            if (currentSymbol === ',' || currentSymbol === ' ' || currentSymbol === '[' || currentSymbol === ']') {
                if (inWord) {
                    inWord = false;

                    if (currentVarName === '') {
                        currentVarName = currentString;
                    }
                    else if (variables[currentString]){
                        Array.prototype.push.apply(operands, variables[currentString]);
                    }
                    else if (currentFunc === '') {
                        currentFunc = currentString;
                    }

                    currentString = '';
                }
                else if (currentNumber !== '') {
                    operands.push(parseInt(currentNumber));

                    currentNumber = '';
                }

                continue;
            }

            if (isNumber(currentSymbol) || isMinus(currentSymbol)) {
                if (inWord) {
                    currentString += currentSymbol;
                }
                else {
                    currentNumber += currentSymbol;
                }

                continue;
            }

            if (!inWord) {
                inWord = true;
            }

            currentString += currentSymbol;
        }

        variables[currentVarName] = evaluate(currentFunc, operands);
    }

    return variables.final[0];

    function isNumber(symbol) {
        if (symbol === ' ' || symbol === '') {
            return false;
        }

        return symbol == Number(symbol);
    }

    function isMinus(symbol) {
        return symbol === '-';
    }

    function evaluate(func, operands) {
        if (func === '') {
            return operands;
        }

        var result = operands[0];
        switch (func) {
            case 'sum':
                for (var i = 1; i < operands.length; i++) {
                    result += operands[i];
                }
                break;
            case 'avg':
                result = evaluate('sum', operands);
                result = Math.floor(result / operands.length);
                break;
            case 'min':
                for (var i = 1; i < operands.length; i++) {
                    if (operands[i] < result) {
                        result = operands[i];
                    }
                }
                break;
            case 'max':
                for (var i = 1; i < operands.length; i++) {
                    if (operands[i] > result) {
                        result = operands[i];
                    }
                }
                break;
        }

        return [result];
    }
}

var firstTest = [
    'def var1 [1, 2, 6, 8]',
    'def var2 sum[1, 5, -10, 20]',
    'def var3 max[5, 2, 4, var2, 2]',
    'def var5 avg[var1]',
    'def var6 sum[var1, var1, 1]'
];

var secondTest = [
    'def var1[1, 2, 3 ,4]',
    'def var2 sum[var1, 20, 70]',
    'def var3 min[var1]',
    'avg[var2, var3]'
];

var thirdTest = [
    'def func sum[5, 3, 7, 2, 6, 3]',
    'def func2 [5, 3, 7, 2, 6, 3]',
    'def func3 min[func2]',
    'def func4 max[5, 3, 7, 2, 6, 3]',
    'def func5 avg[5, 3, 7, 2, 6, 3]',
    'def func6 sum[func2, func3, func4 ]',
    'sum[func6, func4]'
];

var fourthTest = [
    'def func sum[1, 2, 3, -6]',
    'def newList [func, 10, 1]',
    'def newFunc sum[func, 100, newList]',
    '[newFunc]'
];

console.log(Solve(firstTest));
console.log(Solve(secondTest));
console.log(Solve(thirdTest));
console.log(Solve(fourthTest));