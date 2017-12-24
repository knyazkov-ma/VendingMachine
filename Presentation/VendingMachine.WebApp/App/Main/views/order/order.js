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
            vm.assortment = null;
            vm.selectedItems = [];
            var init = function () {
                vm.selectedItems = [];
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

            prepareOrder = function (productGroup, additionGroup, order)
            {
                if (productGroup.SelectedId > 0)
                {
                    var selectedItem = { Name: null, Additions: [] };
                    var selectedProduct = null;
                    order.SelectedProductIds.push(productGroup.SelectedId);
                    for (var i = 0; i < productGroup.Items.length; i++) {
                        var p = productGroup.Items[i];
                        if (p.Id == productGroup.SelectedId) {
                            selectedItem.Name = p.Name;
                            selectedProduct = p;
                            break;
                        }
                    }

                    /*Капучино (Эспрессо + Молоко + Сахар) - чтобы попало Эспрессо, которое в интерфейсе не выбрано*/
                    for (var i = 0; i < selectedProduct.Combinations.length; i++) {
                        var c = selectedProduct.Combinations[i];
                        if (c.Required && c.ProductTo.ProductType == 0 /*enum ProductType.Drink*/) {
                            selectedItem.Additions.push({ Name: c.ProductTo.Name });
                        }
                    }

                    for (var i = 0; i < additionGroup.Items.length; i++) {
                        var p = additionGroup.Items[i];
                        if (p.Checked) {
                            order.SelectedProductIds.push(p.Id);
                            selectedItem.Additions.push({ Name: p.Name });
                        }
                    }

                    /*Бутерброд (Хлеб+Ветчина)*/
                    if (selectedProduct.TransformationName && selectedItem.Additions.length > 0) {
                        selectedItem.Name = selectedProduct.TransformationName;
                        selectedItem.Additions.push({ Name: selectedProduct.Name });
                    }

                    vm.selectedItems.push(selectedItem);
                }                    
            }

            vm.confirmOrder = function ()
            {
                vm.errors = {};
                vm.showAlert = true;
                vm.selectedItems = [];

                var order = {
                    SelectedProductIds: [],
                    Composition: vm.assortment.Composition.Selected,
                    SugarCount: vm.assortment.SugarCount
                };
                
                prepareOrder(vm.assortment.FoodGroup, vm.assortment.FoodAdditionGroup, order);
                prepareOrder(vm.assortment.DrinkGroup, vm.assortment.DrinkAdditionGroup, order);

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

            setAllowableCombination = function (additions, product, juxtaposition)
            {
                for (var i = 0; i < additions.length; i++) {
                    var p = additions[i];
                    p.AllowableCombination = false;
                    p.Checked = false;
                    for (var j = 0; j < product.Combinations.length; j++)
                    {
                        var c = product.Combinations[j];
                        if (c.ProductTo.Id == p.Id) {
                            juxtaposition(p, c);
                            break;
                        }
                    }
                }
            }


            vm.setAllowableDrinkCombination = function (product)
            {
                setAllowableCombination(vm.assortment.DrinkAdditionGroup.Items, product,
                    function (p, c) {
                        if (!c.Required)
                            p.AllowableCombination = true;
                        p.Checked = c.Required;
                    });

            }
            
            vm.setAllowableFoodCombination = function (product)
            {
                setAllowableCombination(vm.assortment.FoodAdditionGroup.Items, product,
                    function (p) {
                        p.AllowableCombination = true;
                    });

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