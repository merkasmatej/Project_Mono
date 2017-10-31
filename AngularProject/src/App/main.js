var app = angular.module('Projectapp', ['ui.router']);

app.config(function ($stateProvider, $urlrouterProvider) {

    $urlrouterProvider.otherwise("/vehiclemodel");

    $stateProvider
                .state('vehiclemodel', {
                    url: '/vehiclemodel',
                    templateUrl: './src/App/vehiclemodel/vehiclemodel.html',
                    controler: 'ModelController'
                });




})