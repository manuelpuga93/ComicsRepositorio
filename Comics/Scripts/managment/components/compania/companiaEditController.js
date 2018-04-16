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

    app.controller("CompaniaEditController", [
        "$scope",
        "CompaniaService",
        "$location",
        "$injector",
        "ShareData",
        CompaniaEditController
    ]);
}());
