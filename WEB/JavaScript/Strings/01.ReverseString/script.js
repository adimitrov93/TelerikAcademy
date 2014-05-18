function onButtonClick() {
    var input = document.getElementById("input-field").value,
        reversed = reverseString(input);

    jsConsole.writeLine(reversed);
}

function reverseString(str) {
    var charArray = str.split(""),
        length = charArray.length,
        temp;

    for (var i = 0; i < length / 2; i++) {
        temp = charArray[i];
        charArray[i] = charArray[length - i - 1];
        charArray[length - i - 1] = temp;
    }

    return charArray.join("");
}