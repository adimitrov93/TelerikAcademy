var movingShapes = (function () {
    "use strict";
    var minFont = 12,
        maxFont = 48,
        maxWidth = window.innerWidth/2,
        maxHeight = window.innerHeight/2,
        divWidth = 100,
        divHeight = 70,
        divsByMovement = {
            rect: [],
            ellipse: []
        },
        angle = 0;

    function getRandom(min, max) {
        var random = Math.random();
        return 0 | (random * (max - min) + min);
    }

    function getRandomColor() {
        return "rgb(" + getRandom(0, 256) + ", " +
                        getRandom(0, 256) + ", " +
                        getRandom(0, 256) + ")";
    }

    function addDiv(movement) {
        var div = document.createElement("div"),
            x,
            y;

        x = getRandom(0, maxWidth);
        y = getRandom(0, maxHeight);

        div.innerHTML = "DIV";
        div.style.border = "5px solid " + getRandomColor();
        div.style.fontSize = getRandom(minFont, maxFont) + "px";
        div.style.backgroundColor = getRandomColor();
        div.style.width = divWidth + "px";
        div.style.height = divHeight + "px";
        div.style.position = "absolute";
        div.style.left = x + "px";
        div.style.top = y + "px";
        div.setAttribute("data-start-X", x);
        div.setAttribute("data-start-Y", y);
        document.getElementById("wrapper").appendChild(div);
        divsByMovement[movement].push(div);
        moveDivs();
    }

    function moveDivs() {
        var currentDiv,
            currentDivX,
            currentDivY,
            startX,
            startY,
            step = 5,
            i,
            radius = 100,
            ellipseX,
            ellipseY;

        for (i = 0; i < divsByMovement.rect.length; i++) {
            currentDiv = divsByMovement.rect[i];
            currentDivX = parseInt(currentDiv.style.left);
            currentDivY = parseInt(currentDiv.style.top);
            startX = parseInt(currentDiv.dataset.startX);
            startY = parseInt(currentDiv.dataset.startY);

            if (currentDivY <= startY && currentDivX < startX + divWidth) {
                currentDiv.style.left = currentDivX + step + "px";
            }

            if (currentDivX >= startX + divWidth && currentDivY < startY + divHeight) {
                currentDiv.style.top = currentDivY + step + "px";
            }

            if (currentDivY >= startY + divHeight && currentDivX >= startX) {
                currentDiv.style.left = currentDivX - step + "px";
            }

            if (currentDivX <= startX && currentDivY > startY) {
                currentDiv.style.top = currentDivY - step + "px";
            }
        }

        angle += 0.1;
        for (i = 0; i < divsByMovement.ellipse.length; i++) {
            currentDiv = divsByMovement.ellipse[i];
            startX = parseInt(currentDiv.dataset.startX);
            startY = parseInt(currentDiv.dataset.startY);

            ellipseX = 0 | (startX + 4 * radius * Math.cos(angle));
            ellipseY = 0 | (startY + radius * Math.sin(angle));
            currentDiv.style.left = ellipseX + "px";
            currentDiv.style.top = ellipseY + "px";
        }
    }
    setInterval(moveDivs, 100);

    return {
        add: addDiv
    }
}());

movingShapes.add("rect");
movingShapes.add("ellipse");
movingShapes.add("rect");
movingShapes.add("ellipse");