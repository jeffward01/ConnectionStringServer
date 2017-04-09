'use strict';
app.controller('addProjectCtrl',
    [
        '$scope', 'stateManager', 'objectService', 'localStorageService',
        function ($scope, stateManager, objectService, localStorageService) {
            $scope.newEnvironment = {};
            $scope.editEnvironment = {};
            $scope.newConnectionString = {};
            $scope.newConnectionStrings = [];
            $scope.options = [];
            $scope.newMachine = {};
            $scope.newMachineConnectionStrings = {};
            $scope.environments = [];
            $scope.machines = [];
            var machineBeingModified = {};
            $scope.addNewConnectionString = function () {
                $scope.newConnectionStrings.push($scope.newConnectionString);
                $scope.newConnectionString = {};
            }

            $scope.addNewConnectionStringEdit = function () {
                $scope.editMachine.connectionStrings.push($scope.newConnectionString);
                $scope.newConnectionString = {};
            }

            $scope.saveNewMachine = function () {
                var environment = $scope.newMachine.environment[0].name;
                var connectionStrings = $scope.newConnectionStrings;
                $scope.newMachine.environment = null;
                var newMachine = $scope.newMachine;
                newMachine.connectionStrings = connectionStrings;
                $scope.newConnectionStrings = [];
                newMachine.environment = environment;
                $scope.machines.push(newMachine);
                $scope.newMachine = {};
                objectService.clearDropdownOptions($scope.options);

                $('#addMachine').modal('hide');
            }

            $scope.saveEditMachine = function () {
                alert("SAVE EDIT MACHINE CALLED");

                $scope.machines.push($scope.editMachine);
                $scope.editMachine = {};
                machineBeingModified = {};
                objectService.clearDropdownOptions($scope.options);
                $('#editMachine').modal('hide');
            }

            $scope.cancelEditMachine = function () {
                alert("CANCEL EDIT MACHINE CALLED");
                $scope.editMachine = {};
                var machineSaved = localStorageService.get('machineToEdit');
                localStorageService.remove('machineToEdit');
                $scope.machines.push(machineSaved);
                machineBeingModified = {};
                objectService.clearDropdownOptions($scope.options);

                $('#editMachine').modal('hide');
            }

            $scope.editMachineEvent = function (x) {
                alert(" EDIT EVENT MACHINE CALLED");
                var machinetoEdit = x;
                var machinetoEdit2 = x;
                localStorageService.set('machineToEdit', x);
                $scope.editMachine = machinetoEdit2;
                machineBeingModified = machinetoEdit;
                objectService.removeElementFromArray(x, $scope.machines);
            }

            $scope.removeConnectionString = function (x) {
                objectService.removeElementFromArray(x, $scope.newConnectionStrings);
            }
            $scope.removeConnectionStringEdit = function (x) {
                objectService.removeElementFromArray(x, $scope.editMachine.connectionStrings);
            }

            $scope.goHome = function () {
                stateManager.goHome();
            }

            $scope.$watch('environments',
                function () {
                    $scope.options = [];
                    angular.forEach($scope.environments,
                        function (env) {
                            var newObj = {
                                name: env.name
                            }

                            $scope.options.push(newObj);
                        });
                }, true);

            $scope.setNewEnvironment = function () {
                $scope.newEnvironment.loadBalanced = false;
            }

            $scope.addNewEnvironment = function () {
                $scope.environments.push($scope.newEnvironment);
                $scope.newEnvironment = {};
                $('#addEnvironemnt').modal('hide');
            }

            $scope.removeEnvironment = function (x) {
                objectService.removeElementFromArray(x, $scope.environments);
            }
        }
    ]);