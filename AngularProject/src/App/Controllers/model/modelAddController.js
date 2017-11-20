angular.module('appModule').controller('modelAddController', ['$scope', '$http', '$stateParams', '$window', '$state', modelAddController]);

function modelAddController($scope, $http, $stateParams, $window, $state) {
    $scope.AddModel = function () {

        if ($scope.Name == null || $scope.Abrv == null || $scope.VehicleMakeId == null) {
            $window.alert("Fill all fields");
        }
        else {
            var obj = {
                Name: $scope.Name,
                Abrv: $scope.Abrv,
                VehicleMakeId: $scope.VehicleMakeId
            };

            $http.post('/api/model/add', obj).success(function (data) {
                $scope.response = data;
                $window.alert("Success");
            })
            .error(function (data) {
                $window.alert("Error! " + data.Message);
            })

            //Clear model and form
            $scope.modelAddForm.$setPristine(true);
            $scope.Name = null;
            $scope.Abrv = null;
            $scope.VehicleMakeId = null;
        }
    }

};