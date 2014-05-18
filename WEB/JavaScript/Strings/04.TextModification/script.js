function onButtonClick() {
    var text = document.getElementById("input-field").value,
        result = modificateText(text);

    jsConsole.writeLine(result);
}

function modificateText(text) {
    return text.replace(/<mixcase>(.*?)<\/mixcase>/g, function (group) { return getRandomCase(group); })
        .replace(/<lowcase>(.*?)<\/lowcase>/g, function (group) { return group.toLowerCase() })
        .replace(/<upcase>(.*?)<\/upcase>/g, function (group) { return group.toUpperCase(); });
}

function getRandomCase(str) {
    var result = "";

    for (var i = 0; i < str.length; i++) {
        if (Math.random() > 0.5) {
            result += str[i].toUpperCase();
        } else {
            result += str[i].toLowerCase();
        }
    }

    return result;
}