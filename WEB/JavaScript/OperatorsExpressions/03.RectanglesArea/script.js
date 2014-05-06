function calculateRectanglesArea() {
	var width = parseInt(document.getElementById("width").value);
	var height = parseInt(document.getElementById("height").value);

	if (!(isNaN(width) || isNaN(height))) {		// Converted from ((!isNaN(width)) && (!isNaN(height))) to (!(isNaN(width) || isNaN(height))) by the De Morgan's Theorem
		var area = width * height;
		jsConsole.writeLine("Area is " + area);
	}
}