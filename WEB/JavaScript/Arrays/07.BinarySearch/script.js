function findNumber() {
    var elements = new String(document.getElementById("sequence").value).split(","),
        searchedNumber = parseInt(document.getElementById("searched-number").value),
        numbers = new Array(elements.length);

    for (var i = 0; i < elements.length; i++) {
        numbers[i] = parseInt(elements[i]);
    }

    numbers.sort(sortingFunction);

    if ((binarySearch(0, numbers.length - 1)) != -1) {
        jsConsole.writeLine("The number \"" + searchedNumber + "\" exists.");
    } else {
        jsConsole.writeLine("The number \"" + searchedNumber + "\" doesn't exists.");
    }

    function sortingFunction(a, b) {
        return a - b;
    }
    
    function binarySearch(start, end) {
        var middle = Math.floor((start + end) / 2);

        if (start > end) {
            return -1;
        }
        else if (searchedNumber < numbers[middle]) {
            end = middle - 1;
            middle = binarySearch(start, end);
        } else if (searchedNumber > numbers[middle]) {
            start = middle + 1;
            middle = binarySearch(start, end);
        }

        return middle;
    }
}