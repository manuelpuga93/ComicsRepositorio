(function () {
    var app = angular.module("ComicsApp");

    var ComicEditController = function ($scope, ComicService, $location, $injector, ShareData) {

        var init = function () {
            ComicService.ConsultarComicPorId(ShareData.value).then(function (data) {
                    $scope.comic = data;
            });
            $scope.titulo = "Editar comic";
            
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

    app.controller("ComicEditController", [
        "$scope",
        "ComicService",
        "$location",
        "$injector",
        "ShareData",
        ComicEditController
    ]);
}());
