(function () {
    var app = angular.module("ComicsApp");

    var EscritoresController = function ($scope, EscritorService, $location, $injector, ShareData) {
        var init = function () {
            $scope.pagination = {
                totalItems: 0,
                currentPage: 1,
                itemsPerPage: 5
            }

            $scope.ConsultarEscritores(($scope.pagination.currentPage - 1) * 5, $scope.pagination.itemsPerPage);
        };

        $scope.ConsultarEscritores = function (skip, take) {
            EscritorService.ConsultarEscritores(skip, take).then(function (data) {
                $scope.escritoresInfo = data.escritores;
                $scope.pagination.totalItems = data.totalEscritores
            }, mostrarError);
        };

        //To Edit Student Information  
        $scope.EditEscritor = function (escritorId) {
            ShareData.value = escritorId;
            $location.path("/editescritor");
        } 

        $scope.CreateEscritor = function () {
            $location.path("/createescritor");
        }


        $scope.EliminarEscritor = function (escritorId) {
            EscritorService.EliminarEscritor(escritorId).then(function (reason) {
                mostrarAlerta('Operación completada', 'Los datos del escritor han sido correctamente eliminados.', TiposAlerta.EXITO);
                $scope.ConsultarEscritores(($scope.pagination.currentPage - 1) * 5, $scope.pagination.itemsPerPage);
            }, mostrarError);
        };

        $scope.pageChanged = function () {
            $scope.ConsultarEscritores(($scope.pagination.currentPage - 1) * 5, $scope.pagination.itemsPerPage);
        };

        var mostrarError = function (reason) {
            if (reason.data) {
                mostrarAlerta('Error', 'Ha ocurrido un error inesperado.', TiposAlerta.ERROR);
            }
            else {
                if (reason.status = 404) {
                    $scope.comicsInfo = null;
                    mostrarAlerta('Sin registros', 'No se encontraron registros.', TiposAlerta.ADVERTENCIA);
                }
                else {
                    mostrarAlerta('Error', 'Ha ocurrido un error inesperado.', TiposAlerta.ERROR);
                }
            }
        };

        init();
    };

    app.controller("EscritoresController", [
        "$scope",
        "EscritorService",
        "$location",
        "$injector",
        "ShareData",
        EscritoresController
    ]);
}());
