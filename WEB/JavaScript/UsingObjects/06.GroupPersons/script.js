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
    groupedByFirstName = group(persons, "firstName"),
    groupedByLastName = group(persons, "lastName"),
    groupedByAge = group(persons, "age");

    jsConsole.writeLine("From this people: ");
    jsConsole.writeLine("");

    for (var i = 0; i < persons.length; i++) {
        jsConsole.writeLine(personToString(persons[i]));
    }

    jsConsole.writeLine("");
    jsConsole.writeLine("----------");
    jsConsole.writeLine("");
    jsConsole.writeLine("Grouped by first name.");
    printGroup(groupedByFirstName);
    jsConsole.writeLine("----------");
    jsConsole.writeLine("");
    jsConsole.writeLine("Grouped by last name.");
    printGroup(groupedByLastName);
    jsConsole.writeLine("----------");
    jsConsole.writeLine("");
    jsConsole.writeLine("Grouped by age.");
    printGroup(groupedByAge);
}

function group(arrayOfPersons, groupBy) {
    var result = {};

    for (var i = 0; i < arrayOfPersons.length; i++) {
        var property = arrayOfPersons[i][groupBy];

        // Check if the current property is initialized in the result object.
        if (result[property]) {
            result[property].push(arrayOfPersons[i]);
        } else {
            result[property] = [arrayOfPersons[i]];
        }
    }

    return result;
}

function personToString(person) {
    return person.firstName + " " + person.lastName + " Age: " + person.age;
}

function printGroup(group) {
    var properties = Object.getOwnPropertyNames(group);

    for (var i = 0; i < properties.length; i++) {
        var property = properties[i];

        jsConsole.writeLine(property + ":");

        for (var j = 0; j < group[property].length; j++) {
            jsConsole.writeLine(personToString(group[property][j]));
        }

        jsConsole.writeLine("");
    }
}