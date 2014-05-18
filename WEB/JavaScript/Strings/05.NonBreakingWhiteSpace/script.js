function onButtonClick() {
    var text = document.getElementById("input-field").value,
        result = text.replace(/\s/g, "&nbsp;");

    jsConsole.writeLine(result);
}