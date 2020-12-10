define(['knockout', 'dataservice'], (ko, ds) => {
    return function (params) {
        let name = "Login";

        let username = ko.observable();
        let password = ko.observable();
        let error = ko.observable('');

        let login = () => {

            var values = {
                UserName: username(),
                Password: password()
            }

            ds.login(values, function (data) {
                if (data.status !== undefined && data.status === 400) {
                    error("User not found.");
                    params.setAuthStorage('');
                    params.setIsLoggedIn(false);
                } else {
                    error("");
                    params.setAuthStorage(data);
                    params.setIsLoggedIn(true);
                    params.setUserName(data);
                    params.changeContent('home');
                }
            });
        } 

     

        return {
            username, password, error, login
        }
    }
});