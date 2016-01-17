var paginationApp = angular.module("paginationApp", ["angularUtils.directives.dirPagination"]);


/*************************************************************************/
// Controller

    
 paginationApp.controller('ItemsCtrl', function($scope, $http) {
    $scope.items = [];
    $scope.totalItems = 0;
    $scope.itemsPerPage = 10;// this should match however many results your API puts on one page
    getResultsPage(1);

    $scope.pagination = {
        current: 1
    };

    $scope.pageChanged = function(newPage) {
        getResultsPage(newPage);
    };

    function getResultsPage(pageNumber) {
        // this is just an example, in reality this stuff should be in a service
        $http.get('api/items?page=' + pageNumber + '&pageSize=' + $scope.itemsPerPage)
            .then(function(result) {
                console.log(result);
                $scope.items = result.data.Items;
                $scope.totalItems = result.data.TotalCount
            });
    }
});
