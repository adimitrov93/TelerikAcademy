function check() {
    var divs = document.getElementsByTagName("div");

    jsConsole.writeLine("Divs count: " + divs.length);
}

function addDiv() {
    var div = document.createElement("div");

    document.body.appendChild(div);
}