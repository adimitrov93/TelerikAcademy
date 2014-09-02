var persisters = (function ($) {
    var nickname = '';
    var sessionKey = '';

    var saveUserData = function (userData) {
        localStorage.setItem('nickname', userData.nickname);
        localStorage.setItem('sessionKey', userData.sessionKey);
        nickname = userData.nickname;
        sessionKey = userData.sessionKey;
    };

    var clearUserData = function () {
        localStorage.removeItem('nickname');
        localStorage.removeItem('sessionKey');
        nickname = '';
        sessionKey = '';
    };

    var MainPersister = (function () {
        function MainPersister(baseUrl) {
            this.baseUrl = baseUrl;
            this.user = new UserPersister(this.baseUrl);
            this.game = new GamePersister(this.baseUrl);
        }

        return MainPersister;
    })();

    var UserPersister = (function () {
        function UserPersister(baseUrl) {
            this.baseUrl = baseUrl + 'user/';
        }

        UserPersister.prototype.register = function (username, nickname, password) {
            var url = this.baseUrl + 'register';
            var user = {
                username: username,
                nickname: nickname,
                authCode: CryptoJS.SHA1(password).toString()
            };

            httpRequester.post(url, user).then(function (data) {
                saveUserData(data);
                console.log(data);
            });
        };

        UserPersister.prototype.login = function (username, password) {
            var url = this.baseUrl + 'login';
            var user = {
                username: username,
                authCode: CryptoJS.SHA1(password).toString()
            };

            httpRequester.post(url, user).then(function (data) {
                saveUserData(data);
                console.log(data);
            });
        };

        return UserPersister;
    })();

    var GamePersister = (function () {
        function GamePersister(baseUrl) {
            this.baseUrl = baseUrl + 'game/';
        }

        GamePersister.prototype.open = function () {
            var url = this.baseUrl + 'open/' + localStorage.getItem('sessionKey');
            httpRequester.get(url).then(function (data) {
                console.log(data);
                $.ajax({
                    url: 'templates/open-games-template.html',
                    type: 'GET',
                    dataType: 'TEXT',
                    success: function (source) {
                        var template = Handlebars.compile(source);
                        
                        $.ajax({
                            url: 'templates/games-template.html',
                            type: 'GET',
                            dataType: 'TEXT',
                            success: function (partial) {
                                Handlebars.registerPartial('games', partial);
                                var html = template({ games: data });
                                $(document.body).append(html);
                            }
                        });
                    }
                });
            });
        };

        return GamePersister;
    })();

    return {
        get: function (url) {
            return new MainPersister(url);
        }
    };
})(jQuery);