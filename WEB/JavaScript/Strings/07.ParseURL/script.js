function onButtonClick() {
    var input = document.getElementById("input-field").value,
        parsedUrl = parseUrl(input);

    jsConsole.writeLine("Protocol: " + parsedUrl.protocol);
    jsConsole.writeLine("Server: " + parsedUrl.server);
    jsConsole.writeLine("Resource: " + parsedUrl.resource);
}

function parseUrl(string) {
    var result,
        startIndex,
        endIndex,
        protocol,
        server,
        resource;

    startIndex = 0;
    endIndex = string.indexOf("://");
    protocol = string.slice(startIndex, endIndex);
    
    startIndex = endIndex + 3;
    endIndex = string.indexOf("/", startIndex);
    server = string.slice(startIndex, endIndex);

    startIndex = endIndex;
    endIndex = string.length;
    resource = string.slice(startIndex, endIndex);

    result = {
        protocol: protocol,
        server: server,
        resource: resource
    };

    return result;
}