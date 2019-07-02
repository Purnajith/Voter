angular.module('voteApp')
    .service('voterService', ['$http', function ($http) {
        this.createUser = function (data, successCallback) {
            return $http.post('../home/CreatUser', data).then(successCallback, function (data) {
                console.log(data);
            });
        }
    }]);