angular.module('voteApp').controller('homeController', ['$scope', '$timeout', '$http', 'voterService',
    function ($scope, $timeout, $http, voterService) {

        /*------------------- Properties ----------------------------------*/
        //Properties
        $scope.userInvalid = false;
        $scope.userInfoSubmitDisabled = true;
        $scope.user = {};
        /*------------------- Properties ----------------------------------*/

        /*------------------- Init ----------------------------------*/

        $scope.init = function (userEmail) {
            if (userEmail != "") {
                $scope.userInvalid = true;
                $scope.user.Email = userEmail;
            }
        };

        /*------------------- Init ----------------------------------*/

        /*------------------- Methods ----------------------------------*/

        $scope.submitDisabled = function () {
            var result = true;

            if (($scope.user.Email != undefined && $scope.user.FirstName != undefined && $scope.user.LastName != undefined &&
                $scope.user.Email != "" && $scope.user.FirstName != "" && $scope.user.LastName != "") || $scope.userInfoSubmitDisabled)
            {
                result = false;
                $scope.userInfoSubmitDisabled = false;
            }

            return result;
        };

        $scope.submitUserInfo = function () {
            $scope.userInfoSubmitDisabled = true;
            var data = { Email: $scope.user.Email, FirstName: $scope.user.FirstName, LastName: $scope.user.LastName };
            console.log(data);
            voterService.createUser(data, $scope.submitUserInfoSuccess);
        };

        $scope.submitUserInfoSuccess = function (data) {
            $scope.userInvalid = false;
        };

        /*------------------- Methods ----------------------------------*/

    }
]);