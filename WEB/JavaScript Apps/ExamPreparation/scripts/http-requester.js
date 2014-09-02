var httpRequester = (function ($) {
    var makeRequest = function (url, type, data) {
        var deferred = Q.defer();
        
        var ajaxOptions = {
            url: url,
            type: type,
            dataType: 'JSON',
            success: function (data) {
                deferred.resolve(data);
            },
            error: function (error) {
                deferred.reject(error);
            }
        };
        
        if (data) {
            ajaxOptions.data = data;
        }
        
        $.ajax(ajaxOptions);
        
        return deferred.promise;
    };

    var get = function(url) {
        return makeRequest(url, 'GET');
    };

    var post = function(url, data) {
        return makeRequest(url, 'POST', data);
    };

    return {
        get: get,
        post: post
    };
})(jQuery);