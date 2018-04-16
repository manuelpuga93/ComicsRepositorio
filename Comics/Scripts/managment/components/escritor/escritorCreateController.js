(function () {
    var app = angular.module("ComicsApp");

    var EscritorCreateController = function ($scope, EscritorService, $location, $injector, ShareData) {

        var init = function () {
            $scope.titulo = "Crear escritor";
        };

        $scope.CrearEscritor = function (escritor) {
            
            if (!escritor) {
                mostrarError({ mensaje: "Favor de agregar datos!" });
                return false;
            }

            let { nombre, apellido, nacimiento } = escritor;

            if (!nombre || !apellido || !nacimiento) {
                if (!nombre || apellido) {
                    mostrarError({ mensaje: "Favor de agregar el nombre y apellido!" });
                    return false;
                }
                if (!nacimiento) {
                    compania["nacimiento"] = 'NA';
                }
            }

            EscritorService.CrearEscritor(escritor).then(function (data) {
                mostrarAlerta('Operación completada', 'El escritor se ha creado correctamente.', TiposAlerta.EXITO);
                $location.path("/showescritores");
            }, mostrarError);
        };

        var mostrarError = function (reason) {
            let mensaje = (reason.mensaje) ? mensaje : 'Ha ocurrido un error inesperado.';

            if (reason.data) {
                mostrarAlerta('Error', 'Ha ocurrido un error inesperado.', TiposAlerta.ERROR);
            }
            else {
                if (reason.status = 404) {
                    $scope.escritor = null;
                    mostrarAlerta('Sin registros', 'No se encontraron registros.', TiposAlerta.ADVERTENCIA);
                }
                else {
                    mostrarAlerta('Error', mensaje, TiposAlerta.ERROR);
                }
            }
        };

        init();
    };

    app.controller("EscritorCreateController", [
        "$scope",
        "EscritorService",
        "$location",
        "$injector",
        "ShareData",
        EscritorCreateController
    ]);
}());
