angular.module("app").controller('addProjectController',
    [
        '$scope', '$state', 'authService', 'stateManager', 'alertService', 'smoothScroll', '$rootScope', '$timeout', 'objectService', 'projectService',
        function ($scope, $state, authService, stateManager, alertService, smoothScroll, $rootScope, $timeout, objectService, projectService) {
            $scope.envrironmentsToAdd = [];
            $scope.project = {}
            $scope.newEnvironment = {};

            $scope.submitProject = function () {
                if ($scope.project.ProjectName == null || $scope.project.ProjectName.length == 0) {
                    alertService.error("Please add a project name");
                } else {
                    assembleProject();
                    projectService.createProject($scope.project).then(function (result) {
                        alertService.success("Project has been added!");
                        $state.go("app.viewProject",
                            {
                                projectId: result.ProjectId
                            });
                    },
                        function (err) {
                            console.log(JSON.stringify(err));
                            alertService.error("Error adding Project.  Please try again");
                        });
                }
            }

            $scope.removeEnvironment = function (env) {
                objectService.removeElementFromArray(env, $scope.envrironmentsToAdd);
            }

            $scope.addEnvironment = function (tech) {
                if ($scope.newEnvironment.EnvironmentName == null || $scope.newEnvironment.EnvironmentName.length === 0) {
                    return;
                }
                else {
                    $scope.envrironmentsToAdd.push($scope.newEnvironment);
                    $scope.newEnvironment = null;
                }
            }

            function assembleProject() {
                $scope.project.Environments = $scope.envrironmentsToAdd;
                $scope.project.ProjectId = 0;
            }
        }
    ]);