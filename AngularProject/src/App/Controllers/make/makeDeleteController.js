angular.module('appModule').controller('makeDeleteController', ['$scope', '$http', '$stateParams', '$window', '$state', makeDeleteController]);

function makeDeleteController($scope, $http, $stateParams, $window, $state) {

    $scope.delete = function (id) {
        if ($window.confirm('Are you sure?')) {
            $http.delete('/api/make/delete' + id).success(function (data) {
                $scope.response = data;
                $scope.getAllMake();
            })
            .error(function (data) {
                $window.alert("Error! " + data.Message);
            })
        };
        
        $scope.getAllMake();

    }

}