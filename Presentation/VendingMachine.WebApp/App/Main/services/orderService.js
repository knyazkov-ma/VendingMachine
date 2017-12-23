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

                        
            var _confirmOrder = function (order) {
                return $http.post(urlWebAPIService.get("Order/СonfirmOrder"), JSON.stringify(order)).then(function (results) {
                    return results;
                });
            };
            
            factory.getAssortment   = _getAssortment;
            factory.confirmOrder = _confirmOrder;
            
            return factory;

        }
    ]);
})();