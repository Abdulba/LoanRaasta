var mainAppp = angular.module('LoanBazaarApp', []);
mainAppp.controller('CareerCtrl', function ($scope) {
    $scope.Test = 'Test Message';
        $scope.name = '';
        $scope.email = '';
        $scope.cover = '';
        $scope.content = '';

        $scope.submitresume = function () {
            window.alert($scope.name);
            window.alert($scope.email);
            window.alert($scope.cover);
            window.alert($scope.content);
        }
    });