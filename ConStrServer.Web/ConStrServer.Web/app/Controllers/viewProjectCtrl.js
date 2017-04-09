'use strict';
app.controller('viewProjectCtrl',
    [
        '$scope', 'stateManager',
        function ($scope, stateManager) {
            $scope.goHome = function () {
                stateManager.goHome();
            }
        }
    ]);