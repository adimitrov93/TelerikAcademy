function findSignOfTheProduct() {
	var firstVariable = parseInt(document.getElementById("first-variable").value),
		secondVariable = parseInt(document.getElementById("second-variable").value),
		thirdVariable = parseInt(document.getElementById("third-variable").value),
		result = "+";

	if (typeof(firstVariable) === "number" && typeof(secondVariable) === "number" && typeof(thirdVariable) === "number") {
		if (firstVariable === 0 || secondVariable === 0 || thirdVariable === 0) {
			result = "0";
		} else {
			if (firstVariable < 0) {
				changeResult();
			}

			if (secondVariable < 0) {
				changeResult();
			}

			if (thirdVariable < 0) {
				changeResult();
			}
		}
	}

	jsConsole.writeLine("Result is " + result);

	function changeResult() {
		if (result === "+") {
			result = "-";
		} else {
			result = "+";
		}
	}
}