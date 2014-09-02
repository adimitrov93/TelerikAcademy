window.onload = function () {
    var numberOfDivs = 5;
    createDivs(numberOfDivs);

    var divs = document.getElementsByTagName('div');
    var angles = [];
    var angle = 2 * Math.PI / numberOfDivs;

    for (var i = 0; i < divs.length; i++) {
        angles[i] = angle * i;
    }

    var cx = 500;
    var cy = 250;
    var radius = 150;

    frame();

    function frame() {
        for (var i = 0; i < divs.length; i++) {
            divs[i].style.top = (cy + radius * Math.sin(angles[i])) + 'px';
            divs[i].style.left = (cx + radius * Math.cos(angles[i])) + 'px';

            angles[i]++;
        }

        setInterval(frame, 100);
    }

    function createDivs(numberOfDivs) {
        var div = document.createElement('div');
        div.innerHTML = 'div';
        div.style.display = 'inline';
        div.style.position = 'absolute';
        div.style.padding = '10px';

        var docFragment = document.createDocumentFragment();

        for (var i = 0; i < numberOfDivs; i++) {
            div.style.backgroundColor = getRandomColor();

            docFragment.appendChild(div.cloneNode(true));
        }

        document.body.appendChild(docFragment);
    }

    function getRandomNumber(min, max) {
        return Math.floor(Math.random() * (max - min) + min);
    }

    function getRandomColor() {
        var red = getRandomNumber(0, 255);
        var green = getRandomNumber(0, 255);
        var blue = getRandomNumber(0, 255);

        return 'rgb(' + red + ', ' + green + ', ' + blue + ')';
    }
};