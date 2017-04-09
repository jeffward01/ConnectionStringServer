var app = angular.module('ConStrApp', ['ui.router', 'LocalStorageModule', 'angular-loading-bar', 'ngSanitize', 'btorfs.multiselect']);


app.config(function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise('/app/home');

    //States
    $stateProvider.state('app',
        {
            url: '/app',
            templateUrl: './app/Views/app.html',
            controller: 'appCtrl',
            data: {
                displayName: 'App'
            }
        })
        .state('app.home',
        {
            templateUrl: './app/Views/home.html',
            url: '/home',
            controller: 'homeCtrl',
            data: {
                displayName: 'Home'
            },
        })
        .state('app.about',
        {
            templateUrl: './app/Views/about.html',
            url: '/about',
            controller: 'aboutCtrl',
            data: {
                displayName: 'About'
            },
        })
        .state('app.documentaion',
        {
            templateUrl: './app/Views/documentation.html',
            url: '/about',
            controller: 'documentationCtrl',
            data: {
                displayName: 'Documentation'
            },
        })
        .state('app.login',
        {
            templateUrl: './app/Views/login.html',
            url: '/login',
            controller: 'loginCtrl',
            data: {
                displayName: 'Login'
            },
        })
        .state('app.project',
        {
            abstract: true,
            url: '/project',
            template: '<ui-view>'
        })
        .state('app.project.viewProject',
        {
            url: '/viewProject/:projectId',
            templateUrl: './app/Views/viewProject.html',
            controller: 'viewProjectCtrl',
            data: {
                displayName: 'View Project'
            },
            params: {
                projectId: null
            }
        })
        .state('app.project.editProject',
        {
            url: '/editProject/:projectId',
            templateUrl: './app/Views/viewProject.html',
            controller: 'viewProjectCtrl',
            data: {
                displayName: 'View Project'
            },
            params: {
                projectId: null
            }
        })
        .state('app.project.addProject',
        {
            url: '/addProject',
            templateUrl: './app/Views/addProject.html',
            controller: 'addProjectCtrl',
            data: {
                displayName: 'Add Project'
            },
            params: {
                projectId: null
            }
        });
})