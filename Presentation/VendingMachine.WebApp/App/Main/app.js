(function () {
    'use strict';
    
    var app = angular.module('app', [
        'ngAnimate',
        'ngSanitize',
        'ngRoute',
        'ui.router',
        'ui.bootstrap',
        'ui.jq',
        'ui.keypress',
        'ui.event',
        'angular-loading-bar'
    ]);

    //Configuration for Angular UI routing.
    app.config([
        '$stateProvider', '$urlRouterProvider', '$httpProvider', 
        function ($stateProvider, $urlRouterProvider, $httpProvider) {
            
            $urlRouterProvider.otherwise('/');
            $stateProvider
                .state('order', {
                    url: '/',
                    templateUrl: '/AngularTemplate/Order',
                    menu: 'order'
                })

            delete $httpProvider.defaults.headers.common['X-Requested-With'];
            
        }
    ]);

})();