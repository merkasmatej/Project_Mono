var app = angular.module('Projectapp');

app.controller('ModelController', ['modelService', '$window', '$scope', 'deleteConfirmService', '$state',
    function (modelService, $window, $scope, deleteConfirmService, $state) {
        var vm = $scope.vm = {};

        vm.models = [];
        vm.model = null;
        vm.newItem = {};
        vm.selected = {};

        vm.showModelTable = false;
        vm.showAddModel = false;
        vm.showEditModel = false;
        vm.showModelDetails = false;

        //search and pagination
        vm.searchTerm = "";
        vm.pageNumber = 1;
        var pageSize = 5;

        //show add model
        vm.showAddModelView = function () {
            vm.newItem = {};

            vm.showAddModel = true;
            vm.showModelTable = false;
            vm.showModelDetails = false;
        }

        //show edit model

        vm.showEditModelView = function () {
            vm.selected = {};
            vm.selected = item;

            vm.showEditModel = true;
            vm.showModelTable = false;
            vm.showModelDetails = false;
        }

        //get models
        vm.getModels = function () {
            vm.showAddModel = false;
            vm.showEditModel = false;
            vm.showModelDetails = false;
            vm.showModelTable = true;

            if (vm.searchTerm.length > 0) {
                modelService.getModelByName(vm.searchTerm, vm.pageNumber, pageSize)
                .success(function (data) {
                    vm.models = data;
                }).error(function (error) {
                    vm.status = 'Unable to get models:' + error.message;
                });
            }

            else {
                modelService.getModels(vm.pageNumber, pageSize).success(function (data) {
                    vm.models = data;
                }).error(function (error) {
                    vm.status = 'Unable to get models:' + error.message;
                });
            }
        };

        vm.getModels();

        //get model details
        vm.getModelDetails = function (id) {
            vm.showAddModel = false;
            vm.showModelTable = false;
            vm.showModelDetails = true;

            modelService.getModel(id).success(function (data) {
                vm.model = data;
            }).error(function (error) {
                vm.status = 'Unable to get model:' + error.message;
            });
        };

        //add model
        vm.postModel = function (item) {
            modelService.postModel(item)
            .success(function (data) {
                $state.go('model');
            })
            .error(function (data) {
                console.log("Add model failed");
                vm.showAddModelView();
            });
        };

        //update model
        vm.updateModel = function (item) {
            vm.selected.ModelName = item.ModelName;
            vm.selected.ModelAbrv = item.ModelAbrv;

            modelService.putModel(vm.selected)
            .success(function (data) {
                vm.selected = data;
                vm.getModels();
            })
            .error(function (data) {
                console.log("Edit model failed");
                vm.showEditModelView();
            });
        };

        // Delete model
        vm.deleteModel = function (item) {

            var name = item.ModelName;

            // Custom modal options
            var modalOptions = {
                headerText: 'Jeste li sigurni da želite obrisati model?',
                bodyText: 'Name: ',
                bodyTextValue: item.ModelName
            };

            deleteConfirmService.showModal({}, modalOptions).then(function (result) {
                customerService.deleteModel(item.Id)
                    .success(function (data) {
                        vm.getModels();
                        vm.selected = {};
                    })
                    .error(function () {
                        console.log("Delete model failed.");
                    });
            });
        }

        // Pagination
        vm.previous = function () {
            vm.pageNumber--;

            if (vm.pageNumber < 1)
                vm.pageNumber = 1;

            vm.getModels();
        }

        vm.next = function () {
            vm.pageNumber++;
            modelService.getModels(vm.pageNumber, pageSize).success(function (data) {
                vm.models = data;

                if (data.length == 0) {
                    vm.pageNumber--;
                    vm.getModels();
                }
            });
        }
    }
]);