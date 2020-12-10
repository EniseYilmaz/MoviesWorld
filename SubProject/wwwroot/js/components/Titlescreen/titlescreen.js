define(['knockout', 'dataservice'], (ko, ds) => {
    return function (params) {

        let name = "Home";
        let rating = ko.observableArray([]);
        let actors = ko.observableArray([]);
        let movie = ko.observableArray([]);
        let OMDB = ko.observableArray([]);
        ds.getMovie(params.titleid, function (data) {
            movie(data)
            //waits for movie to get data
            ds.getOMDB(params.titleid, function (data) {
                OMDB(data)
                ds.getActorsForMovie(params.titleid, function (data) {
                    actors(data);
                    ds.getRating(params.titleid, function (data) {
                        rating(data)

                    });
                });
            });
        });

        return {
            rating,
            actors,
            movie,
            OMDB
        }

     
       

    }
});
