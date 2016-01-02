(function () {
    'use strict';

    var profileSettingsController = function profileSettingsController(auth, notifier, users) {
        var vm = this;
        vm.DefaultProfile = 'https://diasp.eu/assets/user/default.png';

        auth.getIdentity()
            .then(function (user) {
                vm.currentUser = user;
            }, function () {
                notifier.error('There was a problem editing your profile. Please try again.');
            });

        vm.saveChanges = function () {
            vm.currentUser.ProfileImage = vm.newProfileImage;

            users.updateUserInfo(vm.currentUser)
                .then(function () {
                    notifier.success('Profile was updated successfully!');
                }, function (err) {
                    notifier.error(err);
                });
        };
    }

    angular
        .module('negwork.controllers')
        .controller('ProfileSettingsController', ['auth', 'notifier', 'users', profileSettingsController]);
}());