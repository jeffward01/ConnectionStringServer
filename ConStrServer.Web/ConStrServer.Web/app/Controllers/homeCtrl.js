'use strict';
app.controller('homeCtrl',
[
    '$scope', 'stateManager',
    function ($scope, stateManager) {


        $scope.viewProject = function() {
            stateManager.viewProject();
        }

        $scope.addProject = function() {
            stateManager.addProject();

        }
    }
]);