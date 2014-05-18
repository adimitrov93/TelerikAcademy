function onButtonClick() {
    var expression = document.getElementById("input-field").value,
        result = areBracketsCorrect(expression);

    if (result) {
        jsConsole.writeLine("All brackets are correct.");
    } else {
        jsConsole.writeLine("There are incorrect brackets.");
    }
}

function areBracketsCorrect(expression) {
    var brackets = 0,
        result;

    for (var i = 0; i < expression.length; i++) {
        if (expression[i] === "(") {
            brackets++;
        } else if (expression[i] === ")") {
            brackets--;
        }

        if (brackets < 0) {
            break;
        }
    }

    result = brackets === 0;

    return result;
}