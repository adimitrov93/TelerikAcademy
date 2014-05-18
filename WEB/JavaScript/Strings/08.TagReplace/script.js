function onButtonClick() {
    var text = document.getElementById("input-field").value,
        result = replaceTags(text);

    jsConsole.writeLine(text);
}

function replaceTags(text) {
    var oldOpenTag = "<a href",
        oldCloseTag = "</a",
        newOpenTag = "<URL",
        newCloseTag = "</URL",
        splited;

    splited = text.split(oldOpenTag);
    text = splited.join(newOpenTag);
    splited = text.split(oldCloseTag);
    text = splited.join(newCloseTag);

    // Second way of doing the same thing
    //while (text.indexOf(oldOpenTag) !== -1) {
    //    text = text.replace(oldOpenTag, newOpenTag);
    //    text = text.replace(oldCloseTag, newCloseTag);
    //}

    return text;
}