var PersonModule = (function () {
    function Person(firstName, lastName, age) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }

    var getPeopleArray = function (count) {
        count = count || 15;

        var firstNames = ['Pesho', 'Gosho', 'Ivan', 'Petkan', 'Dimitar', 'Aleksandar', 'Boiko', 'Veselin', 'Pencho', 'Ilian', 'Ivo'],
            lastNames = ['Dimitrov', 'Peshev', 'Ivanov', 'Petrov', 'Genadiev', 'Penchev', 'Gigov', 'Todorov', 'Mishev'],
            people = [];

        for (var i = 0; i < count; i++) {
            var person = new Person(firstNames[getRandomNumber(firstNames.length)], lastNames[getRandomNumber(lastNames.length)], getRandomNumber(100));

            people.push(person);
        }

        return people;
    };

    var getRandomNumber = function (max) {
        return Math.floor(Math.random() * max);
    };

    return {
        Person: Person,
        getPeopleArray: getPeopleArray
    };
})();