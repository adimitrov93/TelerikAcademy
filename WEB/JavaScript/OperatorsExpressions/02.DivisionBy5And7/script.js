function check() {
	var inputNumber = parseInt(document.getElementById("input-field").value);

	if (!isNaN(inputNumber)) {
		jsConsole.writeLine(inputNumber % 35 == 0 ?
			inputNumber + " divides by 5 and 7 without remainer." :
			inputNumber + " doesn't divides by 5 and 7 without remainer");
	}
}