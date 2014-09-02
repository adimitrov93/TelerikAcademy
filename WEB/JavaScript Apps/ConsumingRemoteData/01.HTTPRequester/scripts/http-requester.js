var httpRequester = (function ($) {
    'use strict';

    var getJSON = function (url, headers) {
        var deferred = Q.defer();

        $.ajax({
            url: url,
            type: "GET",
            timeout: 5000,
            dataType: 'json',
            headers: headers,
            success: function (data) {
                deferred.resolve(data);
            },
            error: function (error) {
                deferred.reject(error);
            }
        });

        return deferred.promise;
    };
    
    var postJSON = function (url, data, headers) {
        var deferred = Q.defer();

        $.ajax({
            url: url,
            type: "POST",
            timeout: 5000,
            dataType: 'json',
            data: data,
            headers: headers,
            success: function (data) {
                deferred.resolve(data);
            },
            error: function (error) {
                deferred.reject(error);
            }
        });

        return deferred.promise;
    };

    return {
        getJSON: getJSON,
        postJSON: postJSON
    };
})(jQuery);