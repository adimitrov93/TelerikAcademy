function onLoad() {
    var pesho = {
        name: "Pesho",
        age: 21,
        grades: {
            math: 4,
            physics: 6
        },
        print: function () {
            jsConsole.writeLine("Name: " + this.name);
            jsConsole.writeLine("Age: " + this.age);
            jsConsole.writeLine("Grades:");

            var gradesProp = Object.getOwnPropertyNames(this.grades);

            for (var i = 0; i < gradesProp.length; i++) {
                jsConsole.writeLine(gradesProp[i] + ": " + this.grades[gradesProp[i]]);
            }
        }
    },
    clone = deepCopy(pesho);

    jsConsole.writeLine("We create object pesho with some properties.");
    jsConsole.writeLine("");
    pesho.print();
    jsConsole.writeLine("");
    jsConsole.writeLine("When we copy it, the copy will be exacly the same. (lol you didn't expect that, right? ;d)");
    jsConsole.writeLine("");
    clone.print();
    jsConsole.writeLine("");
    jsConsole.writeLine("But when we change clone's name, it will not change the original's name too.");
    jsConsole.writeLine("");
    pesho.print();
    jsConsole.writeLine("");
    clone.name = "Gosho";
    clone.print();
    jsConsole.writeLine("");
    jsConsole.writeLine("That means that the copy is deep, not just copy of the reference.");
}

function deepCopy(obj) {
    if (typeof (obj) === "object") {
        var clone = {};

        for (var prop in obj) {
            clone[prop] = deepCopy(obj[prop]);
        }

        return clone;
    } else {
        return obj;
    }
}