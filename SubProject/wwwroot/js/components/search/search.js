define(['knockout', 'dataservice'], (ko, ds) => {

    return function (params) {
        let name = "Search";
        let movies = ko.observableArray([]);
        let selectedTitle = ko.observable();
        let info = ko.observable(false);
        
        showinfo = function (title) {
            setTimeout(function () {
                info(true)
            }, 500);
            
        };

        hideinfo = function (title) {
            info(false);
        }



        ds.search(params.keyword(), function (data) { movies(data) });

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