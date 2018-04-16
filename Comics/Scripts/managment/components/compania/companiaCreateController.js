(function () {
    var app = angular.module("ComicsApp");

    var CompaniaCreateController = function ($scope, CompaniaService, $location, $injector, ShareData) {

        var init = function () {
            $scope.titulo = "Crear comic";
        };

        var mostrarError = function (reason) {
            let mensaje = (reason.mensaje) ? reason.mensaje : 'Ha ocurrido un error inesperado.';

            if (reason.data) {
                mostrarAlerta('Error', mensaje, TiposAlerta.ERROR);
            }
            else {
                mostrarAlerta('Error', mensaje, TiposAlerta.ERROR);
            }
        };

        $scope.CrearCompania = function (compania) {
            debugger;
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
            CompaniaService.CrearCompania(compania);
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
