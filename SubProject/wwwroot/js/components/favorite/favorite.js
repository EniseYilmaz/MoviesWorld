define(['knockout', 'dataservice'], (ko, ds) => {

    return function (params) {
        let name = "Favorite";
        let movies = ko.observableArray([]);

        

        let getMovies = () => {
            ds.getFavoriteMovies(params.userName(), function (data) {
                movies(data);
            });
        }

        let remove = movieId => {
            ds.removeMovieFav(params.userName(), movieId, function (data) {
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