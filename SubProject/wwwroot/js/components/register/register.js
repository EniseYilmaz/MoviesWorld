define(['knockout', 'dataservice'], (ko, ds) => {
    return function () {
        let name = "Register";

        let username = ko.observable();
        let fullname = ko.observable();
        let email = ko.observable();
        let password = ko.observable();
        let error = ko.observable('');
        let success = ko.observable('');

        let register = () => {
            var values = {
                UserName: username(),
                Name: fullname(),
                Email: email(),
                Password: password()
            }

            ds.register(values, function (data) {
                if (data.status !== undefined && data.status === 400) {
                    error("Username is already taken.");
                    success('');
                } else {
                    success("Hi " + data.userName + ", register successful. Please proceed to login.");
                    username(''); fullname(''); email(''); password(''); error('');
                }
            });
        } 

        //debugger
        return {
            username, fullname, email, password, register, error, success
        }
    }
});