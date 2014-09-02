(function ($) {
    $(function () {
        var refreshChat = function () {
            $.get('http://crowd-chat.herokuapp.com/posts', function (data) {
                var source = $("#chat-item-template").html();
                var template = Handlebars.compile(source);
                var html = template({messages: data});

                $('#chat-items-container').empty().append(html);

                var chatItemsContainer = document.getElementById("chat-items-container");
                chatItemsContainer.scrollTop = chatItemsContainer.scrollHeight;
            });
        };

        refreshChat();
        setInterval(refreshChat, 10000);

        var sendMessage = function () {
            var $messageField = $('#message-field');

            if ($messageField.val() !== '') {
                var message = {
                    user: 'Me',
                    text: $messageField.val()
                };

                $messageField.val('');

                $.post('http://crowd-chat.herokuapp.com/posts', message, function (data) {
                    if (data) {
                        refreshChat();
                    }
                });
            }
        };

        $('#send-btn').on('click', sendMessage);
        $('#message-field').on('change', sendMessage);
    });
})(jQuery);