function maxEqualSequence() {
    var elements = new String(document.getElementById("input").value).split(","),
        current = elements[0],
        currentCount = 1,
        maxCount = Number.MIN_VALUE,
        maxElement;

    for (var i = 1; i < elements.length; i++) {
        if (elements[i] === current) {
            currentCount++;
        } else {
            if (currentCount > maxCount) {
                maxCount = currentCount;
                maxElement = current;
            }

            currentCount = 1;
            current = elements[i];
        }
    }

    jsConsole.write("{");

    for (var i = 0; i < maxCount; i++) {
        jsConsole.write(maxElement);

        if ((i + 1) < maxCount) {
            jsConsole.write(",");
        }
    }

    jsConsole.writeLine("}");
}