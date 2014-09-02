(function () {
    var paper = Raphael(200, 100, 600, 600);

    var pathX = 200;
    var pathY = 200;
    var pathRadius = 0;
    var angle = 0;

    var cx = 0;
    var cy = 0;
    var radius = 1;

    for (var i = 0; i < 20000; i++) {
        cx = pathX + pathRadius * Math.cos(angle * Math.PI / 180);
        cy = pathY + pathRadius * Math.sin(angle * Math.PI / 180);

        var circle = paper.circle(cx, cy, radius);
        circle.attr({
            fill: '#000'
        });

        angle += 0.1;
        pathRadius += 0.01;
    }
})();