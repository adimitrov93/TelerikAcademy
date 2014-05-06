function compareStrings() {
    var firstString = new String(document.getElementById("first-string").value),
        secondString = new String(document.getElementById("second-string").value),
        condition = Math.min(firstString.length, secondString.length);

    for (var i = 0; i < condition; i++) {
        if (firstString[i] != secondString[i]) {

            if (firstString[i] < secondString[i]) {
                jsConsole.writeLine(firstString + " is before " + secondString);
            }
            else {
                jsConsole.writeLine(secondString + " is before " + firstString);
            }

            return;
        }
    }

    if (firstString.length < secondString.length) {
        jsConsole.writeLine(firstString + " is before " + secondString);
    }
    else if (firstString.length > secondString.length) {
        jsConsole.writeLine(secondString + " is before " + firstString);
    }
    else {
        jsConsole.writeLine("The words are equal.");
    }
}