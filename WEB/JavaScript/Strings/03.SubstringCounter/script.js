function onButtonClick() {
    var string = document.getElementById("text").value,
        substring = document.getElementById("substring").value,
        resultCaseSensitive = countSubstrings(string, substring, true),
        resultCaseInsensitive = countSubstrings(string, substring, false);

    jsConsole.writeLine("Case sensitive result = " + resultCaseSensitive);
    jsConsole.writeLine("Case insensitive result = " + resultCaseInsensitive);
    jsConsole.writeLine("--------------------------");
}

function countSubstrings(string, substring, isCaseSensitive) {
    var count = 0,
        currentIndex,
        start = 0;

    if (!isCaseSensitive) {
        string = string.toLowerCase();
    }

    currentIndex = string.indexOf(substring, start);

    while (currentIndex !== -1) {
        count++;
        start = currentIndex + 1;
        currentIndex = string.indexOf(substring, start);
    }

    return count;
}