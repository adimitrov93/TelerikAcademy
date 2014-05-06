function check() {
	var inputNumber = parseInt(document.getElementById('input-field').value);

	if (!isNaN(inputNumber)) {
		jsConsole.writeLine(inputNumber % 2 === 0 ? 'Even' : 'Odd');
	}
}