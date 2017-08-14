//var EmpControllers = angular.module("EmpControllers", []);
// this controller call the api method and display the list of employees  
// in list.html  
EmpApp.controller("ListController", ['$scope', '$http',
    function ($scope, $http) {
        $http.get('/api/employee').then(function (data) {
            $scope.employees = data.data;
        });
    }
]);

// this controller call the api method and display the record of selected employee  
// in delete.html and provide an option for delete  
EmpApp.controller("DeleteController", ['$scope', '$http', '$routeParams', '$location',
    function ($scope, $http, $routeParams, $location) {
        $scope.id = $routeParams.id;
        $http.get('/api/employee/' + $routeParams.id).then(function (data) {
            $scope.firstname = data.data.FirstName;
            $scope.lastname = data.data.LastName;
            $scope.country = data.data.Country;
            $scope.state = data.data.State;
            $scope.salary = data.data.Salary;
            $scope.active = data.data.IsActive;
            $scope.dob = data.data.DateofBirth;
            $scope.description = data.data.Description;
        });
        $scope.delete = function () {
            $http.delete('/api/employee/' + $scope.id).then(function (data) {
                $location.path('/list');
            },function (data) {
                $scope.error = "An error has occured while deleting employee! " + data;
            });
        };
    }
]);
// this controller call the api method and display the record of selected employee  
// in edit.html and provide an option for create and modify the employee and save the employee record  
EmpApp.controller("EditController", ['$scope', '$filter', '$http', '$routeParams', '$location',
    function ($scope, $filter, $http, $routeParams, $location) {
        $http.get('/api/country').then(function (data) {
            $scope.countries = data.data;
        });
        $scope.id = 0;
        $scope.getStates = function () {
            var country = $scope.country;
            if (country) {
                $http.get('/api/country/' + country).then(function (data) {
                    $scope.states = data.data;
                });
            }
            else {
                $scope.states = null;
            }
        }
        $scope.save = function () {
            var obj = {
                EmployeeId: $scope.id,
                FirstName: $scope.firstname,
                LastName: $scope.lastname,
                Country: $scope.country,
                State: $scope.state,
                Salary: $scope.salary,
                IsActive: $scope.active,
                Description: $scope.description,
                DateofBirth: $scope.dob
            };
            if ($scope.id == 0) {
                debugger;
                $http.post('/api/Employee/', obj).then(function (data) {
                    $location.path('/list');
                }, function (data) {
                    debugger;
                    $scope.error = "An error has occured while adding employee! " + data.ExceptionMessage;
                });
            }
            else {
                $http.put('/api/Employee/', obj).then(function (data) {
                    $location.path('/list');
                },function (data) {
                    console.log(data);
                    $scope.error = "An Error has occured while Saving customer! " + data.ExceptionMessage;
                });
            }
        }
        if ($routeParams.id) {
            $scope.id = $routeParams.id;
            $scope.title = "Edit Employee";
            $http.get('/api/employee/' + $routeParams.id).then(function (data) {
                $scope.firstname = data.data.FirstName;
                $scope.lastname = data.data.LastName;
                $scope.country = data.data.Country;
                $scope.state = data.data.State;
                $scope.salary = data.data.Salary;
                $scope.active = data.data.IsActive;
                $scope.description = data.data.Description;
                $scope.dob = new Date(data.data.DateofBirth);
                $scope.getStates();
            });
        }
        else {
            $scope.title = "Create New Employee";
        }
    }
]);