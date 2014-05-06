function findBiggest() {
    var firstVariable = parseInt(document.getElementById("first-variable").value),
        secondVariable = parseInt(document.getElementById("second-variable").value),
        thirdVariable = parseInt(document.getElementById("third-variable").value),
        biggest = firstVariable;

    if (secondVariable > firstVariable) {
        biggest = secondVariable;

        if (thirdVariable > secondVariable) {
            biggest = thirdVariable;
        }
    } else {
        if (thirdVariable > firstVariable) {
            biggest = thirdVariable;
        }
    }

    jsConsole.writeLine("The biggest number is " + biggest);
}