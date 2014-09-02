var specialConsole = (function () {
    "use strict";

    function getMsg(args) {
        var resultString,
            message;

        if (args.length > 1) {
            resultString = stringFormat(args);
        } else {
            message = args[0];
            if (typeof (message) == 'string') {
                resultString = message;
            } else {
                resultString = message.toString();
            }
        }

        return resultString;
    }

    function writeLine(message) {
        console.log(getMsg(arguments));
    }

    function writeError(message) {
        throw new Error(getMsg(arguments));
    }

    function writeWarning(message) {
        console.warn(getMsg(arguments));
    }

    function stringFormat(args) {
        var pattern = args[0];

        while (pattern.indexOf("{") >= 0) {
            var placeHolderIndex = parseInt(pattern.substring(pattern.indexOf("{") + 1, pattern.indexOf("}")));
            pattern = pattern.replace("{" + placeHolderIndex + "}", args[placeHolderIndex + 1]);
        }
        return pattern;
    }

    return {
        writeLine: writeLine,
        writeError: writeError,
        writeWarning: writeWarning
    }
}());


specialConsole.writeLine("Message: hello");
specialConsole.writeLine("Message: {0}, {1}", "Hello", "Pesho");
var testNumber = 35;
specialConsole.writeLine(testNumber);

specialConsole.writeWarning("Warning: {0}", "A warning");
//specialConsole.writeError("{0}", "Something happened");
specialConsole.writeError("Fatal Error: {0}", "Something Fatal happened");


