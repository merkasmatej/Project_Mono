angular.module('appModule').controller('makeAddController', ['$scope', '$http', '$stateParams', '$window', '$state', makeAddController]);

function makeAddController($scope, $http, $stateParams, $window, $state) {
    $scope.AddMake = function () {

        if ($scope.Name == null || $scope.Abrv == null) {
            $window.alert("Fill all fields");
        }
        else {
            var obj = {
                Name: $scope.Name,
                Abrv: $scope.Abrv
            };

            $http.post('/api/make/add', obj).success(function (data) {
                $scope.response = data;
                console.log(data);
                $window.alert("Success");
            })
            .error(function (data) {
                $scope.error = "An error has occured while trying to add make";
                $window.alert("Error " + data.Message);
            });

            //Clear model and form
            $scope.makeAddForm.$setPristine(true);
            $scope.Name = null;
            $scope.Abrv = null;
        }
    }


};