(function () {
    var app = angular.module("ComicsApp");

    var CompaniasController = function ($scope, CompaniaService, $location, $injector, ShareData) {
        var init = function () {
            $scope.pagination = {
                totalItems: 0,
                currentPage: 1,
                itemsPerPage: 5
            }

            $scope.ConsultarCompanias(($scope.pagination.currentPage - 1) * 5, $scope.pagination.itemsPerPage);
        };

        $scope.ConsultarCompanias = function (skip, take) {
            CompaniaService.ConsultarCompanias(skip, take).then(function (data) {
                $scope.companiasInfo = data.companias;
                $scope.pagination.totalItems = data.totalCompanias
            }, mostrarError);
        };

        //To Edit Student Information  
        $scope.EditCompania = function (companiaId) {
            ShareData.value = companiaId;
            $location.path("/editcompania");
        }

        $scope.CreateCompania = function () {
            $location.path("/createcompania");
        }

        $scope.EliminarCompania = function (companiaId) {
            CompaniaService.EliminarCompania(companiaId).then(function (reason) {
                mostrarAlerta('Operación completada', 'Los datos de la compania han sido correctamente eliminados.', TiposAlerta.EXITO);
                $scope.ConsultarCompanias(($scope.pagination.currentPage - 1) * 5, $scope.pagination.itemsPerPage);
            }, mostrarError);
        };

        $scope.pageChanged = function () {
            $scope.ConsultarCompanias(($scope.pagination.currentPage - 1) * 5, $scope.pagination.itemsPerPage);
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

    app.controller("CompaniasController", [
        "$scope",
        "CompaniaService",
        "$location",
        "$injector",
        "ShareData",
        CompaniasController
    ]);
}());
