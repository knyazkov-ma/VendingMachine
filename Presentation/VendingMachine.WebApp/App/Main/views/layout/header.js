(function () {
    
    var controllerId = 'app.views.layout.header';
    angular.module('app').controller(controllerId, [
        '$rootScope', '$state', '$location', 'menuService',
        function ($rootScope, $state, $location, menuService) {

            
            var vm = this;
            vm.errorMsg = null;

           
            vm.menu = {};
            localizedMenu = menuService.get();
            vm.menu.items = [];
            for (var propertyName in localizedMenu) {
                vm.menu.items.push({ displayName: localizedMenu[propertyName], name: propertyName })
            }
                        
            vm.isActive = function(item) {
                return (item.name == $state.current.name);
            };

            vm.go = function(stateName) {
                $state.go(stateName);
            };
           
            $rootScope.$on('error', function (event, data) {
                vm.errorMsg = data.errorMsg;
            });
            
            
        }
    ]);
})();