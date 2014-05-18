(function onLoad() {
    jsConsole.writeLine(stringFormat("Hello, {0}! It's nice to meet you!", "Pesho"));
}());

function stringFormat(formatString, arg0, arg1, arg2, args) {
    var result = "",
        appendStartIndex = 0,
        placeholderStartIndex,
        placeholderEndIndex,
        resultToAppend,
        currentPlaceholder,
        currentPlaceholderAsString;

    for (var i = 0; i < formatString.length; i++) {
        if (formatString[i] === "{") {
            resultToAppend = formatString.substring(appendStartIndex, i);
            result += resultToAppend;

            placeholderStartIndex = i + 1;
            placeholderEndIndex = formatString.indexOf("}", i);
            currentPlaceholderAsString = formatString.substring(placeholderStartIndex, placeholderEndIndex);
            currentPlaceholder = parseInt(currentPlaceholderAsString);
            result += arguments[currentPlaceholder + 1];

            appendStartIndex = placeholderEndIndex + 1;
        }
    }

    resultToAppend = formatString.substring(appendStartIndex, i);
    result += resultToAppend;

    return result;
}