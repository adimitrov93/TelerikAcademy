(function ($) {
    $(function () {
        $('#get-tweets-btn').on('click', function () {
            var data = JSON.stringify({
                "consumerKey": $('#consumer-key-input').val(),
                "consumerSecret": $('#consumer-secret-input').val(),
                "accessToken": $('#access-token-input').val(),
                "accessTokenSecret": $('#access-token-secret-input').val(),
                "username": $('#screen-name-input').val(),
                "count": $('#tweets-count-input').val()
            });

            $.ajax({
                url: 'http://localhost:3000/tweets',
                type: 'POST',
                data: data,
                contentType: "application/json",
                success: function (data) {
                    $('#tweets-container').empty();

                    var source = $("#tweet-template").html();
                    var template = Handlebars.compile(source);
                    var html = template({ tweets: JSON.parse(data) });

                    $('#tweets-container').append(html);
                },
                error: function (error) {
                    alert('You entered invalid data or you have no Internet connection or you have not started the server.');
                }
            });
        });

        alert('You must start the server from server/index.js before using the app.');
    });
})(jQuery);