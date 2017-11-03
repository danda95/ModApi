var app = angular.module('app', ['ui.grid', 'ui.grid.edit']);
app.controller('MainCtrl', ['$scope', '$http', function ($scope, $http) {
    $scope.adatleker = function () {
        $http.get('json/data.json')
            .success(function (data) {
                $scope.gridOptions.data = data;
                alert("Succed!")
            });
    }
    $scope.deleteRow = function (row) {
        $http.post("/api/delete", { id: row.entity.id }).success(function (response) {
            $scope.adatleker();
        });
    }
    $scope.updateRow = function (row) {
        $http.post("/api/update", { id: row.entity.id, name: row.entity.Name, species: row.entity.Species, numberoflegs: row.entity.NumberOfLegs }).success(function (response) {
            $scope.adatleker();
        });
    }
    $scope.addData = function (textBoxName, textBoxSpecies, textBoxNumberOfLegs) {
        $http.post("/api/insert", { name: textBoxName, species: textBoxSpecies, numberoflegs: textBoxNumberOfLegs })
            .success(function (response) {
                $scope.adatleker();
            }
        );
    };
    $scope.gridOptions = {
        columnDefs: [
            { field: 'id' },
            { field: 'Name' },
            { field: 'Species' },
            { field: 'NumberOfLegs' },
            { field: 'Delete', cellTemplate: '<button class="btn primary" ng-click="grid.appScope.deleteRow(row)">Delete</button>'},
            { field: 'Update', cellTemplate: '<button class="btn primary" ng-click="grid.appScope.updateRow(row)">Update</button>' }
        ]
    };
    $http.get('json/data.json')
        .success(function (data) {
            $scope.gridOptions.data = data;
        });
}]);
