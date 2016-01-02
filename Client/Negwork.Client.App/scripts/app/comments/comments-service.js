(function () {
    'use strict';

    var commentsService = function commentsService(data) {
        var COMMENTS_API_URL = '/api/comments';

        function add(comment) {
            return data.post(COMMENTS_API_URL, comment);
        }

        return {
            add: add
        };
    }

    angular
        .module('negwork.services')
        .factory('comments', ['data', commentsService])
}());