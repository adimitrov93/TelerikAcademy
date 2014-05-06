function sortDesc() {
    var firstValue = parseFloat(document.getElementById("first-value").value),
        secondValue = parseFloat(document.getElementById("second-value").value),
        thirdValue = parseFloat(document.getElementById("third-value").value);

    if (firstValue < secondValue) {
        firstValue += secondValue;
        secondValue = firstValue - secondValue;
        firstValue -= secondValue;
    }

    if (firstValue < thirdValue) {
        firstValue += thirdValue;
        thirdValue = firstValue - thirdValue;
        firstValue -= thirdValue;
    }

    if (secondValue < thirdValue) {
        secondValue += thirdValue;
        thirdValue = secondValue - thirdValue;
        secondValue -= thirdValue;
    }

    jsConsole.writeLine("Biggest: " + firstValue);
    jsConsole.writeLine("Medium: " + secondValue);
    jsConsole.writeLine("Smallest " + thirdValue);
}