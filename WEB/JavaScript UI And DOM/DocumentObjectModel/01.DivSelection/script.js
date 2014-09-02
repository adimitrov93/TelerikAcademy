(function () {
    var selectedWithQuerySelector = selectDivsWithQuerySelector();
    var selectedWithGetElementsByTagName = selectDivsWithGetElementsByTagName();
})();

function selectDivsWithQuerySelector() {
    var divs = document.querySelectorAll("div > div");

    return divs;
}

function selectDivsWithGetElementsByTagName() {
    var divs = document.getElementsByTagName("div");
    var innerDivs = [];
    
    for (var i = 0; i < divs.length; i++) {
        if (divs[i].parentNode.localName === "div") {
            innerDivs.push(divs[i]);
        }
    }

    return innerDivs;
}