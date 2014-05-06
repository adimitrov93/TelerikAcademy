function findSmallestAndLargestProperty() {
    var documentProperties = Object.getOwnPropertyNames(document),
        windowProperties = Object.getOwnPropertyNames(window),
        navigatorProperties = Object.getOwnPropertyNames(navigator);

    documentProperties.sort();
    windowProperties.sort();
    navigatorProperties.sort();

    jsConsole.writeLine("document object:");
    jsConsole.writeLine("Smallest: " + documentProperties[0]);
    jsConsole.writeLine("Largest: " + documentProperties[documentProperties.length - 1]);
    jsConsole.writeLine("----------------------------------------");

    jsConsole.writeLine("window object:");
    jsConsole.writeLine("Smallest: " + windowProperties[0]);
    jsConsole.writeLine("Largest: " + windowProperties[windowProperties.length - 1]);
    jsConsole.writeLine("----------------------------------------");

    jsConsole.writeLine("navigator object:");
    jsConsole.writeLine("Smallest: " + navigatorProperties[0]);
    jsConsole.writeLine("Largest: " + navigatorProperties[navigatorProperties.length - 1]);
    jsConsole.writeLine("----------------------------------------");
}