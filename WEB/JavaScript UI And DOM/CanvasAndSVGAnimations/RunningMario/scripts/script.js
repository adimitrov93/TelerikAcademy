(function () {
    var stage = new Kinetic.Stage({
        container: 'container',
        width: 800,
        height: 320
    });

    var layer = new Kinetic.Layer();

    var animations = {
        idleLeft: [{
            x: 169,
            y: 76,
            width: 15,
            height: 28
        }],
        idleRight: [{
            x: 208,
            y: 76,
            width: 15,
            height: 28
        }],
        runLeft: [{
            x: 48,
            y: 76,
            width: 16,
            height: 27
        }, {
            x: 169,
            y: 76,
            width: 15,
            height: 28
        }],
        runRight: [{
            x: 328,
            y: 76,
            width: 16,
            height: 27
        }, {
            x: 208,
            y: 76,
            width: 15,
            height: 28
        }]
    };

    var imageObj = new Image();

    imageObj.onload = function () {
        var mario = new Kinetic.Sprite({
            x: 300,
            y: 280,
            image: imageObj,
            animation: 'idleRight',
            animations: animations,
            frameRate: 7,
            index: 0
        });

        layer.add(mario);
        stage.add(layer);
        mario.start();

        document.body.addEventListener('keydown', function (e) {
            if (e.keyCode === 37) {
                mario.setAnimation('runLeft');
                mario.setX(mario.attrs.x - 5);
            }
            else if (e.keyCode === 39) {
                mario.setAnimation('runRight');
                mario.setX(mario.attrs.x + 5);
            }
        }, false);
        document.body.addEventListener('keyup', function () {
            if (mario.attrs.animation === 'runLeft') {
                mario.setAnimation('idleLeft');
            }
            else {
                mario.setAnimation('idleRight');
            }
        }, false);
    };

    imageObj.src = 'http://store.picbg.net/pubpic/DD/FF/fcfd53a61478ddff.png';
})();