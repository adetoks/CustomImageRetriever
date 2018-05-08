var app = angular.module('app', []);
app.controller('ctrl', function ($scope, $http) {
    $scope.image = [];
    $scope.error = [];
    $scope.formLoading = false;

    $scope.$watch('imageUrl', function () {
        $scope.error = [];
    });

    $scope.GetImage = function (form) {
        if (form.$valid) {
            $scope.formLoading = true;
            $scope.image = [];
            $scope.error = [];

            $http.get("/api/image?url=" + $scope.imageUrl).then(function (response) {
                $scope.image = response.data;
                $scope.formLoading = false;
                $scope.imageUrl = '';
                form.$setPristine();
            }, function (response) {
                console.log(response);

                if (response.status == 400) {
                    $scope.error = response.data;
                } else {
                    $scope.error.internalError = true;
                }
                $scope.formLoading = false;
            });

        }
    };

});