function examineForBigger() {
	var firstVariable = parseInt(document.getElementById("first-variable").value);
	var secondVariable = parseInt(document.getElementById("second-variable").value);

	if (typeof(firstVariable) === "number" && typeof(secondVariable) === "number") {
		if (firstVariable > secondVariable) {
			firstVariable += secondVariable;
			secondVariable = firstVariable - secondVariable;
			firstVariable -= secondVariable;
		}

		jsConsole.writeLine("First variable: " + firstVariable);
		jsConsole.writeLine("Second variable: " + secondVariable);
	}
}