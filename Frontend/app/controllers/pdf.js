app.controller("pdf", function ($scope, ajax, $window) {


    
        $scope.submit = function () {
            ajax.get("https://localhost:44366/api/pdf", $scope.post, success, error);
        }

        function success(response){
            console.log(response);
        }

        function error(error){
            console.log(error);
        }
        
} );
