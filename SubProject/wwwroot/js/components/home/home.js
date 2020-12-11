
define(['knockout', 'dataservice'], (ko, ds) => {
    return function (params) {
        let name = "Home";
        let popularMovies = ko.observableArray([]);

        ds.getPopularMovies(function (data) {
            popularMovies(data)
            console.log(popularMovies())
            
        });

        
        return {
            name,
            popularMovies
        }
    }
});
