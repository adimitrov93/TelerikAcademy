function reverse() {
    var input = parseInt(document.getElementById("input-field").value);

    if (isNaN(input)) {
        jsConsole.writeLine("Invalid number");
        return;
    }

    jsConsole.writeLine(reverseDigitsOfNumber(input));
}

function reverseDigitsOfNumber(number) {
    var currentDigit,
        result = 0;
    
    while (number !== 0) {
        currentDigit = number % 10;
        number = Math.floor(number / 10);
        result *= 10;
        result += currentDigit;
    }

    return result;
}