define(['knockout', 'dataservice'], (ko, ds) => {

    return function (params) {
        let name = "Home";
        let movies = ko.observableArray([]);
        let selectedTitle = ko.observable();

       

        ds.getMovies(function (data) {
            movies(data)
            console.log(data)
            showstuff(data[0]);
        });

        
        let showstuff = title => {
            console.log("selecting title");
            selectedTitle(title);
            console.log(selectedTitle().id)
        };


        //debugger;
        

        return {
            showstuff,
            selectedTitle,
            movies
        }

        
    }
    

});