function onButtonClick() {
    var htmlText = document.getElementById("input-field").value,
        extractedText = extractText(htmlText);

    jsConsole.writeLine(extractedText);
}

function extractText(html) {
    var strings = html.split(/<[/a-zA-Z="'-.!]*>/);

    return strings.join("");
}