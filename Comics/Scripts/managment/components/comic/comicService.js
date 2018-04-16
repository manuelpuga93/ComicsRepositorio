(function () {
    var app = angular.module("ComicsApp");

    var ComicService = function ($http, API_CONFIG) {
        var _consultarComics = function (skip, take) {
            return $http.get(API_CONFIG.url + '/comics?skip=' + skip + '&take=' + take).then(function (response) {
                return response.data;
            });
        };

        var _consultarComicPorId = function (comicId) {
            return $http.get(API_CONFIG.url + '/comics/' + comicId).then(function (response) {
                return response.data;
            });
        };

        var _crearComic = function (comic) {
            return $http.post(API_CONFIG.url + '/comics', comic);
        };

        var _actualizarComic = function (comic) {
            return $http.put(API_CONFIG.url + '/comics/' + comic.id, comic);
        };

        var _eliminarComic = function (comicId) {
            return $http.delete(API_CONFIG.url + '/comics/' + comicId);
        };

        var _obtenerEscritores = function () {
            return $http.delete(API_CONFIG.url + '/escritores');
        };

        var _obtenerCompanias = function (companiaId) {
            return $http.delete(API_CONFIG.url + '/companias');
        };

        return {
            ConsultarComics: _consultarComics,
            ConsultarComicPorId: _consultarComicPorId,
            CrearComic: _crearComic,
            ActualizarComic: _actualizarComic,
            EliminarComic: _eliminarComic,
            ObtenerEscritores: _obtenerEscritores,
            ObtenerCompanias: _obtenerCompanias
        };
    }

    app.factory("ComicService", ["$http", "API_CONFIG", ComicService]);
}());