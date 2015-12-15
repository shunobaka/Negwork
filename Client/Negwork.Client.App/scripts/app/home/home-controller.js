(function() {
    'use strict';

	function HomeController() {
	    var vm = this;
		vm.hi = 'Hello';
	}

    angular.module('negwork.controllers')
		.controller('HomeController', [HomeController]);
}());