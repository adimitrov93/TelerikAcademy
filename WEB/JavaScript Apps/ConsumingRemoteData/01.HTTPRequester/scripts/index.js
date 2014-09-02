(function ($) {
    'use strict';

    $(function () {
        httpRequester.getJSON('data/data.js').then(function (data) {
            var source = $("#student-template").html();
            var template = Handlebars.compile(source);
            var html = template({ students: data });

            $('#students-container').append(html);
        }, function (error) {
            console.log(error);
        });
    });
})(jQuery);