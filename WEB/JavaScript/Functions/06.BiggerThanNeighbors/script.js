function onButtonClick() {
    var elements = String(document.getElementById("sequence").value).split(","),
        index = parseInt(document.getElementById("index").value),
        arrayOfNumbers = [],
        result;

    for (var i = 0; i < elements.length; i++) {
        arrayOfNumbers[i] = parseInt(elements[i]);
    }

    result = isBiggerThanNeighbors(arrayOfNumbers, index);

    if (result) {
        if ((index === 0) || (index === arrayOfNumbers.length - 1)) {
            jsConsole.writeLine(arrayOfNumbers[index] + " is bigger than it's neighbor.");
        } else {
            jsConsole.writeLine(arrayOfNumbers[index] + " is bigger than it's neighbors.");
        }
    } else {
        if ((index === 0) || (index === arrayOfNumbers.length - 1)) {
            jsConsole.writeLine(arrayOfNumbers[index] + " isn't bigger than it's neighbor.");
        } else {
            jsConsole.writeLine(arrayOfNumbers[index] + " isn't bigger than it's neighbors.");
        }
    }
}

function isBiggerThanNeighbors(array, index) {
    var result;

    if (index === 0) {
        if (array[index] > array[index + 1]) {
            result = true;
        } else {
            result = false;
        }
    } else if (index === array.length - 1) {
        if (array[index] > array[index - 1]) {
            result = true;
        } else {
            result = false;
        }
    } else {
        if ((array[index] > array[index - 1]) && (array[index] > array[index + 1])) {
            result = true;
        } else {
            result = false;
        }
    }

    return result;
}