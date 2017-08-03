angular.module('app')
    .factory('machineService', [
        '$http', '$q', 'serviceUrl',
        function ($http, $q, serviceUrl) {
            var machineServiceFactory = {};

            var _createMachine = function (machine) {
                var deferred = $q.defer();
                $http.post(serviceUrl + "api/Machine/CreateMachine", machine).then(function (result) {
                    deferred.resolve(result);
                },
                    function (err) {
                        deferred.reject(err);
                    });
                return deferred.promise;
            }

            var _editMachine= function (machine) {
                var deferred = $q.defer();
                $http.post(serviceUrl + "api/Machine/EditMachine", machine).then(function (result) {
                    deferred.resolve(result);
                },
                    function (err) {
                        deferred.reject(err);
                    });
                return deferred.promise;
            }

            var _deleteMachine = function (machineId) {
                var deferred = $q.defer();
                $http.post(serviceUrl + "api/Machine/DeleteMachine/" + machineId).then(function (result) {
                    deferred.resolve(result);
                },
                    function (err) {
                        deferred.reject(err);
                    });
                return deferred.promise;
            }


            var _getMachinebyId = function (machineId) {
                var deferred = $q.defer();
                $http.get(serviceUrl + "api/Machine/GetMachinebyId/" + machineId).then(function (result) {
                    deferred.resolve(result);
                },
                    function (err) {
                        deferred.reject(err);
                    });
                return deferred.promise;
            }

            var _getAllMachines = function () {
                var deferred = $q.defer();
                $http.get(serviceUrl + "api/Machine/GetAllMachines").then(function (result) {
                    deferred.resolve(result);
                },
                    function (err) {
                        deferred.reject(err);
                    });
                return deferred.promise;
            }

            machineServiceFactory.createMachine = _createMachine;
            machineServiceFactory.editMachine = _editMachine;
            machineServiceFactory.deleteMachine = _deleteMachine;
            machineServiceFactory.getMachineById = _getMachinebyId;
            machineServiceFactory.getAllMachines = _getAllMachines;

            return machineServiceFactory;
        }
    ]);