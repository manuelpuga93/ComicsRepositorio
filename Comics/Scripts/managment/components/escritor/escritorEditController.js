(function () {
    var app = angular.module("ComicsApp");

    var EscritorEditController = function ($scope, EscritorService, $location, $injector, ShareData) {

        var init = function () {
            $scope.EditEscritor(ShareData.value);
            $scope.titulo = "Editar escritor";
            
        };

        $scope.EditEscritor = function (escritorId) {
            EscritorService.ConsultarEscritorPorId(escritorId).then(function (data) {
                $scope.escritor = data;
            });
        };

        $scope.EditarEscritor = function (escritor) {            
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

            EscritorService.ActualizarEscritor(escritor).then(function (data) {
                mostrarAlerta('Operación completada', 'Los datos del escritor han sido correctamente actualizados.', TiposAlerta.EXITO);
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

    app.controller("EscritorEditController", [
        "$scope",
        "EscritorService",
        "$location",
        "$injector",
        "ShareData",
        EscritorEditController
    ]);
}());
