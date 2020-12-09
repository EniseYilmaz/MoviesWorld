define(['knockout', 'dataservice'], (ko, ds) => {

    return function (params) {
        let name = "Search";
        let movies = ko.observableArray([]);
        let selectedTitle = ko.observable();
        let info = ko.observable(false);
       

        ds.getMovies(function (data) {
            movies(data)
            console.log(data)
            showstuff(data[0]);
        });

        
        showinfo = function (title) {
            console.log(info() + " showing title " + title);
            console.log("waiting..")
            setTimeout(function () {
                info(true)
                console.log("done waiting")
            }, 500);
            
        };

        hideinfo = function (title) {
            info(false);
            console.log(info() + " Hídding title " + title);
        }



        ds.search(params.keyword(), function (data) { movies(data) });
        ds.getMovies(function (data) { });

        //debugger;
        

        return {
            info,
            showinfo,
            hideinfo,
            selectedTitle,
            movies
        }

        
    }
    

});