define(['knockout', 'dataservice'], (ko, ds) => {

    return function (params) {
        let name = "Favorite";
        let movies = ko.observableArray([]);

        ds.getFavoriteMovies(params.userName(), function (data) {
            movies(data);
        });
       
        return {
            name,
            movies
        }
    }
    

});