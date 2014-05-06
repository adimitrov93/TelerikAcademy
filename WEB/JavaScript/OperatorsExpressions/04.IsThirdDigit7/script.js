function check() {
	var inputNumber = parseInt(document.getElementById("input-field").value);

	if (!isNaN(inputNumber)) {
		inputNumber = parseInt(inputNumber / 100);
		inputNumber %= 10;

		jsConsole.writeLine(inputNumber === 7 ? true : false);
	}
}