function calculateTrapezoidsArea() {
	var a = parseInt(document.getElementById("a").value),
		b = parseInt(document.getElementById("b").value),
		h = parseInt(document.getElementById("h").value);

	if (!(isNaN(a) || isNaN(b) || isNaN(h))) {		// Converted by the De Morgan's Theorem like in task 3
		var area = ((a + b) / 2) * h;

		jsConsole.writeLine("Area is " + area);
	}
}