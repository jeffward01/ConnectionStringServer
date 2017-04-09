'use strict';
app.controller('addProjectCtrl',
    [
        '$scope', 'stateManager',
        function ($scope, stateManager) {

            $scope.goHome = function() {
                stateManager.goHome();
            }
            $scope.options =  [
                "France",
                "United Kingdom",
                "Germany",
                "Belgium",
                "Netherlands",
                "Spain",
                "Italy",
                "Poland",
                "Austria"
            ]
        }
    ]);