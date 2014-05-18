function onLoad() {
    var array = [];

    jsConsole.writeLine("Have an array \"length\" property? -> " + hasProperty(array, "length"));

    jsConsole.writeLine("Look at the code. There is nothing else to show in this task.");
}

function hasProperty(obj, property) {
    var properties = Object.getOwnPropertyNames(obj),
        hasProp = false;

    for (var i = 0; i < properties.length; i++) {
        if (properties[i] === property) {
            hasProp = true;
            break;
        }
    }

    return hasProp;
}