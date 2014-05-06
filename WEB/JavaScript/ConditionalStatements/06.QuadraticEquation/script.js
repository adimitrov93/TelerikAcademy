function solveEquation() {
    var a = parseFloat(document.getElementById("a").value),
        b = parseFloat(document.getElementById("b").value),
        c = parseFloat(document.getElementById("c").value),
        d,
        x1,
        x2;

    if (a == 0) {
        jsConsole.writeLine("'a' cannot be 0");
    } else {
        d = (b * b) - (4 * a * c);

        if (d < 0) {
            jsConsole.writeLine("The equation has no real roots.");
        } else if (d === 0) {
            x1 = -b / 2 * a;

            jsConsole.writeLine("x1 = " + x1);
        } else {
            x1 = (-b + Math.sqrt(d)) / (2 * a);
            x2 = (-b - Math.sqrt(d)) / (2 * a);

            jsConsole.writeLine("x1 = " + x1);
            jsConsole.writeLine("x2 = " + x2);
        }
    }
}