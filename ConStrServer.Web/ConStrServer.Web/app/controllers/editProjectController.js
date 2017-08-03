angular.module("app").controller('editProjectController',
    [
        '$scope', '$state', 'authService', 'stateManager', 'alertService', 'smoothScroll', '$rootScope', '$timeout', 'projectService', '$stateParams', 'objectService',
        function($scope,
            $state,
            authService,
            stateManager,
            alertService,
            smoothScroll,
            $rootScope,
            $timeout,
            projectService,
            $stateParams,
            objectService) {
            $scope.newEnvironment = {};

            projectService.getProjectById($stateParams.projectId).then(function(result) {
                    $scope.project = result.data;
                    $scope.environmentsToAdd = $scope.project.Environments;

                    $scope.project.Environments = null;

                },
                function(err) {
                    console.log(JSON.stringify(err));
                });

            $scope.removeEnvironment = function(image) {
                objectService.removeElementFromArray(image, $scope.environmentsToAdd);
            }


            $scope.addEnvironment = function(image) {
                if ($scope.newEnvironment.EnvironmentName != null && $scope.newEnvironment.EnvironmentName.length > 0) {


                    $scope.environmentsToAdd.push($scope.newEnvironment);

                    $scope.newEnvironment = {};
                } else {
                    alertService.error("Error adding Environment, please add an Environment name!");

                    return;
                }
            }

            $scope.updateProject = function() {
                assembleProject();
                projectService.editProject($scope.project).then(function(result) {
                        alertService.success("Project has been updated!");
                        $state.go('app.viewProject', { projectId: $stateParams.projectId });
                    },
                    function(err) {
                        alertService.error("Error updating project!");
                    });
            }

            function assembleProject() {
                angular.forEach($scope.environmentsToAdd,
                    function(item) {
                        item.ProjectId = $stateParams.projectId;
                    });
                $scope.project.Environments = $scope.environmentsToAdd;
            }
        }
    ]);