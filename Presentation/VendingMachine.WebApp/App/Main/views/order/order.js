(function () {
    var app = angular.module('app');

    var controllerId = 'app.views.order.order';
    app.controller(controllerId, [
        '$scope', '$rootScope', '$state', 'orderService',
        function ($scope, $rootScope, $state, orderService) {

            var vm = this;
            vm.showAlert = true;

            vm.closeAlert = function () {
                vm.errors = {};
                vm.showAlert = false;
            }

            var init = function () {

                orderService.getAssortment().then(function (results) {
                    vm.assortment = results.data.data;

                    vm.assortment.DrinkGroup.SelectedId = 0;
                    vm.assortment.DrinkAdditionGroup.SelectedId = 0;
                    vm.assortment.FoodGroup.SelectedId = 0;
                    vm.assortment.FoodAdditionGroup.SelectedId = 0;
                    
                    for (var i = 0; i < vm.assortment.DrinkAdditionGroup.Items.length; i++) {
                        vm.assortment.DrinkAdditionGroup.Items[i].Checked = false;
                        vm.assortment.DrinkAdditionGroup.Items[i].AllowableCombination = false;
                        
                    }

                    for (var i = 0; i < vm.assortment.FoodAdditionGroup.Items.length; i++) {
                        vm.assortment.FoodAdditionGroup.Items[i].Checked = false;
                        vm.assortment.FoodAdditionGroup.Items[i].AllowableCombination = false;
                        
                    }
                    
                    if (vm.assortment.MaxSugarCount)
                    {
                        vm.assortment.SugarCounts = [];
                        for (var i = 1; i <= vm.assortment.MaxSugarCount; i++)
                            vm.assortment.SugarCounts.push(i);

                        vm.assortment.SugarCount = 1;
                    }
                    vm.assortment.Composition.Selected = false;
                    vm.assortment.Summary = 0;
                }, function (error) {
                    $rootScope.$broadcast("error", { errorMsg: error.data.Message });
                });

                vm.errors = {};
            }

            vm.confirmOrder = function ()
            {
                vm.errors = {};
                vm.showAlert = true;

                var order = {
                    SelectedProductIds: [],
                    Composition: vm.assortment.Composition.Selected,
                    SugarCount: vm.assortment.SugarCount
                };

                if(vm.assortment.FoodGroup.SelectedId > 0)
                    order.SelectedProductIds.push(vm.assortment.FoodGroup.SelectedId);
                if(vm.assortment.DrinkGroup.SelectedId > 0)
                    order.SelectedProductIds.push(vm.assortment.DrinkGroup.SelectedId);


                for (var i = 0; i < vm.assortment.FoodAdditionGroup.Items.length; i++)
                {
                    var p = vm.assortment.FoodAdditionGroup.Items[i];
                    if (p.Checked)
                        order.SelectedProductIds.push(p.Id);
                }

                for (var i = 0; i < vm.assortment.DrinkAdditionGroup.Items.length; i++) {
                    var p = vm.assortment.DrinkAdditionGroup.Items[i];
                    if (p.Checked)
                        order.SelectedProductIds.push(p.Id);
                }

                orderService.confirmOrder(order).then(function (results) {
                    if (results.data.success === false) {
                        vm.errors = results.data.errors;
                    }
                    else {
                        vm.assortment.Summary = results.data.data;
                    }
                    
                }, function (error) {
                    $rootScope.$broadcast("error", { errorMsg: error.data.Message });
                });
            }

            vm.setAllowableDrinkCombination = function (product)
            {
                for (var i = 0; i < vm.assortment.DrinkAdditionGroup.Items.length; i++)
                {
                    var p = vm.assortment.DrinkAdditionGroup.Items[i];
                    p.AllowableCombination = false;
                    p.Checked = false;
                    for (var j = 0; j < product.Combinations.length; j++)
                    {
                        var c = product.Combinations[j];
                        if (c.ProductTo.Id == p.Id)
                        {
                            if (!c.Required)
                                p.AllowableCombination = true;
                            p.Checked = c.Required;
                            
                            break;
                        }
                    }
                }
            }
            
            vm.setAllowableFoodCombination = function (product) {
                for (var i = 0; i < vm.assortment.FoodAdditionGroup.Items.length; i++) {
                    var p = vm.assortment.FoodAdditionGroup.Items[i];
                    p.AllowableCombination = false;
                    p.Checked = false;
                    for (var j = 0; j < product.Combinations.length; j++) {
                        var c = product.Combinations[j];
                        if (c.ProductTo.Id == p.Id) {
                            p.AllowableCombination = true;
                            break;
                        }
                    }
                }
            }

            vm.resetForbiddenFoodCombination = function (product) {
                if (!product.Checked)
                    return;

                for (var i = 0; i < vm.assortment.FoodAdditionGroup.Items.length; i++) {
                    var p = vm.assortment.FoodAdditionGroup.Items[i];
                    for (var j = 0; j < product.ForbiddenCombinations.length; j++) {
                        var c = product.ForbiddenCombinations[j];
                        if (c.ProductTo.Id == p.Id) {
                            p.Checked = false;
                            break;
                        }
                    }
                }
            }

            vm.cancel = function ()
            {
                init();
            }

            init();
        }
    ]);
})();