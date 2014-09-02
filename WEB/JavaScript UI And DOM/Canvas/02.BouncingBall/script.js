(function () {
    var canvas = document.getElementById("the-canvas");

    var canvasWidth = 1500;
    var canvasHeight = 800;
    canvas.style.width = canvasWidth;
    canvas.style.height = canvasHeight;

    var ctx = canvas.getContext("2d");

    var position = {
        x: Math.floor(Math.random() * canvasWidth),
        y: Math.floor(Math.random() * canvasHeight)
    };
    var direction = {
        x: Math.random() < 0.5 ? -1 : 1,
        y: Math.random() < 0.5 ? -1 : 1
    };
    var speed = 3;
    var ballRadius = 10;
    randomColor();

    animationFrame();

    function animationFrame() {
        ctx.clearRect(0, 0, canvasWidth, canvasHeight);

        ctx.beginPath();
        ctx.arc(position.x, position.y, ballRadius, 0, 2 * Math.PI);
        ctx.fill();

        var newPositionX = position.x + (direction.x * speed);

        if (newPositionX + ballRadius > canvasWidth || newPositionX - ballRadius < 0) {
            direction.x = -direction.x;
            randomColor();
        }

        var newPositionY = position.y + (direction.y * speed);

        if (newPositionY + ballRadius > canvasHeight || newPositionY - ballRadius < 0) {
            direction.y = -direction.y;
            randomColor();
        }

        position.x = newPositionX;
        position.y = newPositionY;

        requestAnimationFrame(animationFrame);
    }

    function randomColor() {
        var red = Math.floor(Math.random() * 255);
        var green = Math.floor(Math.random() * 255);
        var blue = Math.floor(Math.random() * 255);

        ctx.fillStyle = 'rgb(' + red + "," + green + ',' + blue + ')';
    }
})();