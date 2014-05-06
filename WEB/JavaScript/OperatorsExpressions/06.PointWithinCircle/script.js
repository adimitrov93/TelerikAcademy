function isWithinCircle() {
	var xCoordinate = parseFloat(document.getElementById("x").value),
		yCoordinate = parseFloat(document.getElementById("x").value);

	if (!(isNaN(xCoordinate) || isNaN(yCoordinate))) {
		var isWithinCircle = ((xCoordinate * xCoordinate) + (yCoordinate * yCoordinate)) < 25;

		jsConsole.writeLine(isWithinCircle ? "The point is within the circle" : "The point is out of the circle");
	}
}