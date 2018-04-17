(function () {
    var app = angular.module("ComicsApp");

    var ComicsCreateController = function ($scope, ComicService, $location, $injector, ShareData) {

        var init = function () {
            $scope.titulo = "Crear comic";
        };

        var mostrarError = function (reason) {
            if (reason.data) {
                mostrarAlerta('Error', 'Ha ocurrido un error inesperado.', TiposAlerta.ERROR);
            }
            else {
                mostrarAlerta('Error', 'Ha ocurrido un error inesperado.', TiposAlerta.ERROR);
            }
        };

        init();
    };

    app.controller("ComicsCreateController", [
        "$scope",
        "ComicService",
        "$location",
        "$injector",
        "ShareData",
        ComicsCreateController
    ]);
}());
