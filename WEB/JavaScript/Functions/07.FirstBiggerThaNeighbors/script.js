function onButtonClick() {
    var elements = String(document.getElementById("sequence").value).split(","),
        arrayOfNumbers = [],
        result;

    for (var i = 0; i < elements.length; i++) {
        arrayOfNumbers[i] = parseInt(elements[i]);
    }

    result = firstBiggerThanNeighbors(arrayOfNumbers);

    if (result === -1) {
        jsConsole.writeLine("Such number doesn't exist!");
    } else {
        jsConsole.writeLine(arrayOfNumbers[result] + " is the furst number bigger than it's neighbors.");
    }
}

function firstBiggerThanNeighbors(array) {
    for (var i = 0; i < array.length; i++) {
        if (isBiggerThanNeighbors(array, i)) {
            return i;
        }
    }

    return -1;
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