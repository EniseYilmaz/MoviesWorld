define(['knockout', 'dataservice'], (ko, ds) => {
    return function (params) {

        let name = "Home";

        let actors = ko.observableArray([]);
        let movie = ko.observableArray([]);
        let OMDB = ko.observableArray([]);

        ds.getMovie(params.id, function (data) {
            movie(data)
            console.log(data);
            //waits for movie to get data
            ds.getOMDB(params.id, function (data) {
                OMDB(data)
                console.log(data);

            });
        });


        return {
            actors,
            movie,
            OMDB
        }

     
       

    }
});
