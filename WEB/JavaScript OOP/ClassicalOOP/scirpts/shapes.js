var Shapes = (function () {
    var Shape = (function () {
        function Shape(x, y) {
            this._startPos = {
                x: x,
                y: y
            };
        }

        Shape.prototype.getContext = function () {
            var canvas = document.getElementById('the-canvas');
            var ctx = canvas.getContext('2d');
            ctx.strokeStyle = 'green';

            return ctx;
        }

        return Shape;
    })();

    var Rect = (function () {
        function Rect(x, y, width, height) {
            var self = this;

            Shape.call(self, x, y);
            self._width = width;
            self._height = height;
        }

        Rect.prototype = new Shape();
        Rect.prototype.draw = function () {
            var ctx = this.getContext();

            ctx.strokeRect(this._startPos.x, this._startPos.y, this._width, this._height);
        };

        return Rect;
    })();

    var Circle = (function () {
        function Circle(x, y, radius) {
            var self = this;

            Shape.call(self, x, y);
            self._radius = radius;
        }

        Circle.prototype = new Shape();
        Circle.prototype.draw = function () {
            var ctx = this.getContext();

            ctx.arc(this._startPos.x, this._startPos.y, this._radius, 0, Math.PI * 2);
            ctx.stroke();
        };

        return Circle;
    })();

    var Line = (function () {
        function Line(x1, y1, x2, y2) {
            var self = this;

            Shape.call(self, x1, y1);
            self._endPos = {
                x: x2,
                y: y2
            };
        }

        Line.prototype = new Shape();
        Line.prototype.draw = function () {
            var ctx = this.getContext();

            ctx.beginPath();

            ctx.moveTo(this._startPos.x, this._startPos.y);
            ctx.lineTo(this._endPos.x, this._endPos.y);

            ctx.stroke();
        };

        return Line;
    })();

    return {
        Rect: Rect,
        Circle: Circle,
        Line: Line
    };
})();