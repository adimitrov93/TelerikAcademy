function print1ToN() {
    var n = parseInt(document.getElementById("input").value),
        i = 0;

    if (isNaN(n)) {
        jsConsole.writeLine("Incorrect number!");
        return;
    }

    for (var i = 1; i <= n; i++) {
        jsConsole.writeLine(i);
    }

    jsConsole.writeLine("---------------");
}