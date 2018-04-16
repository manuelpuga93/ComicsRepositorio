(function () {
    var app = angular.module("ComicsApp");

    var CompaniaCreateController = function ($scope, CompaniaService, $location, $injector, ShareData) {

        var init = function () {
            $scope.titulo = "Crear comic";
        };

        $scope.CrearCompania = function (compania) {
            
            if (!compania) {
                mostrarError({ mensaje: "Favor de agregar datos!" });
                return false;
            }

            let { nombre, founded } = compania;

            if (!nombre || !founded) {
                if (!nombre) {
                    mostrarError({ mensaje: "Favor de agregar el nombre!" });
                    return false;
                }
                if (!founded) {
                    compania["founded"] = 'NA';
                }
            }

            CompaniaService.CrearCompania(compania).then(function (data) {
                mostrarAlerta('Operación completada', 'La compa&ntilde;ia se ha creado correctamente.', TiposAlerta.EXITO);
                $location.path("/showcompanias");
            }, mostrarError);
        };

        var mostrarError = function (reason) {
            let mensaje = (reason.mensaje) ? mensaje : 'Ha ocurrido un error inesperado.';

            if (reason.data) {
                mostrarAlerta('Error', 'Ha ocurrido un error inesperado.', TiposAlerta.ERROR);
            }
            else {
                if (reason.status = 404) {
                    $scope.comicsInfo = null;
                    mostrarAlerta('Sin registros', 'No se encontraron registros.', TiposAlerta.ADVERTENCIA);
                }
                else {
                    mostrarAlerta('Error', mensaje, TiposAlerta.ERROR);
                }
            }
        };

        init();
    };

    app.controller("CompaniaCreateController", [
        "$scope",
        "CompaniaService",
        "$location",
        "$injector",
        "ShareData",
        CompaniaCreateController
    ]);
}());
