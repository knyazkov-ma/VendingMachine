(function () {
    var app = angular.module('app');
    app.factory('orderService', ['$http', 'urlWebAPIService',
        function ($http, urlWebAPIService) {

            var factory = {};

            var _getAssortment = function () {
                return $http.get(urlWebAPIService.get("Order/GetAssortment"))
                    .then(function (results) {
                        return results;
                    });
            };

                        
            var _getOrderCost = function (order) {
                return $http.post(urlWebAPIService.get("Order/GetOrderCost"), JSON.stringify(order)).then(function (results) {
                    return results;
                });
            };
            
            factory.getAssortment   = _getAssortment;
            factory.getOrderCost    = _getOrderCost;
            
            return factory;

        }
    ]);
})();