angular.module('appModule').controller('makeDetailsController', ['$scope', '$http', '$stateParams', makeDetailsController]);

function makeDetailsController($scope, $http, $stateParams) {

    $http.get('/api/make/get' + $stateParams.id).success(function (data) {
        $scope.make = data;
    })
    .error(function (data) {
        $window.alert("Error! " + data.Message);
    })

}