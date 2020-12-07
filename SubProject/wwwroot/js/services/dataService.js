define([], () => {

    let getMovies = (callback) => {
        fetch('api/movies')
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




    return {
        getRating,
        getMovies,
        getMovie,
        getActorsForMovie,
        getOMDB
    }
        
    
});
