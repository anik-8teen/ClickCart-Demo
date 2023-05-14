app.controller("packages", function ($scope, $http, $window) {
    
    if(localStorage.getItem('token') != null) {
        $http.get("https://localhost:44366/api/allproduct").then(function (resp) {
            $scope.packages = resp.data;
        });
    } else $window.location.href = '#!/login';
});
