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
            .then(error => {
                handleError(error);
            })
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
    
    let getOMDB = (id, callback) => {
        fetch(`api/movies/OMDB/${id}`)
            .then(response => response.json())
            .then(callback);
    }

    let getActorsForMovie = (id, callback) => {
        fetch(`api/actors/${id}`)
            .then(response => response.json())
            .then(callback);
    }

    let getMovie = (id , callback) => {
        fetch(`api/movies/${id}`)
            .then(response => response.json())
            .then(callback);
        return callback;

    }

    let getRating = (id, callback) => {
        fetch(`api/rating/${id}`)
            .then(response => response.json())
            .then(callback);
        return callback;

    }




    let search = (keyword, callback) => {
        fetch('api/search/' + keyword)
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
            .then(error => {
                handleError(error);
            })
            .then(callback);
    }

    let handleError = (error) => {
        if (error.status === 401) {
            localStorage.setItem('auth', '');
            alert('Your login has expired, please proceed to login.')
        }
    }

    return {
        getRating,
        getMovie,
        getActorsForMovie,
        getOMDB
        getMovies,
        register,
        login,
        checkIfAuthenticated,
        search
    }
        
    
});
