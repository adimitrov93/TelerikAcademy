function onLoad() {
    var persons = [
        {
            firstName: "Pesho",
            lastName: "Goshov",
            age: 32
        },
        {
            firstName: "Gosho",
            lastName: "Peshov",
            age: 31
        },
        {
            firstName: "Michael",
            lastName: "Jackson",
            age: 56
        },
        {
            firstName: "Lili",
            lastName: "Ivanova",
            age: 1000
        },
        {
            firstName: "Ivan",
            lastName: "Petrov",
            age: 19
        },
        {
            firstName: "Qnica",
            lastName: "Petrova",
            age: 25
        },
        {
            firstName: "Ivanka",
            lastName: "Veselinova",
            age: 59
        },
        {
            firstName: "Gosho",
            lastName: "Petrov",
            age: 19
        }
    ],
    yongest = findYongest(persons);

    jsConsole.writeLine("From this people: ");
    jsConsole.writeLine("");

    for (var i = 0; i < persons.length; i++) {
        jsConsole.writeLine(personToString(persons[i]));
    }

    jsConsole.writeLine("");
    jsConsole.writeLine("Yongest person is " + personToString(yongest));
}

function findYongest(arrayOfPersons) {
    // Better way
    var yongest = {
        age: Number.MAX_VALUE
    };

    for (var i = 0; i < arrayOfPersons.length; i++) {
        if (arrayOfPersons[i].age < yongest.age) {
            yongest = arrayOfPersons[i];
        }
    }

    return yongest;

    // Easiest way
    //arrayOfPersons.sort(function (a, b) {
    //    return a.age - b.age;
    //});

    //return arrayOfPersons[0];
}

function personToString(person) {
    return person.firstName + " " + person.lastName + " Age: " + person.age;
}