(function () {
    var app = angular.module("ComicsApp");

    var ComicsCreateController = function ($scope, ComicService, $location, $injector, ShareData) {

        var init = function () {            
            $scope.escritores = ShareData.value.escritores.data.escritores;
            $scope.companias = ShareData.value.companias.data.companias;
            $scope.titulo = "Crear comic";
        };

        $scope.CrearComic = function (comic) {

            if (!comic) {
                mostrarError({ mensaje: "Favor de agregar datos!" });
                return false;
            }

            let { titulo, anio, numero, escritor, compania } = comic;

            if (!titulo || !anio || !numero || !escritor || !compania) {
                if (!nombre || !escritor || !compania) {
                    mostrarError({ mensaje: "Para agregar un comic es necesario el t&iacute;tulo, escritor y la compa&ntilde;ia!" });
                    return false;
                }
                if (!anio) {
                    comic["anio"] = 1900;
                }
                if (!numero) {
                    comic["numero"] = 0;
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

    app.controller("ComicsCreateController", [
        "$scope",
        "ComicService",
        "$location",
        "$injector",
        "ShareData",
        ComicsCreateController
    ]);
}());
