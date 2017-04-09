angular.module('ConStrApp')
    .factory('objectService', [

        function () {
            var objectServiceFactory = {};

            var _removeElementFromArray = function (item, array) {
                var index = array.indexOf(item);
                if (index > -1) {
                    array.splice(index, 1);
                }
                return array;
            }

            var _clearDropdownOptions = function (x) {
                angular.forEach(x,
                    function (item) {
                        item.selected = false;
                    });
            }
            objectServiceFactory.clearDropdownOptions = _clearDropdownOptions;
            objectServiceFactory.removeElementFromArray = _removeElementFromArray;
            return objectServiceFactory;
        }
    ]);