define(['knockout', 'dataservice'], (ko, ds) => {
    return function (params) {

        let name = "Home";
        let rating = ko.observableArray([]);
        let actors = ko.observableArray([]);
        let movie = ko.observableArray([]);
        let OMDB = ko.observableArray([]);

        let similarmovies = ko.observableArray([]);
        
        console.log(params.titleid);

        ds.getMovie(params.titleid, function (data) {
            movie(data)
            //waits for movie to get data
            ds.getOMDB(params.titleid, function (data) {
                OMDB(data)
                ds.getActorsForMovie(params.titleid, function (data) {
                    actors(data);
                    ds.getRating(params.titleid, function (data) {
                        rating(data)

                        console.log(data);
                        ds.getSimilarMovies(movie().originalTitle, function (data) {
                            similarmovies(data)
                            console.log(data)
                        });

                    });
                });
            });
        });

        return {
            similarmovies,
            rating,
            actors,
            movie,
            OMDB
        }

     
       

    }
});
