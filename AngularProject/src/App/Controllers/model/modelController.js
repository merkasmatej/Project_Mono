angular.module('appModule').controller('modelController', ['$scope', '$http', '$window', '$state', modelController]);

//Controller function
function modelController($scope, $http, $window, $state) {
    var models;
    var make;

    $scope.getAllModels = function () {
      
        $http.get('/api/model/getall').success(function (data) {
            $scope.dataModel = data;
            models = $scope.dataModel;
        })
        .error(function (data) {
            $window.alert("Error! " + data.Message);
        });


    };

    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;
        $scope.reverse = !$scope.reverse;
    }

}