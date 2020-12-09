define(['knockout', 'dataservice'], (ko, ds) => {
    return function (params) {

        let name = "Home";
        let rating = ko.observableArray([]);
        let actors = ko.observableArray([]);
        let movie = ko.observableArray([]);
        let OMDB = ko.observableArray([]);
        console.log(params.titleid);
        ds.getMovie(params.titleid, function (data) {
            movie(data)
            console.log(data);
            //waits for movie to get data
            ds.getOMDB(params.titleid, function (data) {
                OMDB(data)
                console.log(data);
                ds.getActorsForMovie(params.titleid, function (data) {
                    actors(data)
                    console.log(data);
                    ds.getRating(params.titleid, function (data) {
                        rating(data)
                        console.log(data);

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
