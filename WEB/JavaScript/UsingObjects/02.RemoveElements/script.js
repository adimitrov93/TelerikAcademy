function onButtonClick() {
    Array.prototype.remove = function (numberToRemove) {
        for (var i = 0; i < this.length; i++) {
            if (this[i] === numberToRemove) {
                this.splice(i, 1);
                i--;
            }
        }
    }

    var elements = document.getElementById("sequence").value.split(","),
        numberToRemove = document.getElementById("element-to-remove").value;

    elements.remove(numberToRemove);

    jsConsole.writeLine(elements.join(","));
}