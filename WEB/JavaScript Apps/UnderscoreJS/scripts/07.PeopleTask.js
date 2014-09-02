(function () {
    var people = PersonModule.getPeopleArray(100);

    // Task 07. By an array of people find the most common first and last name. Use underscore.
    var firstNamesCount = _.countBy(people, function (person) {
        return person.firstName;
    });

    var mostPopularFirstName = {
        name: '',
        count: 0
    };

    _.map(firstNamesCount, function (count, name) {
        if (count > mostPopularFirstName.count) {
            mostPopularFirstName.name = name;
            mostPopularFirstName.count = count;
        }
    });

    var lastNamesCount = _.countBy(people, function (person) {
        return person.lastName;
    });

    var mostPopularLastName = {
        name: '',
        count: 0
    };

    _.map(lastNamesCount, function (count, name) {
        if (count > mostPopularLastName.count) {
            mostPopularLastName.name = name;
            mostPopularLastName.count = count;
        }
    });

    console.log(firstNamesCount);
    console.log('Most popular first name: ' + mostPopularFirstName.name);

    console.log(lastNamesCount);
    console.log('Most popular last name: ' + mostPopularLastName.name);
})();