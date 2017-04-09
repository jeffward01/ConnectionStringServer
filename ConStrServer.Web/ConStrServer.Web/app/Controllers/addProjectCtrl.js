'use strict';
app.controller('addProjectCtrl',
    [
        '$scope', 'stateManager',
        function ($scope, stateManager) {

            $scope.goHome = function() {
                stateManager.goHome();
            }

        }
    ]);