define(['knockout', 'dataservice'], (ko, ds) => {

    return function (params) {
        let name = "Search";
        let movies = ko.observableArray([]);
        let resultsize = ko.observable();
        let selectedTitle = ko.observable();
        let lastkeyword = ko.observable(params.keyword());
        let lastusername = ko.observable(params.userName());
        let lastpage = ko.observable(0);
        let lastpagesize = ko.observable(8);
        let maxpage = ko.observable();
        let functionlimiter = ko.observable(true);
       

        let nextpage = results => {
            if (functionlimiter() && lastpage() != maxpage()- 1) {
                functionlimiter(false);
                console.log(functionlimiter())
                lastpage(lastpage() + 1);
                ds.search(lastkeyword(), lastusername(), lastpage(), lastpagesize(), function (data) {
                    console.log(data)
                    movies(data.searchResultsList)
                    resultsize(data.resultSize)
                });
                setTimeout(function () {
                    functionlimiter(true);
                }, 300);
            } else {
                console.log("still waiting...");
            }
           
        }

        let previouspage = results => {
            if (functionlimiter() && lastpage() != 0) {
                functionlimiter(false);
                console.log(functionlimiter())
                lastpage(lastpage() - 1);
                ds.search(lastkeyword(), lastusername(), lastpage(), lastpagesize(), function (data) {
                    console.log(data)
                    movies(data.searchResultsList)
                    resultsize(data.resultSize)
                });
                setTimeout(function () {
                    functionlimiter(true);
                }, 300);
            } else {
                console.log("limiter : " + functionlimiter());
                
            }

        }

        ds.search(params.keyword(), params.userName(), lastpage(), lastpagesize(), function (data) {
            console.log(data)
            movies(data.searchResultsList)
            resultsize(data.resultSize)
            maxpage(Math.ceil(resultsize() / lastpagesize()))
            console.log("maxpage : " + maxpage())
        });


        let changepagesize = size => {
            lastpagesize(size)
            maxpage(Math.ceil(resultsize() / lastpagesize()))
            console.log(lastpagesize());
            ds.search(lastkeyword(), lastusername(), lastpage(), lastpagesize(), function (data) {
                console.log(data)
                movies(data.searchResultsList)
                resultsize(data.resultSize)
            });
        }
       

        return {
            changepagesize,
            previouspage,
            maxpage,
            resultsize,
            lastpage,
            lastpagesize,
            lastusername,
            lastkeyword,
            nextpage,
            selectedTitle,
            movies
        }

        
    }
    

});