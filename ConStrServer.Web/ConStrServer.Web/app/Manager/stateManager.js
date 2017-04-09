angular.module('ConStrApp')
    .factory('stateManager', ['$document', '$state', function ($document, $state) {
        var stateMangerFactory = {}

        var _goHome = function () {
            $state.go('app.home', {});
        }

        var _addProject = function () {
            $state.go('app.project.addProject', {});
        }

        var _editProject = function () {
            $state.go('app.project.editProject', {});
        }
        var _login = function () {
            $state.go('app.login', {});
        }

        var _viewProject = function () {
            $state.go('app.project.viewProject', {});
        }

        var _about = function () {
            $state.go('app.about', {});
        }
        var _documentation = function () {
            $state.go('app.documentation', {});
        }
        stateMangerFactory.goHome = _goHome;
        stateMangerFactory.addProject = _addProject;
        stateMangerFactory.editProject = _editProject;
        stateMangerFactory.viewProject = _viewProject;
        stateMangerFactory.login = _login;
        stateMangerFactory.about = _about;
        stateMangerFactory.documentation = _documentation;

        return stateMangerFactory;
    }]);