(function () {
    requirejs.config({
        baseUrl: 'scripts',
        paths: {
            jquery: 'libs/jquery',
            q: 'libs/q',
            handlebars: 'libs/handlebars',
            underscore: 'libs/underscore',
            cryptojs: 'libs/sha1'
        }
    });
})();

require(['controllers'], function (controllers) {
    var controller = controllers.get('http://localhost:3000/');
    controller.loadUI('#wrapper');
});

//require(['persisters'], function (persisters) {
//    var persister = persisters.get('http://jsapps.bgcoder.com/');
////    persister.user.login('revention', '123');
//    // persister.user.register();
//    persister.posts.get();
//});