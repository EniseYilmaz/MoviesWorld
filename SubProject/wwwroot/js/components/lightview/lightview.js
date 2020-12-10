define(['knockout', 'dataservice'], (ko, ds) => {
    return function (params) {
        let buttontext = ko.observable("More Info");
        let rating = ko.observableArray([]);
        let movie = ko.observableArray([]);
        let OMDB = ko.observableArray([]);
        let infocheck = ko.observable(true);
        const titleid = params.titleid;

        setTimeout(() => {
            ds.getMovie(titleid, function (data) {
                movie(data)
                //waits for movie to get data
                ds.getOMDB(titleid, function (data) {
                    OMDB(data)
                    ds.getRating(titleid, function (data) {
                        rating(data)
                    });
                });
            });
        }, 400);
        
               
            




        return {
            infocheck,
            buttontext,
            
            rating,
            movie,
            OMDB,
            titleid
        }


    }

});
