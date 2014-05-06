// This task is solved by using an "Asociative arrays", also called Dictionary (in C#) or Map (in Java). The idea is simple - i take one number as a string and put it in this array as a "key"
// and make its value equal to 1. If it already exist in the array just increment its value.

function mostFrequentNumber() {
    var elements = new String(document.getElementById("input").value).split(","),
        // The associative array.
        frequency = {};

    for (var i = 0; i < elements.length; i++) {
        // If elements[i] exist in the array. Example for elements[i] = "2".
        if (frequency[elements[i]]) {
            frequency[elements[i]]++;
        // else means that elements[i] doesn't exist in the array and we create it by giving it value of 1.
        } else {
            frequency[elements[i]] = 1;
        }
    }

    // FrequencyProperties hold all the properties of the array, in our case - numbers as strings. Ex: "2", "3", ... and so on.
    // By frequency[frequencyProperties[0]] we acces the value of the first property(number) in the array. If frequencyProperties[0] === "2" and we have 3 times this number, frequency[frequencyProperties[0]] = 3.
    var frequencyProperties = Object.getOwnPropertyNames(frequency),
        mostFrequentNumber = frequencyProperties[0],
        count = frequency[frequencyProperties[0]];

    for (var i = 1; i < frequencyProperties.length; i++) {
        if (frequency[frequencyProperties[i]] > count) {
            mostFrequentNumber = frequencyProperties[i];
            count = frequency[frequencyProperties[i]];
        }
    }

    jsConsole.writeLine("Most frequent number is: " + mostFrequentNumber);
}