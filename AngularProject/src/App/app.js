var appModule = angular.module('appModule', ['ui.router']);

appModule.config(function ($stateProvider, $urlrouterProvider) {

    $urlrouterProvider.otherwise("/make");

    $stateProvider
      .state('make', {
          url: '/make',
          templateUrl: 'src/App/Views/make/make.html'
      })
      .state('make/details', {
          url: '/make/details',
          templateUrl: 'src/App/Views/make/ShowDetailsMake.html'
      })
      .state('make/add', {
          url: '/make/add',
          templateUrl: 'src/App/Views/make/AddMake.html'
      })
      .state('make/update', {
          url: '/make/update',
          templateUrl: 'src/App/Views/make/UpdateMake.html'
      })


          
      .state('model', {
          url: '/model',
          templateUrl: 'src/App/Views/model/model.html'
      })
      .state('model/details', {
          url: '/model/details',
          templateUrl: 'src/App/Views/model/ShowDetailsModel.html'
      })
      .state('model/add', {
          url: '/model/add',
          templateUrl: 'src/App/Views/model/AddModel.html'
      })
      .state('model/update', {
          url: '/model/update',
          templateUrl: 'App/Views/model/UpdateModel.html'
      })




})