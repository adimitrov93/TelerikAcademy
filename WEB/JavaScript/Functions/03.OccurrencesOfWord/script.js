function onButtonClick() {
    var text = String(document.getElementById("text").value),
        searchedWord = String(document.getElementById("searched-word").value),
        isCaseSensitive,
        numberOfOccurrences;

    if (document.getElementById("caseSensitive").checked) {
        isCaseSensitive = true;
    } else {
        isCaseSensitive = false;
    }

    numberOfOccurrences = findOccurrences(text, searchedWord, isCaseSensitive);

    jsConsole.writeLine("The occurance of \"" + searchedWord + "\" is " + numberOfOccurrences);
}

function findOccurrences(text, searchedWord, isCaseSensitive) {
    var count = 0,
        words = [];

    if (!isCaseSensitive) {
        text = String(text).toLowerCase();
        searchedWord = String(searchedWord).toLowerCase();
    }

    words = text.split(/[\s.!?)(,;:"'-]/);

    for (var i = 0; i < words.length; i++) {
        if (words[i] === searchedWord) {
            count++;
        }
    }

    return count;
}