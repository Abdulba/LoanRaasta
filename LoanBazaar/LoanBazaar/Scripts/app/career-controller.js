var mainAppp = angular.module('LoanBazaarApp');

mainAppp.controller('CareerCtrl', function ($scope, $http)
{    
        $scope.name = '';
        $scope.email = '';
        $scope.contactNumber = '';
        $scope.company = '';
        $scope.experience = '';       
        //$scope.files = [];

        $scope.getFileDetails = function (e) {

            $scope.files = [];
            $scope.$apply(function () {

                // STORE THE FILE OBJECT IN AN ARRAY.
                for (var i = 0; i < e.files.length; i++) {
                    $scope.files.push(e.files[i])
                }

            });
        };

        $scope.ClearModels = function () {
            $scope.name = '';
            $scope.email = '';
            $scope.contactNumber = '';
            $scope.company = '';
            $scope.experience = '';
            $scope.files = [];
        };

        
        $scope.SaveCandidateDetails = function () {
            CandidateDetails = {
                Name: $scope.name,
                Email: $scope.email,
                Mobile: $scope.contactNumber,
                Company: $scope.company,
                Experience: $scope.experience,
                File : $scope.files[0].name
            }

            var req = {
                method: 'POST',
                url: '/api/Career',
                headers: {
                    'Content-Type': 'application/json'
                },
                data: CandidateDetails
            }

            $http(req)
            .then(function () {                
                $scope.ClearModels();
                document.getElementById("fileResume").value = "";
            },
                function () {
                    window.alert('Some Error in Applying, please try again after sometime')
                });
        }

        $scope.applycareers = function () {                        
            $scope.uploadFiles();            
        }

        $scope.uploadFiles = function () {

            //FILL FormData WITH FILE DETAILS.
            var data = new FormData();

            for (var i in $scope.files) {
                data.append("uploadedFile", $scope.files[i]);
            }

            // ADD LISTENERS.
            var objXhr = new XMLHttpRequest();
            objXhr.addEventListener("progress", updateProgress, false);
            objXhr.addEventListener("load", transferComplete, false);

            // SEND FILE DETAILS TO THE API.
            objXhr.open("POST", "/api/fileupload/UploadFiles");
            objXhr.send(data);
        }

    // UPDATE PROGRESS BAR.
        function updateProgress(e) {
            if (e.lengthComputable) {
                document.getElementById('pro').setAttribute('value', e.loaded);
                document.getElementById('pro').setAttribute('max', e.total);
            }
        }

    // CONFIRMATION.
        function transferComplete(e) {
            $scope.SaveCandidateDetails();
            alert("Thanks for your interest with LoanRaasta. We will reach you shortly.");
        }

    });