(function () {
    var app = angular.module('app');
    app.factory('urlWebAPIService', [
        function () {

            var factory = {};

            var _get = function (uri) {
                return "/api/" + uri;
            };
           
            factory.get = _get;
            
            return factory;

        }
    ]);
})();