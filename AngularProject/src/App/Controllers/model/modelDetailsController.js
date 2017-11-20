angular.module('appModule').controller('modelDetailsController', ['$scope', '$http', '$stateParams', modelDetailsController]);

function modelDetailsController($scope, $http, $stateParams) {

    $http.get('/api/model/get' + $stateParams.id).success(function (data) {
        $scope.model = data;
    })
    .error(function (data) {
        $window.alert("Error! " + data.Message);
    });

}