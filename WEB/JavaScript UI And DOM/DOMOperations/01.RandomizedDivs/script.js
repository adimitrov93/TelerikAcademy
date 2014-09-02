window.onload = function () {
    var generateBtn = document.getElementById('generate-btn');
    var clearBtn = document.getElementById('clear-btn');

    generateBtn.addEventListener('click', function () {
        var numberOfDivs = parseInt(document.getElementById('number-of-divs').value);
        var documentFragment = document.createDocumentFragment();

        var div = document.createElement('div');
        div.innerHTML = '<strong>div</strong>';

        for (var i = 0; i < numberOfDivs; i++) {
            div.style.width = getRandomNumber(20, 100) + 'px';
            div.style.height = getRandomNumber(20, 100) + 'px';
            div.style.backgroundColor = getRandomColor();
            div.style.color = getRandomColor();
            div.style.position = 'absolute';
            div.style.left = getRandomNumber(0, 1500) + 'px';
            div.style.top = getRandomNumber(0, 750) + 'px';
            div.style.borderRadius = getRandomNumber(0, 15) + 'px';
            div.style.borderColor = getRandomColor();
            div.style.borderWidth = getRandomNumber(0, 15) + 'px';

            documentFragment.appendChild(div.cloneNode(true));
        }

        document.body.appendChild(documentFragment);
    });

    clearBtn.addEventListener('click', function () {
        var divs = document.getElementsByTagName('div');

        for (var i = 0, length = divs.length; i < length; i++) {
            divs[i].parentNode.removeChild(divs[i]);
            i--;
        }
    });

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