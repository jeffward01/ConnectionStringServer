angular.module("app").controller('viewProjectController',
    [
        '$scope', '$state', 'authService', 'stateManager', 'alertService', 'smoothScroll', '$rootScope', '$timeout', 'projectService', '$stateParams', 'objectService', 'machineService',
        function ($scope, $state, authService, stateManager, alertService, smoothScroll, $rootScope, $timeout, projectService, $stateParams, objectService, machineService) {
            $scope.images = [];
            $scope.featuredImage = {};
            $scope.tech = [];
            $scope.newMachineToAdd = {};
            $scope.newConnectionStringToAdd = {};
            $scope.connectionStringsToAdd = [];
            $scope.machineToEdit = {};
            $scope.machineConnectionStringsToEdit = [];

            loadProject();
            $scope.deleteMachine = function (machineId) {
                machineService.deleteMachine(machineId).then(function (result) {
                    loadProject();
                    alertService.success("Machine Deleted!");
                },
                    function (err) {
                        alertService.error("Error adding deleting Machine");
                        console.log(JSON.stringify(err));
                    });
            }
            $scope.addMachine = function (environmentId) {
                $scope.newMachineToAdd.EnvironmentId = environmentId;
            }

            $scope.editMachine = function (environmentId, machineId) {
                $scope.machineToEdit.EnvironmentId = environmentId;
                machineService.getMachineById(machineId).then(function(result) {
                    $scope.machineToEdit = result.data;
                    $scope.machineConnectionStringsToEdit = $scope.machineToEdit.ConnectionStrings;
                },function(err) {
                    console.log(JSON.stringfy(err));
                    alertService.error("Error retrieving Machine Details.");
                });

            }
            $scope.exitAddMachine = function () {
                $scope.newMachineToAdd = {};
                $scope.connectionStringsToAdd = [];
            }

            $scope.exitEditMachine = function () {
                $scope.newMachineToAdd = {};
                $scope.connectionStringsToAdd = [];
                $scope.machineToEdit = {};
                $scope.machineConnectionStringsToEdit = [];
            }
            $scope.saveMachine = function () {
                if ($scope.newMachineToAdd.EnvironmentId != null &&
                    $scope.newMachineToAdd.MachinePort != null &&
                    $scope.newMachineToAdd.MachineIpAddress != null &&
                    $scope.newMachineToAdd.MachineName != null &&
                    $scope.newMachineToAdd.MachineNickName != null) {

                
                    //Add it
                    $scope.newMachineToAdd.MachineId = 0;
                    $scope.newMachineToAdd.ConnectionStrings = $scope.connectionStringsToAdd;
                    machineService.createMachine($scope.newMachineToAdd).then(function (result) {
                        setObjsToEmpty();
                        loadProject();
                        alertService.success("New Machine Added!");

                        $('.bs-machine-add-modal-lg').modal('toggle');
                    },
                        function (err) {
                            alertService.error("Error adding new Machine");
                            console.log(JSON.stringify(err));
                        });
                } else {
                    alertService.error("Please add a value for all fields");
                    return;
                }
            }

            $scope.saveEditMachine = function() {
                if ($scope.machineToEdit.EnvironmentId != null &&
                    $scope.machineToEdit.MachinePort != null &&
                    $scope.machineToEdit.MachineIpAddress != null &&
                    $scope.machineToEdit.MachineName != null &&
                    $scope.machineToEdit.MachineNickName != null) {
                    //Add it
                    $scope.machineToEdit.ConnectionStrings = $scope.machineConnectionStringsToEdit;
                    machineService.editMachine($scope.machineToEdit).then(function (result) {
                        loadProject();
                        alertService.success("Machine Updated!");
                        $('.bs-machine-edit-modal-lg').modal('toggle');
                    },
                        function (err) {
                            alertService.error("Error updating Machine");
                            console.log(JSON.stringify(err));
                        });
                } else {
                    alertService.error("Please add a value for all fields");
                    return;
                } 
            }

            $scope.addConnectionString = function () {
                if ($scope.newConnectionStringToAdd.ConnectionStringName != null &&
                    $scope.newConnectionStringToAdd.ConnectionStringUrl != null) {
                    $scope.newConnectionStringToAdd.MachineId = 0;
                    $scope.connectionStringsToAdd.push($scope.newConnectionStringToAdd);
                    $scope.newConnectionStringToAdd = {};
                }
            }
            $scope.addConnectionStringToEdit = function () {
                if ($scope.newConnectionStringToAdd.ConnectionStringName != null &&
                    $scope.newConnectionStringToAdd.ConnectionStringUrl != null) {
                    $scope.newConnectionStringToAdd.MachineId = 0;
                    $scope.machineConnectionStringsToEdit.push($scope.newConnectionStringToAdd);
                    $scope.newConnectionStringToAdd = {};
                }
            }
            $scope.removeEditConnectionString = function(x) {
                objectService.removeElementFromArray(x, $scope.machineConnectionStringsToEdit);
            }

            $scope.removeConnectionString = function (conStr) {
                objectService.removeElementFromArray(conStr, $scope.connectionStringsToAdd);
            }

            $scope.edit = function () {
                $state.go('app.editProject',
                    {
                        projectId: $stateParams.projectId
                    });
            }

            $scope.editProject = function (id) {
                $state.go('app.editProject', { projectId: id });
            }

            $scope.getLimits = function (array) {
                return [
                    Math.floor($scope.tech.length / 2) + 1,
                    -Math.floor($scope.tech.length / 2)
                ];
            };
            $scope.openConStrs = function (machine) {
                machine.collapsed = !machine.collapsed;
            }

            function loadProject() {

                projectService.getProjectById($stateParams.projectId).then(function (result) {
                    $scope.project = result.data;
                    setCollapseToggles($scope.project);
                },
                    function (err) {
                        console.log(JSON.stringify(err));
                    });
            }

            $scope.deleteMachine = function (machineId) {
                machineService.deleteMachine(machineId).then(function (result) {
                        setObjsToEmpty();
                    loadProject();
                    alertService.success("Machine Deleted!");
                },
                    function (err) {
                        alertService.error("Error Deleting Machine...");
                        console.log(JSON.stringify(err));
                        return;
                    });
            }

            function setObjsToEmpty() {
                $scope.images = [];
                $scope.featuredImage = {};
                $scope.tech = [];
                $scope.newMachineToAdd = {};
                $scope.newConnectionStringToAdd = {};
                $scope.connectionStringsToAdd = [];
                $scope.machineToEdit = {};
                $scope.machineConnectionStringsToEdit = [];
            }

            function setCollapseToggles(x) {
                angular.forEach(x.Machines,
                    function (machine) {
                        if (machine.collapsed === null) {
                            machine.collapsed = false;
                        }
                        if (machine.collapsed === undefined) {
                            machine.collapsed = false;
                        }
                    });
            }
        }
    ]);