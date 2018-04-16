(function () {
    var app = angular.module("ComicsApp");

    var CompaniaEditController = function ($scope, CompaniaService, $location, $injector, ShareData) {

        var init = function () {
            $scope.EditCompania(ShareData.value);
            $scope.titulo = "Editar compania";
            
        };

        $scope.EditCompania = function (companiaId) {
            CompaniaService.ConsultarCompaniaPorId(companiaId).then(function (data) {
                $scope.compania = data;
            });
        };

        $scope.EditarCompania = function (compania) {            
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
            CompaniaService.ActualizarCompania(compania).then(function (data) {
                mostrarAlerta('Operación completada', 'Los datos de la compania han sido correctamente actualizados.', TiposAlerta.EXITO);
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
                    $scope.compania = null;
                    mostrarAlerta('Sin registros', 'No se encontraron registros.', TiposAlerta.ADVERTENCIA);
                }
                else {
                    mostrarAlerta('Error', mensaje, TiposAlerta.ERROR);
                }
            }
        };

        init();
    };

    app.controller("CompaniaEditController", [
        "$scope",
        "CompaniaService",
        "$location",
        "$injector",
        "ShareData",
        CompaniaEditController
    ]);
}());
