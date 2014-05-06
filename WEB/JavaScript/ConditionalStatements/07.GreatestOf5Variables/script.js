function findGreatest() {
    var input = new String(document.getElementById("input").value).split(","),
        biggest = Number.MIN_VALUE,
        current;

    for (var i = 0; i < input.length; i++) {
        current = parseFloat(input[i]);

        if (current > biggest) {
            biggest = current;
        }
    }

    jsConsole.writeLine("The biggest number is " + biggest);
}