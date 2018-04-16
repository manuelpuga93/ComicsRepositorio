(function () {
    var app = angular.module("ComicsApp");

    var CompaniaService = function ($http, API_CONFIG) {
        var _consultarCompanias = function (skip, take) {
            return $http.get(API_CONFIG.url + '/companias?skip=' + skip + '&take=' + take).then(function (response) {
                return response.data;
            });
        };

        var _consultarCompaniaPorId = function (companiaId) {
            return $http.get(API_CONFIG.url + '/companias/' + companiaId).then(function (response) {
                return response.data;
            });
        };

        var _crearCompania = function (compania) {
            return $http.post(API_CONFIG.url + '/companias', compania);
        };

        var _actualizarCompania = function (compania) {
            return $http.put(API_CONFIG.url + '/companias/' + compania.id, compania);
        };

        var _eliminarCompania = function (companiaId) {
            return $http.delete(API_CONFIG.url + '/companias/' + companiaId);
        };

        return {
            ConsultarCompanias: _consultarCompanias,
            ConsultarCompaniaPorId: _consultarCompaniaPorId,
            CrearCompania: _crearCompania,
            ActualizarCompania: _actualizarCompania,
            EliminarCompania: _eliminarCompania
        };
    }

    app.factory("CompaniaService", ["$http", "API_CONFIG", CompaniaService]);
}());