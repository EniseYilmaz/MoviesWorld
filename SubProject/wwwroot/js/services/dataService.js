define([], () => {

    let getMovies = (callback) => {
        fetch('api/movies')
            .then(response => response.json())
            .then(callback);
    }

    return {
        getMovies
    }
});