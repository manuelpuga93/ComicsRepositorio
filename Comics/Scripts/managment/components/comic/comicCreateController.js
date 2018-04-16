(function () {
    var app = angular.module("ComicsApp");

    var ComicCreateController = function ($scope, ComicService, $location, $injector, ShareData) {

        var init = function () {
            $scope.titulo = "Crear comic";
        };

        $scope.CrearComic = function (comic) {

            if (!comic) {
                mostrarError({ mensaje: "Favor de agregar datos!" });
                return false;
            }

            let { titulo, anio, numero, escritor, compania} = comic;

            if (!titulo || anio || numero || escritor || compania) {
                if (!titulo) {
                    mostrarError({ mensaje: "Favor de agregar el titulo!" });
                    return false;
                }
                if (!escritor || !compania) {
                    mostrarError({ mensaje: "Favor de seleccionar el escritor y la compa&ntilde;ia!" });
                    return false;
                }
                if (!anio) {
                    compania["anio"] = 'NA';
                }
                if (!numero) {
                    compania["anio"] = 'NA';
                }
            }

            ComicService.CrearComic(comic).then(function (data) {
                mostrarAlerta('Operación completada', 'El comic se ha creado correctamente.', TiposAlerta.EXITO);
                $location.path("/showcomics");
            }, mostrarError);
        };

        var mostrarError = function (reason) {
            let mensaje = (reason.mensaje) ? mensaje : 'Ha ocurrido un error inesperado.';

            if (reason.data) {
                mostrarAlerta('Error', 'Ha ocurrido un error inesperado.', TiposAlerta.ERROR);
            }
            else {
                if (reason.status = 404) {
                    $scope.comic = null;
                    mostrarAlerta('Sin registros', 'No se encontraron registros.', TiposAlerta.ADVERTENCIA);
                }
                else {
                    mostrarAlerta('Error', mensaje, TiposAlerta.ERROR);
                }
            }
        };

        init();
    };

    app.controller("ComicCreateController", [
        "$scope",
        "ComicService",
        "$location",
        "$injector",
        "ShareData",
        ComicCreateController
    ]);
}());
