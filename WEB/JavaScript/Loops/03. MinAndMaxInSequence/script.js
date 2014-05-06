function findMinAndMax() {
    var input = new String(document.getElementById("input").value).split(","),
        min = Number.MAX_VALUE,
        max = Number.MIN_VALUE,
        current;

    for (var i = 0; i < input.length; i++) {
        current = parseFloat(input[i]);

        if (current > max) {
            max = current;
        }
        else if (current < min) {
            min = current;
        }
    }

    jsConsole.writeLine("Min: " + min);
    jsConsole.writeLine("Max: " + max);
}