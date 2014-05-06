function nameOfDigits() {
    var digit = parseInt(document.getElementById("input").value),
        nameOfDigit;

    if (isNaN(digit)) {
        nameOfDigit = "This is not a number";
    } else {
        switch (digit) {
            case 0:
                nameOfDigit = "Zero";
                break;
            case 1:
                nameOfDigit = "One";
                break;
            case 2:
                nameOfDigit = "Two";
                break;
            case 3:
                nameOfDigit = "Three";
                break;
            case 4:
                nameOfDigit = "Four";
                break;
            case 5:
                nameOfDigit = "Five";
                break;
            case 6:
                nameOfDigit = "Six";
                break;
            case 7:
                nameOfDigit = "Seven";
                break;
            case 8:
                nameOfDigit = "Eight";
                break;
            case 9:
                nameOfDigit = "Nine";
                break;
            default:
                nameOfDigit = "This is not a digit";
                break;
        }
    }

    jsConsole.writeLine(nameOfDigit);
}