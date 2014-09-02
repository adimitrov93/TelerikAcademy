(function () {
    var canvas = document.getElementById("the-canvas");
    var ctx = canvas.getContext("2d");

    drawHouse();
    drawHead();
    drawBycicle();

    function drawHouse() {
        ctx.lineWidth = 3;

        var houseWidth = 300;
        var houseHeight = 250;
        var houseX = 900;
        var houseY = 300;

        var windowsWidth = 120;
        var windowsHeight = 80;
        var spaceBetweenWindowsX = ((houseWidth - (2 * windowsWidth)) / 4);
        var spaceBetweenWindowsY = ((houseHeight - (2 * windowsHeight)) / 5);
        var topLeftWindowX = houseX + spaceBetweenWindowsX;
        var topLeftWindowY = houseY + spaceBetweenWindowsY;

        var doorWidth = 100;
        var doorHeight = houseHeight - (windowsHeight + (spaceBetweenWindowsY * 4));
        var topLeftDoorX = (topLeftWindowX + (windowsWidth / 2)) - (doorWidth / 2);
        var topLeftDoorY = houseY + houseHeight - doorHeight;
        var middleDoorX = (topLeftDoorX + (doorWidth / 2));
        var middleDoorY = (topLeftDoorY + (doorHeight / 2));
        var controlPoint1X = topLeftDoorX;
        var controlPoint1Y = topLeftDoorY - spaceBetweenWindowsY * 2;
        var controlPoint2X = topLeftDoorX + doorWidth;
        var controlPoint2Y = topLeftDoorY - spaceBetweenWindowsY * 2;
        var doorHandleRadius = 5;

        var chimneyWidth = spaceBetweenWindowsX * 2;
        var chimneyHeight = houseHeight / 2;
        var chimneyBottomLeftX = houseX + windowsWidth + (5 * spaceBetweenWindowsX);
        var chimneyBottomLeftY = houseY - (2 * spaceBetweenWindowsY);
        var chimneyMiddleTopX = chimneyBottomLeftX + (chimneyWidth / 2);
        var chimneyMiddleTopY = chimneyBottomLeftY - chimneyHeight;

        drawSquareOfTheHouse();
        drawWindows();
        drawDoor();
        drawChimney();

        function drawSquareOfTheHouse() {
            ctx.strokeStyle = '#000';
            ctx.fillStyle = '#975B5B';

            ctx.beginPath();

            ctx.rect(houseX, houseY, houseWidth, houseHeight);
            ctx.lineTo((houseX + houseWidth / 2), (houseHeight / 2));
            ctx.lineTo((houseX + houseWidth), houseY);

            ctx.fill();
            ctx.stroke();
        }

        function drawWindows() {
            ctx.strokeStyle = '#975B5B';
            ctx.fillStyle = '#000';

            ctx.beginPath();
            ctx.save();

            ctx.rect(topLeftWindowX, topLeftWindowY, windowsWidth, windowsHeight);

            ctx.moveTo(topLeftWindowX, topLeftWindowY + (windowsHeight / 2));
            ctx.lineTo(topLeftWindowX + windowsWidth, topLeftWindowY + (windowsHeight / 2));

            ctx.moveTo(topLeftWindowX + (windowsWidth / 2), topLeftWindowY);
            ctx.lineTo(topLeftWindowX + (windowsWidth / 2), topLeftWindowY + windowsHeight);

            ctx.translate(windowsWidth + ((houseWidth - (2 * windowsWidth)) / 2), 0);

            ctx.rect(topLeftWindowX, topLeftWindowY, windowsWidth, windowsHeight);

            ctx.moveTo(topLeftWindowX, topLeftWindowY + (windowsHeight / 2));
            ctx.lineTo(topLeftWindowX + windowsWidth, topLeftWindowY + (windowsHeight / 2));

            ctx.moveTo(topLeftWindowX + (windowsWidth / 2), topLeftWindowY);
            ctx.lineTo(topLeftWindowX + (windowsWidth / 2), topLeftWindowY + windowsHeight);

            ctx.translate(0, windowsHeight + spaceBetweenWindowsY);

            ctx.rect(topLeftWindowX, topLeftWindowY, windowsWidth, windowsHeight);

            ctx.moveTo(topLeftWindowX, topLeftWindowY + (windowsHeight / 2));
            ctx.lineTo(topLeftWindowX + windowsWidth, topLeftWindowY + (windowsHeight / 2));

            ctx.moveTo(topLeftWindowX + (windowsWidth / 2), topLeftWindowY);
            ctx.lineTo(topLeftWindowX + (windowsWidth / 2), topLeftWindowY + windowsHeight);

            ctx.restore();

            ctx.fill();
            ctx.stroke();
        }

        function drawDoor() {
            ctx.strokeStyle = '#000';
            ctx.fillStyle = '#975B5B';

            ctx.beginPath();

            ctx.moveTo(topLeftDoorX, topLeftDoorY + doorHeight);

            ctx.lineTo(topLeftDoorX, topLeftDoorY);
            ctx.bezierCurveTo(controlPoint1X, controlPoint1Y, controlPoint2X, controlPoint2Y, topLeftDoorX + doorWidth, topLeftDoorY);
            ctx.lineTo(topLeftDoorX + doorWidth, topLeftDoorY + doorHeight);

            ctx.moveTo(topLeftDoorX + (doorWidth / 2), topLeftDoorY - spaceBetweenWindowsY * 1.5);
            ctx.lineTo(topLeftDoorX + (doorWidth / 2), houseY + houseHeight);

            ctx.stroke();

            ctx.beginPath();
            ctx.arc(middleDoorX - spaceBetweenWindowsX, middleDoorY, doorHandleRadius, 0, 2 * Math.PI);
            ctx.stroke();

            ctx.beginPath();
            ctx.arc(middleDoorX + spaceBetweenWindowsX, middleDoorY, doorHandleRadius, 0, 2 * Math.PI);
            ctx.stroke();
        }

        function drawChimney() {
            ctx.beginPath();

            ctx.moveTo(chimneyBottomLeftX, chimneyBottomLeftY);
            ctx.lineTo(chimneyBottomLeftX, chimneyBottomLeftY - chimneyHeight);

            ctx.lineTo(chimneyBottomLeftX + chimneyWidth, chimneyBottomLeftY - chimneyHeight);
            ctx.lineTo(chimneyBottomLeftX + chimneyWidth, chimneyBottomLeftY);

            ctx.fill();
            ctx.stroke();

            ctx.beginPath();
            ctx.save();
            ctx.scale(1, 0.2);
            // Here is * 5 because of the scale 0.2
            ctx.arc(chimneyMiddleTopX, chimneyMiddleTopY * 5, chimneyWidth / 2, 0, 2 * Math.PI);
            ctx.restore();
            ctx.fill();
            ctx.stroke();
        }
    }

    function drawHead() {
        var headCenterX = 250;
        var headCenterY = 250;
        var headRadius = 80;

        drawFace();
        drawHat();

        function drawFace() {
            ctx.fillStyle = '#90CAD7';
            ctx.strokeStyle = '#1F515B';

            ctx.beginPath();
            ctx.save();
            ctx.scale(1.1, 1);
            ctx.arc(headCenterX, headCenterY, headRadius, 0, 2 * Math.PI);
            ctx.restore();
            ctx.fill();
            ctx.stroke();

            ctx.beginPath();
            ctx.save();
            ctx.scale(1.3, 1);
            ctx.arc(headCenterX - 80, headCenterY - 20, headRadius / 8, 0, 2 * Math.PI);
            ctx.restore();
            ctx.stroke();
            
            ctx.fillStyle = ctx.strokeStyle;
            ctx.beginPath();
            ctx.save();
            ctx.scale(1, 1.5);
            ctx.arc(headCenterX - 32, headCenterY - 97, headRadius / 15, 0, 2 * Math.PI);
            ctx.restore();
            ctx.fill();
            ctx.stroke();

            ctx.save();
            ctx.translate(60, 0);

            ctx.beginPath();
            ctx.save();
            ctx.scale(1.3, 1);
            ctx.arc(headCenterX - 80, headCenterY - 20, headRadius / 8, 0, 2 * Math.PI);
            ctx.restore();
            ctx.stroke();

            ctx.fillStyle = ctx.strokeStyle;
            ctx.beginPath();
            ctx.save();
            ctx.scale(1, 1.5);
            ctx.arc(headCenterX - 32, headCenterY - 97, headRadius / 15, 0, 2 * Math.PI);
            ctx.restore();
            ctx.fill();
            ctx.stroke();

            ctx.restore();

            ctx.beginPath();

            ctx.save();
            ctx.rotate(15 * Math.PI / 180);
            ctx.scale(2.5, 1);

            ctx.arc(headCenterX - 120, headCenterY - 30, headRadius / 6, 0, 2 * Math.PI);

            ctx.restore();
            ctx.stroke();

            ctx.beginPath();

            ctx.moveTo(headCenterX, headCenterY + 10);
            ctx.lineTo(headCenterX - 10, headCenterY + 10);
            ctx.lineTo(headCenterX, headCenterY - 20);

            ctx.stroke();
        }

        function drawHat() {
            ctx.fillStyle = '#396693';
            ctx.strokeStyle = '#262625';

            ctx.beginPath();

            ctx.save();
            ctx.scale(6, 1);
            ctx.arc(46, headCenterY - headRadius + 5, headRadius / 4, 0, 2 * Math.PI);
            ctx.restore();

            ctx.fill();
            ctx.stroke();

            ctx.fillRect(225, headCenterY - 188, 120, 100);
            ctx.strokeRect(225, headCenterY - 188, 120, 100);

            ctx.beginPath();

            ctx.save();
            ctx.scale(3, 1);
            ctx.arc(95, headCenterY - headRadius - 10, headRadius / 4, 0, Math.PI);
            ctx.restore();

            ctx.fill();
            ctx.stroke();

            ctx.save();
            ctx.translate(0, -100);

            ctx.beginPath();

            ctx.save();
            ctx.scale(3, 1);
            ctx.arc(95, headCenterY - headRadius - 10, headRadius / 4, 0, 2 * Math.PI);
            ctx.restore();

            ctx.fill();
            ctx.stroke();

            ctx.restore();
        }
    }

    function drawBycicle() {
        ctx.fillStyle = '#90CAD7';
        ctx.strokeStyle = '#348194';

        var leftWheelCenterX = 300;
        var rightWheelCenterX = 550;
        var wheelsCenterY = 700;
        var wheelsRadius = 60;

        var pedalWheelCenterX = leftWheelCenterX + 110;
        var pedalWheelCenterY = wheelsCenterY;
        var pedalWheelRadius = 20;

        drawWheels();
        drawFrame();

        function drawWheels() {
            ctx.beginPath();

            ctx.arc(leftWheelCenterX, wheelsCenterY, wheelsRadius, 0, 2 * Math.PI);

            ctx.fill();
            ctx.stroke();

            ctx.beginPath();

            ctx.arc(rightWheelCenterX, wheelsCenterY, wheelsRadius, 0, 2 * Math.PI);

            ctx.fill();
            ctx.stroke();

            ctx.beginPath();

            ctx.arc(pedalWheelCenterX, pedalWheelCenterY, pedalWheelRadius, 0, 2 * Math.PI);

            ctx.stroke();
        }

        function drawFrame() {
            ctx.beginPath();

            ctx.moveTo(leftWheelCenterX, wheelsCenterY);
            ctx.lineTo(pedalWheelCenterX, pedalWheelCenterY);
            ctx.lineTo(pedalWheelCenterX - 50, pedalWheelCenterY - 100);
            ctx.closePath();

            ctx.stroke();

            ctx.beginPath();

            ctx.moveTo(rightWheelCenterX, wheelsCenterY);
            ctx.lineTo(rightWheelCenterX - 20, wheelsCenterY - 100);
            ctx.lineTo(pedalWheelCenterX - 50, pedalWheelCenterY - 100);
            ctx.moveTo(pedalWheelCenterX, pedalWheelCenterY);
            ctx.lineTo(rightWheelCenterX - 20, wheelsCenterY - 100);

            ctx.stroke();

            ctx.beginPath();

            ctx.moveTo(rightWheelCenterX - 20, wheelsCenterY - 100);
            ctx.lineTo(rightWheelCenterX - 30, wheelsCenterY - 150);
            ctx.moveTo(rightWheelCenterX, wheelsCenterY - 200);
            ctx.lineTo(rightWheelCenterX - 30, wheelsCenterY - 150);
            ctx.lineTo(rightWheelCenterX - 80, wheelsCenterY - 120);

            ctx.stroke();

            ctx.beginPath();

            ctx.moveTo(pedalWheelCenterX - 50, pedalWheelCenterY - 100);
            ctx.lineTo(pedalWheelCenterX - 70, pedalWheelCenterY - 140);
            ctx.moveTo(pedalWheelCenterX - 100, pedalWheelCenterY - 140);
            ctx.lineTo(pedalWheelCenterX - 40, pedalWheelCenterY - 140)

            ctx.stroke();

            ctx.beginPath();

            ctx.moveTo(pedalWheelCenterX - 30, pedalWheelCenterY - 30);
            ctx.lineTo(pedalWheelCenterX - 15, pedalWheelCenterY - 15);
            ctx.moveTo(pedalWheelCenterX + 15, pedalWheelCenterY + 15);
            ctx.lineTo(pedalWheelCenterX + 30, pedalWheelCenterY + 30);

            ctx.stroke();
        }
    }
})();