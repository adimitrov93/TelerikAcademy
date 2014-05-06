function selectionSort() {
    var elements = new String(document.getElementById("input").value).split(","),
        array = new Array(elements.length),
        position = 0;

    for (var i = 0; i < elements.length; i++) {
        array[i] = parseInt(elements[i]);
    }

    for (var i = 0; i < array.length; i++) {
        smallestElem = array[i];
        position = i;

        // Finding the smallest element
        for (var j = i; j < array.length; j++)
        {
            if (array[j] < smallestElem) {
                smallestElem = array[j];
                position = j;
            }
        }

        if (smallestElem < array[i]) {
            array[position] = array[i];
            array[i] = smallestElem;
        }
    }

    jsConsole.writeLine("{" + array.join(",") + "}");
}