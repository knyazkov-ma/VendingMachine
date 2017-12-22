(function () {
    var app = angular.module('app');

    var controllerId = 'app.views.order.order';
    app.controller(controllerId, [
        '$scope', '$rootScope', '$state', 'orderService',
        function ($scope, $rootScope, $state, orderService) {

            var vm = this;

            var init = function () {

                orderService.getAssortment().then(function (results) {
                    vm.assortment = results.data.data;

                    vm.assortment.DrinkGroup.SelectedId = 0;
                    vm.assortment.DrinkAdditionGroup.SelectedId = 0;
                    vm.assortment.FoodGroup.SelectedId = 0;
                    vm.assortment.FoodAdditionGroup.SelectedId = 0;

                }, function (error) {
                    $rootScope.$broadcast("error", { errorMsg: error.data.Message });
                });

                vm.errors = {};
            }

            init();
        }
    ]);
})();