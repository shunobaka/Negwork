(function() {
    'use strict';

	function HomeController(auth, articles) {
	    var vm = this;

	    vm.isAuthenticated = auth.isAuthenticated();

	    auth.getIdentity()
            .then(function (user) {
                vm.user = user;
            });

	    articles.search()
            .then(function (articlesResult) {
                vm.articles = articlesResult;
            });
	}

    angular.module('negwork.controllers')
		.controller('HomeController', ['auth', 'articles', HomeController]);
}());