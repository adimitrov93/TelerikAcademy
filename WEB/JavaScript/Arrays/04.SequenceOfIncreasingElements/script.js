function maxIncrSequence() {
    var elements = new String(document.getElementById("input").value).split(","),
        numbers = new Array(elements.length),
        currentCount = 1,
        maxCount = Number.MIN_VALUE,
        previous,
        currentStartElement,
        current,
        maxStartElement;

    for (var i = 0; i < elements.length; i++) {
        numbers[i] = parseInt(elements[i]);
    }

    currentStartElement = numbers[0],
    previous = numbers[0];

    for (var i = 1; i < numbers.length; i++) {
        current = numbers[i];

        if (current - 1 === previous) {
            currentCount++;
            previous = current;
        } else {
            if (currentCount > maxCount) {
                maxCount = currentCount;
                maxStartElement = currentStartElement;
            }

            currentCount = 1;
            previous = numbers[i];
            currentStartElement = numbers[i];
        }
    }

    // Second check in case if there is only one sequence and it is increasing. Ex: 3,4,5. Without this if it won't work.
    if (currentCount > maxCount) {
        maxCount = currentCount;
        maxStartElement = currentStartElement;
    }

    jsConsole.write("{");

    for (var i = 0; i < maxCount; i++) {
        jsConsole.write(parseInt(maxStartElement) + i);

        if ((i + 1) < maxCount) {
            jsConsole.write(",");
        }
    }

    jsConsole.writeLine("}");
}