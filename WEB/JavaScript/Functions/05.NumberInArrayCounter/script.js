function onButtonClick() {
    var elements = String(document.getElementById("sequence").value).split(","),
        searchedNumber = parseInt(document.getElementById("searched-number").value),
        arrayOfNumbers = [],
        result;

    for (var i = 0; i < elements.length; i++) {
        arrayOfNumbers[i] = parseInt(elements[i]);
    }

    result = countOccurrences(arrayOfNumbers, searchedNumber);

    if (result === 0) {
        jsConsole.writeLine(searchedNumber + " doesn't appear in the array.");
    } else if (result === 1) {
        jsConsole.writeLine(searchedNumber + " appears in the array 1 time.");
    } else {
        jsConsole.writeLine(searchedNumber + " appears in the array " + result + " times.");
    }
}

function countOccurrences(array, searchedNumber) {
    var count = 0;

    for (var i = 0; i < array.length; i++) {
        if (array[i] === searchedNumber) {
            count++;
        }
    }

    return count;
}

function testFunction() {
    jsConsole.writeLine("Running test function.");
    jsConsole.writeLine("----------------------");

    var usedNumbers = [],
        numberOfTestValues = Math.floor(Math.random() * 10) + 5,
        randomNumbers = getRandomNumbers(numberOfTestValues),
        expectedResult = new Array(numberOfTestValues),
        actual = [],
        arraySize = 0,
        testArray = [],
        currentPosition = 0,
        allTestPassed = true;

    // Filling up the array of objects holding number property and count property
    for (var i = 0; i < numberOfTestValues; i++) {
        expectedResult[i] = {
            number: randomNumbers[i],
            count: Math.floor(Math.random() * 10)
        };

        arraySize += expectedResult[i].count;
    }

    testArray = new Array(arraySize);

    // Filling up the testArray with the testing values.
    for (var i = 0; i < expectedResult.length; i++) {
        for (var j = 0; j < expectedResult[i].count; j++) {
            testArray[currentPosition++] = expectedResult[i].number;
        }
    }

    shuffle(testArray);
    insertRandomNumbers(testArray);

    // Getting results from the function that is tested
    for (var i = 0; i < expectedResult.length; i++) {
        actual[i] = {
            number: expectedResult[i].number,
            count: countOccurrences(testArray, expectedResult[i].number)
        };
    }

    jsConsole.writeLine("Test array: " + testArray.join(","));
    jsConsole.writeLine("");

    // Printing results
    for (var i = 0; i < expectedResult.length; i++) {
        jsConsole.writeLine("Number: " + expectedResult[i].number);
        jsConsole.writeLine("Expected count: " + expectedResult[i].count);
        jsConsole.writeLine("Actual count: " + actual[i].count);

        if (expectedResult[i].count === actual[i].count) {
            jsConsole.writeLine("Test passed.");
        } else {
            jsConsole.writeLine("Test failed.");
            allTestPassed = false;
        }

        jsConsole.writeLine("");
    }

    if (allTestPassed) {
        jsConsole.writeLine("All tests passed!");
    } else {
        jsConsole.writeLine("There is/are a failed test/s!");
    }

    jsConsole.writeLine("");

    jsConsole.writeLine("----------------------");
    jsConsole.writeLine("End of test function.");

    jsConsole.writeLine("");

    // Returns array with randomized numbers, that's not repeated.
    function getRandomNumbers(count) {
        var array = new Array(count);

        for (var i = 0; i < array.length; i++) {
            var randomNumber = Math.floor(Math.random() * 100);

            if (usedNumbers !== undefined) {
                while (usedNumbers.indexOf(randomNumber) >= 0) {
                    randomNumber = Math.floor(Math.random() * 100);
                }

                usedNumbers.push(randomNumber);
            } else {
                usedNumbers = [randomNumber];
            }

            array[i] = randomNumber;
        }

        return array;
    }
    
    // This function adds random numbers to the array. They don't have real purpose for the testing, but to make the array more beautiful.
    function insertRandomNumbers(array) {
        var count = Math.floor(array.length / 2);
            randomNumbers = getRandomNumbers(count),
            randomPosition;

        for (var i = 0; i < randomNumbers.length; i++) {
            var randomPosition = Math.floor(Math.random() * 100);

            while (randomPosition >= array.length) {
                randomPosition = Math.floor(Math.random() * 100);
            }

            array.splice(randomPosition, 0, randomNumbers[i]);
        }
    }

    // Fisher–Yates shuffle
    function shuffle(array) {
        var m = array.length,
            temp,
            i;

        // While there remain elements to shuffle…
        while (m) {

            // Pick a remaining element…
            i = Math.floor(Math.random() * m--);

            // And swap it with the current element.
            temp = array[m];
            array[m] = array[i];
            array[i] = temp;
        }

        return array;
    }
}