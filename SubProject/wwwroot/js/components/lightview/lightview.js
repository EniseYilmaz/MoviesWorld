define(['knockout', 'dataservice'], (ko, ds) => {
    return function (params) {

        let rating = ko.observableArray([]);
        let movie = ko.observableArray([]);
        let OMDB = ko.observableArray([]);
        const titleid = params.id || "";
        console.log(params.id);
        let generatelightview = title => {
            console.log("trying to generate view with :");
            console.log(titleid);
            ds.getMovie(titleid, function (data) {
                movie(data)
                console.log(data);
                //waits for movie to get data
                ds.getOMDB(titleid, function (data) {
                    OMDB(data)
                    console.log(data);
                    ds.getRating(titleid, function (data) {
                        rating(data)
                        console.log(data);
                    });
                });
            });
        }

            
            
        return {
            generatelightview,
            rating,
            movie,
            OMDB,
            titleid
        }


    }

});
