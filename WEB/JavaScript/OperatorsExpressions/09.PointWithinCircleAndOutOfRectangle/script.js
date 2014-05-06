function check() {
	var xCoordinate = parseFloat(document.getElementById("x").value),
		yCoordinate = parseFloat(document.getElementById("x").value);

	if (!(isNaN(xCoordinate) || isNaN(yCoordinate))) {
		var isWithinCircle = ((xCoordinate - 1) * (xCoordinate - 1) + (yCoordinate - 1) * (yCoordinate - 1)) < 9;
		var isOutOfRect = (xCoordinate < -1 || xCoordinate > 5 || yCoordinate < -1 || yCoordinate > 1);

		if (isWithinCircle && isOutOfRect) {
			jsConsole.writeLine("This point is within the circle and out of the rectangle.");
		} else {
			jsConsole.writeLine("This point doesn't meet the criteria.");
		}
	}
}