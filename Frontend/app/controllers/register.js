app.controller("register", function ($scope, ajax, $window) {

    if (localStorage.getItem('token') == null) {
        $scope.submit = function () {
            ajax.post("https://localhost:44366/api/user/add" + $scope.accountType, $scope.post, success, error);
        }

        function success(response) {
            /*console.log(response);*/
            $window.location.href = '#!/login'
        }

        function error(error) {
            console.log(error);
        }
    } 
})
