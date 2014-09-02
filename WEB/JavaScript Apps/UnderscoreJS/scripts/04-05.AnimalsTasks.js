(function () {
	var animals = AnimalModule.getAnimalsArray();
	console.log(animals);

    // Task 04. Write a function that by a given array of animals, groups them by species and sorts them by number of legs
	var sortedAnimals = _.sortBy(animals, function (animal) {
		return animal.numberOfLegs;
	});

	var groupedAnimals = _.groupBy(sortedAnimals, function (animal) {
		return animal.specie;
	});

	console.log(groupedAnimals);

    // Task 05. By a given array of animals, find the total number of legs
	var totalNumberOfLegs = _.reduce(animals, function (memo, animal) {
	    return memo + animal.numberOfLegs;
	}, 0);

	console.log('Total number of legs: ' + totalNumberOfLegs);
})();