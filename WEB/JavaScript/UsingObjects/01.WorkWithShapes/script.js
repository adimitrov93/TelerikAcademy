function calculateDistanceBetweenPointsButtonClick() {
    var firstPoint = parsePoint(document.getElementById("first-point").value),
        secondPoint = parsePoint(document.getElementById("second-point").value),
        distance = getDistanceBetweenPoints(firstPoint, secondPoint);

    jsConsole.writeLine("Distance is " + distance);
}

function chechIfTriangleButtonClick() {
    var firstLine = {
        startPoint: parsePoint(document.getElementById("first-line-start").value),
        endPoint: parsePoint(document.getElementById("first-line-end").value)
    },
    secondLine = {
        startPoint: parsePoint(document.getElementById("second-line-start").value),
        endPoint: parsePoint(document.getElementById("second-line-end").value)
    },
    thirdLine = {
        startPoint: parsePoint(document.getElementById("third-line-start").value),
        endPoint: parsePoint(document.getElementById("third-line-end").value)
    },
    canFormTriangle;

    firstLine.length = getDistanceBetweenPoints(firstLine.startPoint, firstLine.endPoint);
    secondLine.length = getDistanceBetweenPoints(secondLine.startPoint, secondLine.endPoint);
    thirdLine.length = getDistanceBetweenPoints(thirdLine.startPoint, thirdLine.endPoint);

    canFormTriangle = (firstLine.length + secondLine.length > thirdLine.length) &&
        (firstLine.length + thirdLine.length > secondLine.length) &&
        (secondLine.length + thirdLine.length > firstLine.length);

    jsConsole.writeLine("Can form a triangle? -> " + canFormTriangle);
}

function parsePoint(input) {
    input = input.split(/[,()]/);

    removeEmptyStrings(input);

    return { x: parseInt(input[0]), y: parseInt(input[1]) };
}

function removeEmptyStrings(arrayOfStrings) {
    for (var i = 0; i < arrayOfStrings.length; i++) {
        if (arrayOfStrings[i] === "") {
            arrayOfStrings.splice(i, 1);
        }
    }
}

function comparePoints(firstPoint, secondPoint) {
    if ((firstPoint.x === secondPoint.x) && (firstPoint.y === secondPoint.y)) {
        return true;
    } else {
        return false;
    }
}

function getDistanceBetweenPoints(firstPoint, secondPoint) {
    var distance = Math.sqrt(((firstPoint.x - secondPoint.x) * (firstPoint.x - secondPoint.x)) + ((firstPoint.y - secondPoint.y) * (firstPoint.y - secondPoint.y)));

    return distance;
}