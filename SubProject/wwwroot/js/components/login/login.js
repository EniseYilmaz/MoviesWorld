define(['knockout', 'dataservice'], (ko, ds) => {
    return function () {
        let name = "Home";
        let movies = ko.observableArray([]);

        ds.getMovies(function (data) { movies(data) });
        //debugger;
        return {
            movies
        }
    }
});