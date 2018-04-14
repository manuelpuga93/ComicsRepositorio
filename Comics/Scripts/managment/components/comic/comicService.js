(function () {
    var app = angular.module("ComicsApp");

    var ComicService = function ($http, API_CONFIG) {
        var _consultarComics = function (skip, take) {
            return $http.get(API_CONFIG.url + '/comic?skip=' + skip + '&take=' + take).then(function (response) {
                return response.data;
            });
        };

        var _consultarComicPorId = function (comicId) {
            return $http.get(API_CONFIG.url + '/comic/' + comicId).then(function (response) {
                return response.data;
            });
        };

        var _crearComic = function (comic) {
            return $http.post(API_CONFIG.url + '/comic', comic);
        };

        var _actualizarComic = function (comic) {
            return $http.put(API_CONFIG.url + '/comic/' + comic.id, comic);
        };

        var _eliminarComic = function (comicId) {
            return $http.delete(API_CONFIG.url + '/comic/' + comicId);
        };


        var _consultarCodigoComic = function () {
            return $http.get(API_CONFIG.url + '/comic/codigo').then(function (response) {
                return response.data;
            });
        };

        var _consultarTodosCodigosComic = function () {
            return $http.get(API_CONFIG.url + '/comic/codes').then(function (response) {
                return response.data;
            });
        };

        return {
            ConsultarComics: _consultarComics,
            ConsultarComicPorId: _consultarComicPorId,
            CrearComic: _crearComic,
            ActualizarComic: _actualizarComic,
            EliminarComic: _eliminarComic,
            ConsultarCodigoComic: _consultarCodigoComic,
            ConsultarTodosCodigosComic: _consultarTodosCodigosComic
        };
    }

    app.factory("ComicService", ["$http", "API_CONFIG", ComicService]);
}());