var EmpApp = angular.module('EmpApp', ['ngRoute']);
EmpApp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/list',
    {
        templateUrl: 'Employee/List.html',
        controller: 'ListController'
    }).
    when('/create',
    {
        //template : "<h1>Main</h1><p>Click on the links to change this content</p>"
        templateUrl: 'Employee/Edit.html',
        controller: 'EditController'
    }).
    when('/edit/:id',
    {
        templateUrl: 'Employee/Edit.html',
        controller: 'EditController'
    }).
    when('/delete/:id',
    {
        templateUrl: 'Employee/Delete.html',
        controller: 'DeleteController'
    }).
    otherwise(
    {
        redirectTo: '/list'
    });
}]);