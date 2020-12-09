define(['knockout', 'dataservice'], (ko, ds) => {
    return function (params) {
        let buttontext = ko.observable("More Info");
        let rating = ko.observableArray([]);
        let movie = ko.observableArray([]);
        let OMDB = ko.observableArray([]);
        let infocheck = ko.observable(true);
        const titleid = params.id || "";
        console.log("loaded light view");
        let generatelightview = title => {
            if (infocheck()) {
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
                infocheck(false);
                buttontext("hide info")
                console.log(infocheck);
            } else {
                buttontext("more info")
                rating("");
                movie("");
                OMDB("");
                infocheck(true);
            }
        }




        return {
            buttontext,
            generatelightview,
            rating,
            movie,
            OMDB,
            titleid
        }


    }

});
