angular.module("app").controller('appController',
    [
        '$scope', '$state', 'authService', 'stateManager', 'alertService', 'smoothScroll', '$rootScope', '$timeout',
        function ($scope, $state, authService, stateManager, alertService, smoothScroll, $rootScope, $timeout) {
            //This needs to update upon login, do a $scope.$on???

            checkAuthentication();


            $scope.aboutActive = false;
            $scope.howToActive = false;

            $scope.scrollToSkills = function () {
                // Using defaults
                var element = document.getElementById('skills');
                var options = {
                    duration: 700,
                    easing: 'easeInOutQuad', //originally it was 'easeInQuad'
                    offset: 120
                }
                smoothScroll(element, options);
            }





            $scope.goToHome = function () {
                $state.go('app.home', {});
                scroll('page-top');
            }

            $scope.goToSnippet = function () {
                $state.go('app.home', {});
                scroll('portfolio');
                $rootScope.$broadcast('openCodeSnippet');
            }

            $scope.goToHowTo = function () {
                $state.go('app.howTo', {});
            };

            $scope.goToAbout = function () {
                $state.go('app.about', {});
         };

            $scope.goToFeaturedProjects = function () {
                $state.go('app.home', {});
                scroll('featuredProjects');
            };

            $scope.goToContact = function () {
                $state.go('app.home', {});
                scroll('contact');
            };

            $scope.goToPortfolio = function () {
                $state.go('app.home', {});
                scroll('portfolio');
            };

            $scope.goToProfile = function () {
                setToggleProfile();
                //stateManager.goToMyProfile(authService.getNootUserId());
                stateManager.goToMyProfile(1);
            }

            function checkAuthentication() {
                $scope.isAuth = authService.mockCheckAuthentication();
                var authData = authService.getAuthentication();

                if (authData != null) {
                    $scope.username = authData.username;
                }
            }

            function scroll(elementId) {
                // Using defaults
                var element = document.getElementById(elementId);
                var options = {
                    duration: 700,
                    easing: 'easeInOutQuad', //originally it was 'easeInQuad'
                }
                $timeout(function () {
                    smoothScroll(element, options);
                },
                    100);
            }
        }]);