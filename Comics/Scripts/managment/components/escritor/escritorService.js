(function () {
    var app = angular.module("ComicsApp");

    var EscritorService = function ($http, API_CONFIG) {
        var _consultarEscritores = function (skip, take) {
            return $http.get(API_CONFIG.url + '/escritores?skip=' + skip + '&take=' + take).then(function (response) {
                return response.data;
            });
        };

        var _consultarEscritorPorId = function (escritorId) {
            return $http.get(API_CONFIG.url + '/escritores/' + escritorId).then(function (response) {
                return response.data;
            });
        };

        var _crearEscritor = function (escritor) {
            return $http.post(API_CONFIG.url + '/escritores', escritor);
        };

        var _actualizarEscritor = function (escritor) {
            return $http.put(API_CONFIG.url + '/escritores/' + escritor.id, escritor);
        };

        var _eliminarEscritor = function (escritorId) {
            return $http.delete(API_CONFIG.url + '/escritores/' + escritorId);
        };

        return {
            ConsultarEscritores: _consultarEscritores,
            ConsultarEscritorPorId: _consultarEscritorPorId,
            CrearEscritor: _crearEscritor,
            ActualizarEscritor: _actualizarEscritor,
            EliminarEscritor: _eliminarEscritor
        };
    }

    app.factory("EscritorService", ["$http", "API_CONFIG", EscritorService]);
}());