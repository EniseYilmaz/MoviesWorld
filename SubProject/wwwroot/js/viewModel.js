define(['knockout', 'dataservice'], (ko, ds) => {
    let selectedComponent = ko.observable('home');
    let key = ko.observable('auth');
    let isLoggedIn = ko.observable(false);

    let changeContent = (component) => {
        selectedComponent(component);
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
        var data = localStorage.setItem(key, ko.toJSON(data));
    }

    return {
        changeContent,
        selectedComponent,
        setIsLoggedIn,
        isLoggedIn,
        getAuthStorage,
        setAuthStorage
    };
});