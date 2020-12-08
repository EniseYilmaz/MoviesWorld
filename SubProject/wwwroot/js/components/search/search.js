define(['knockout', 'dataservice'], (ko, ds) => {
    return function (params) {
        let name = "Search";
        let movies = ko.observableArray([]);

        ds.search(params.keyword(), function (data) { movies(data) });
        ds.getMovies(function (data) { });

        //debugger;
        return {
            movies
        }
    }
});