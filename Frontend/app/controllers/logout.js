app.controller("logout", function ($http, $window) {

    if(localStorage.getItem('token') != null) {
        $http.get("https://localhost:44366/api/logout")
            .then(function (response) {
                localStorage.removeItem('token');
            }), function (error) {
            console.log(error);
        }
    } else $window.location.href = '#!/login';
})