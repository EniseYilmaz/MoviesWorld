define([], () => {
    return function (params) {
        let name = "Home";

        let login = () => {
            console.log(params.isLoggedIn());
        }

        return {
            name,
            login
        }
    }
});