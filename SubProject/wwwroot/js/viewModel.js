define(['knockout', 'dataservice'], (ko, ds) => {

    let selectedComponent = ko.observable('home');
    let quickComponent = ko.observable('lightview');
    let quickComponentParams = ko.observable({});
    let key = ko.observable('auth');
    let userName = ko.observable('Unknown');
    let isLoggedIn = ko.observable(false);
    let keyword = ko.observable('');

    let functionlimiter = ko.observable(true);

    let currentParams = ko.observable({});
    let changeContent = (component, titleid) => {
        if (functionlimiter()) {
            functionlimiter(false);
        
            if (component === 'search') {
                currentParams({ changeContent: changeContent, isLoggedIn: isLoggedIn, setIsLoggedIn: setIsLoggedIn, getAuthStorage: getAuthStorage, setAuthStorage: setAuthStorage, keyword: keyword, userName: userName });
            } else if (component === 'titlescreen'){
                currentParams({ titleid: titleid, changeContent: changeContent, isLoggedIn: isLoggedIn, setIsLoggedIn: setIsLoggedIn, getAuthStorage: getAuthStorage, setAuthStorage: setAuthStorage, userName: userName });
            }else {
                currentParams({ changeContent: changeContent, isLoggedIn: isLoggedIn, setIsLoggedIn: setIsLoggedIn, getAuthStorage: getAuthStorage, setAuthStorage: setAuthStorage, setUserName: setUserName, userName: userName });
            }
            selectedComponent(component);
            setTimeout(function () {
                functionlimiter(true);
            }, 100);
        }
    }

    let changeQuickComponent = (component, titleid) => {
        if (functionlimiter()) {
            functionlimiter(false);
            quickComponentParams({ titleid: titleid });
            quickComponent(component, titleid);
            setTimeout(function () {
                functionlimiter(true);
            }, 100);
        } else {
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

    //set auth to local storage
    let setUserName = (data) => {
        userName(data.userName);
    }


    let search = () => {
        changeContent('search');
    }

    let logout = () => {
        setAuthStorage('');
        isLoggedIn(false);
        changeContent('login');
    }


    ds.checkIfAuthenticated(function (data) {
        if (data === true) {
            isLoggedIn(data);
        } else if (data === undefined) {
            changeContent('login');
        }
    });

    return {
        changeQuickComponent,
        quickComponentParams,
        quickComponent,
        changeContent,
        selectedComponent,
        keyword,
        currentParams,
        search,
        isLoggedIn,
        logout,
        userName
    };

});