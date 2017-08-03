angular.module("app").controller('addProjectController',
    [
        '$scope', '$state', 'authService', 'stateManager', 'alertService', 'smoothScroll', '$rootScope', '$timeout', 'objectService', 'projectService', 
        function ($scope, $state, authService, stateManager, alertService, smoothScroll, $rootScope, $timeout, objectService, projectService) {


            $scope.project = {}

            $scope.submitProject = function () {
                if ($scope.project.ProjectName == null || $scope.project.ProjectName.length == 0) {
                    alertService.error("Please add a project name");
                } else {
                    
                    projectService.createProject($scope.project).then(function (result) {
                        clearProject();
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

            $scope.addTech = function (tech) {
                if ($scope.newTech.technologyName == null) {
                    return;
                } else if ($scope.newTech.technologyName.length === 0) {
                    return;
                } else {
                    $scope.technologiesToAdd.push($scope.newTech);
                    $scope.newTech = null;
                }
            }

        }
    ]);