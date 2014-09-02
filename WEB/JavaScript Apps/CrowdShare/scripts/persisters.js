define(['http-requester', 'q', 'cryptojs'], function (httpRequester, Q) {
    var MainPersister = (function () {
        function MainPersister(baseUrl, templateUrl) {
            this.baseUrl = baseUrl;
            this.user = new UserPersister(this.baseUrl);
            this.posts = new PostsPersister(this.baseUrl);
        }
        
        MainPersister.prototype.isUserLoggedIn = function () {
            return (localStorage.getItem('username') && localStorage.getItem('sessionKey')) != null;
        };

        return MainPersister;
    })();

    var UserPersister = (function () {
        function UserPersister(baseUrl) {
            this.baseUrl = baseUrl + 'user';
            this.loginUrl = baseUrl + 'auth';
        }

        UserPersister.prototype.register = function (username, password) {
            var deferred = Q.defer();
            var userData = generateUserData(username, password);

            httpRequester.postJSON(this.baseUrl, userData).then(function (data) {
                deferred.resolve(data);
            }, function (error) {
                deferred.reject(extractErrorMessage(error));
            });
            
            return deferred.promise;
        };

        UserPersister.prototype.login = function (username, password) {
            var deferred = Q.defer();
            var userData = generateUserData(username, password);

            httpRequester.postJSON(this.loginUrl, userData).then(function (data) {
                saveSessionData(data);
                deferred.resolve(true);
            }, function (error) {
                deferred.reject(extractErrorMessage(error));
            });
            
            return deferred.promise;
        };

        UserPersister.prototype.logout = function () {
            var deferred = Q.defer();
            var headers = generateHeaders();

            httpRequester.putJSON(this.baseUrl, headers).then(function (data) {
                clearSessionData();
                deferred.resolve(data);
            }, function (error) {
                deferred.reject(extractErrorMessage(error));
            });

            return deferred.promise;
        };

        return UserPersister;
    })();

    var PostsPersister = (function () {
        function PostsPersister(baseUrl) {
            this.baseUrl = baseUrl + 'post';
        }

        PostsPersister.prototype.get = function (filterOptions) {
            var deferred = Q.defer();
            var url = this.baseUrl;

            if (filterOptions) {
                url += '?';

                if (filterOptions.user) {
                    url += ('user=' + filterOptions.user);
                }

                if (filterOptions.pattern) {
                    url += (filterOptions.user ? '&' : '');

                    url += ('pattern=' + filterOptions.pattern);
                }
            }

            httpRequester.getJSON(url).then(function (data) {
                deferred.resolve(data);
            }, function (error) {
                deferred.reject(extractErrorMessage(error));
            });

            return deferred.promise;
        };

        PostsPersister.prototype.create = function (title, body) {
            var deferred = Q.defer();
            var postData = {
                title: title,
                body: body
            };
            var headers = generateHeaders();

            httpRequester.postJSON(this.baseUrl, postData, headers).then(function (data) {
                deferred.resolve(data);
            }, function (error) {
                deferred.reject(extractErrorMessage(error));
            });

            return deferred.promise;
        };

        return PostsPersister;
    })();

    var saveSessionData = function (userData) {
        localStorage.setItem('username', userData.username);
        localStorage.setItem('sessionKey', userData.sessionKey);
    };

    var clearSessionData = function () {
        localStorage.removeItem('username');
        localStorage.removeItem('sessionKey');
    };

    var generateUserData = function (username, password) {
        return {
            username: username,
            authCode: CryptoJS.SHA1(username + password).toString()
        };
    };

    var generateHeaders = function () {
        return {
            'X-SessionKey': localStorage.getItem('sessionKey')
        };
    };

    var extractErrorMessage = function (error) {
        return JSON.parse(error.responseText).message;
    };

    return {
        get: function (url) {
            return new MainPersister(url);
        }
    }
});