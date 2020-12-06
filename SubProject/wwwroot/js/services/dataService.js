define([], () => {

    let token;

    var data = localStorage.getItem('auth');

    if (data != undefined) {
        token = JSON.parse(data);
    }


    let getMovies = (callback) => {
        fetch('api/movies', {
            headers: {
                'Authorization': 'Bearer ' + token.token
                // 'Content-Type': 'application/x-www-form-urlencoded',
            }
        })
        .then(response => response.json())
        .then(callback);
    }

    let register = (values, callback) => {
        fetch('api/auth/register', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
                // 'Content-Type': 'application/x-www-form-urlencoded',
            },
            body: JSON.stringify(values)
        })
            .then(response => response.json())
            .then(callback);
    }

    let login = (values, callback) => {
        fetch('api/auth/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
                // 'Content-Type': 'application/x-www-form-urlencoded',
            },
            body: JSON.stringify(values)
        })
            .then(response => response.json())
            .then(callback);
    }

    let checkIfAuthenticated = (callback) => {
        fetch('api/auth/checkifauthenticated', {
            headers: {
                'Authorization': 'Bearer ' + token.token
                // 'Content-Type': 'application/x-www-form-urlencoded',
            }
        })
            .then(response => response.json())
            .then(callback);
    }

    return {
        getMovies,
        register,
        login,
        checkIfAuthenticated
    }
});