var AnimalModule = (function () {
    function Animal(specie) {
        this.specie = specie.specie;
        this.numberOfLegs = specie.numberOfLegs[getRandomNumber(specie.numberOfLegs.length)];
    };

    var species = [{
        specie: 'Bird',
        numberOfLegs: [2]
    }, {
        specie: 'Insect',
        numberOfLegs: [2, 4, 6, 8, 100]
    }, {
        specie: 'Mammal',
        numberOfLegs: [2, 4]
    }, {
        specie: 'Reptile',
        numberOfLegs: [4]
    }];

    var getAnimalsArray = function (count) {
        count = count || 15;

        var animals = [];

        for (var i = 0; i < count; i++) {
            var animal = new Animal(species[getRandomNumber(species.length)]);

            animals.push(animal);
        }

        return animals;
    }

    var getRandomNumber = function (max) {
        return Math.floor(Math.random() * max);
    };

    return {
        Animal: Animal,
        species: species,
        getAnimalsArray: getAnimalsArray
    };
})();