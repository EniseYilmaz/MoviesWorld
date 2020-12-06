define([], () => {

    let getMovies = (callback) => {
        fetch('api/movies')
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

    return {
        getMovies,
        register
    }
});