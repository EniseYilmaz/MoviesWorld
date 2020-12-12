define(['knockout', 'dataservice'], (ko, ds) => {
    return function (params) {

        let name = "Movie";
        let rating = ko.observableArray();
        let actors = ko.observableArray([]);
        let movie = ko.observableArray();
        let OMDB = ko.observableArray();

        let similarmovies = ko.observableArray([]);
        
        console.log(params.titleid);

        ds.getMovie(params.titleid, function (data) {
            console.log("getting movie data... ")
            movie(data)
            //waits for movie to get data
            ds.getOMDB(params.titleid, function (data) {

                console.log("getting OMDB data... ")
                OMDB(data)
                
                ds.getActorsForMovie(params.titleid, function (data) {
                    console.log("getting actors... ")
                    actors(data)

                    ds.getRating(params.titleid, function (data) {
                        console.log(Math.round(data))
                        rating(Math.round(data))
                        ds.getSimilarMovies(movie().originalTitle, function (data) {
                            similarmovies(data)
                            console.log("getting similar movies... ")
                            console.log(similarmovies())
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
