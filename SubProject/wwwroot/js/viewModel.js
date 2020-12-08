define(['knockout', 'dataservice'], (ko, ds) => {

    let selectedComponent = ko.observable('home');
    let key = ko.observable('auth');
    let isLoggedIn = ko.observable(false);
    let keyword = ko.observable('');
    let currentParams = ko.observable({});

    let changeContent = (component) => {
        selectedComponent(component);
        if (component === 'search') {
            currentParams({ isLoggedIn: isLoggedIn, setIsLoggedIn: setIsLoggedIn, getAuthStorage: getAuthStorage, setAuthStorage: setAuthStorage, keyword: keyword});
        } else {
            currentParams({ isLoggedIn: isLoggedIn, setIsLoggedIn: setIsLoggedIn, getAuthStorage: getAuthStorage, setAuthStorage: setAuthStorage });
        }
    }

    let setIsLoggedIn = (value) => {
        isLoggedIn(value);
    } 

    //load auth from local storage
    let getAuthStorage = () => {
        var data = localStorage.getItem(key);

        if (data != undefined) {
            return JSON.parse(data);
        }
    }

    //set auth to local storage
    let setAuthStorage = (data) => {
        var data = localStorage.setItem(key(), ko.toJSON(data));
    }

    let search = () => {
        changeContent('search');
    }


    ds.checkIfAuthenticated(function (data) {
        if (data) {
            isLoggedIn(data);
        }
    });
    

    return {
        changeContent,
        selectedComponent,
        keyword,
        currentParams,
        search
    };
});