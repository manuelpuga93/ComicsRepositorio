(function () {
    var app = angular.module("ComicsApp");

    var ComicsController = function ($scope, ComicService, $location, $injector) {
        var init = function () {
            $scope.pagination = {
                totalItems: 0,
                currentPage: 1,
                itemsPerPage: 5
            }

            $scope.ConsultarComics(($scope.pagination.currentPage - 1) * 5, $scope.pagination.itemsPerPage);
        };

        $scope.ConsultarComics = function (skip, take) {
            ComicService.ConsultarComics(skip, take).then(function (data) {
                $scope.comicsInfo = data.comics;
                $scope.pagination.totalItems = data.totalComics
            }, mostrarError);
        };

        $scope.EliminarUnidad = function (comicId) {
            ComicService.EliminarUnidad(comicId).then(function (reason) {
                mostrarAlerta('Operación completada', 'Los datos de la comic han sido correctamente eliminados.', TiposAlerta.EXITO);
                $scope.ConsultarComics(($scope.pagination.currentPage - 1) * 5, $scope.pagination.itemsPerPage);
            }, mostrarError);
        };

        $scope.pageChanged = function () {
            $scope.ConsultarComics(($scope.pagination.currentPage - 1) * 5, $scope.pagination.itemsPerPage);
        };

        var mostrarError = function (reason) {
            if (reason.data) {
                mostrarAlerta('Error', 'Ha ocurrido un error inesperado.', TiposAlerta.ERROR);
            }
            else {
                if (reason.status = 404) {
                    $scope.comicsInfo = null;
                    mostrarAlerta('Sin registros', 'No se encontraron registros.', TiposAlerta.ADVERTENCIA);
                }
                else {
                    mostrarAlerta('Error', 'Ha ocurrido un error inesperado.', TiposAlerta.ERROR);
                }
            }
        };

        init();
    };

    app.controller("ComicsController", [
        "$scope",
        "ComicService",
        "$location",
        "$injector",
        ComicsController
    ]);
}());
