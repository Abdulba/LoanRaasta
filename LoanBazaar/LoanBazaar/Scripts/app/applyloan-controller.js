var mainAppp = angular.module('LoanBazaarApp', []);
mainAppp.controller('ApplyLoanCtrl', function ($scope, $http) {    
    $scope.CustomerName = '';
    $scope.Mobile = '';
    $scope.Email = '';
    $scope.LoanType = '';
    $scope.LoanAmount = '';
    $scope.EmploymentType = '';
    $scope.Organization = '';
    $scope.Income = '';
    $scope.BalanceTransferAndTopup = '';
    $scope.Outstanding = '';
    $scope.EMILong = '';
    $scope.EMIAmount = '';
    $scope.AnyBounces = '';
    $scope.TopupAmount = '';

    $scope.ClearModels = function () {
        $scope.CustomerName = '';
        $scope.Mobile = '';
        $scope.Email = '';
        $scope.LoanType = '';
        $scope.LoanAmount = '';
        $scope.EmploymentType = '';
        $scope.Organization = '';
        $scope.Income = '';
        $scope.BalanceTransferAndTopup = '';
        $scope.Outstanding = '';
        $scope.EMILong = '';
        $scope.EMIAmount = '';
        $scope.AnyBounces = '';
        $scope.TopupAmount = '';
    };

    $scope.applyloan = function () {
        CustomerDetails = {
            Name: $scope.CustomerName,
            Mobile: $scope.Mobile,
            Email: $scope.Email,
            LoanType: $scope.LoanType,
            LoanAmount: $scope.LoanAmount,
            EmploymentType: $scope.EmploymentType,
            Organization: $scope.Organization,
            Income: $scope.Income,
            BalanceTransferAndTopup: $scope.BalanceTransferAndTopup,
            Outstanding: $scope.Outstanding,
            EMILong: $scope.EMILong,
            EMIAmount: $scope.EMIAmount,
            AnyBounces: $scope.AnyBounces,
            TopupAmount: $scope.TopupAmount,
        }

        //window.alert(CustomerDetails); 

        var req = {
            method: 'POST',
            url: '/api/Customer',
            headers: {
                'Content-Type': 'application/json'
            },
            data: CustomerDetails
        }

        $http(req)
        .then(function () {
            $scope.ClearModels();
            alert("Successfully applied for loan. We will reach you shortly.");            
        },
            function () {
                window.alert('error');
            });


    }
});