define(['knockout', 'dataservice'], (ko, ds) => {
    return function (params) {
        let buttontext = ko.observable("More Info");
        let rating = ko.observableArray([]);
        let movie = ko.observableArray([]);
        let OMDB = ko.observableArray([]);
        let infocheck = ko.observable(true);
        console.log(infocheck());
        const titleid = params.titleid;
        console.log(titleid);

        console.log("loaded light view");
        setTimeout(() => {
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
