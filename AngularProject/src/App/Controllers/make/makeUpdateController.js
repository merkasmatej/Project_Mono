angular.module('appModule').controller('makeUpdateController', ['$scope', '$http', '$stateParams', '$window', '$state', makeUpdateController]);

function makeUpdateController($scope, $http, $stateParams, $window, $state) {
    $scope.updateInit = function () {
        var id = $stateParams.make;
        $http.get('/api/make/get' + id).success(function (data) {
            $scope.updateData = data;
        })
        .error(function (data) {
            $window.alert("Error! " + data.Message);
        })
    }

    $scope.UpdateMake = function () {

        if ($scope.updateData.Name == null || $scope.updateData.Abrv == null) {
            $window.alert("Fill all fields");
        }
        else {
            var obj = {
                Name: $scope.updateData.Name,
                Abrv: $scope.updateData.Abrv,
                VehicleMakeId: $scope.updateData.VehicleMakeId
            };

            $http.put('/api/make/update', obj).success(function (data) {
                $window.alert("Updated!");
            })
            .error(function (data) {
                $window.alert("Error! " + data.Message);
            })
        }
    }

};