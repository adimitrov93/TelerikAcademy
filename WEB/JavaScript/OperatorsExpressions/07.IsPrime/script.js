function isPrime() {
	var inputNumber = parseInt(document.getElementById("input-field").value);
	var isPrime = true;

	for (var i = 2; i < Math.sqrt(inputNumber); i++) {
		if (inputNumber % i === 0) {
			isPrime = false;
			break;
		}
	}

	jsConsole.writeLine(isPrime ? true : false);
}