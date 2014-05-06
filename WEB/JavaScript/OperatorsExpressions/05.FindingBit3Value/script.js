function check() {
	var inputNumber = parseInt(document.getElementById("input-field").value);
	var result = (inputNumber >> 3) & 1;

	jsConsole.writeLine(result === 1 ? "Bit 3 is 1" : "Bit 3 is 0");
}