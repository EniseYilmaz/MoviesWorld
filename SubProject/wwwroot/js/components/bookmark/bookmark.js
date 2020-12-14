define(['knockout', 'dataservice'], (ko, ds) => {

    return function (params) {
        let name = "Favorite";
        let movies = ko.observableArray([]);

        

        let getMovies = () => {
            ds.getBookmarkedMovies(params.userName(), function (data) {
                movies(data);
            });
        }

        let remove = movieId => {
            ds.removeMovieBookmark(params.userName(), movieId, function (data) {
                if (data) {
                    getMovies();
                }
            });
        }

        getMovies();

        return {
            name,
            movies,
            remove
        }
    }
});