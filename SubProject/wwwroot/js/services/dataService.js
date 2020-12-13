define([], () => {


    let getToken = () => {
        let data = localStorage.getItem('auth');
        
        if (data != undefined && data != '') {

            let jsondata = JSON.parse(data);
            return 'Bearer ' + jsondata.token;
        }
    };

    


    let getMovies = (callback) => {
        fetch('api/movies', {
            headers: {
                'Authorization': getToken()
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
            },
            body: JSON.stringify(values)
        })
            .then(response => response.json())
            .then(callback);
    }
    
    let getSimilarMovies = (titlename, callback) => {
        fetch(`api/movies/similar/${titlename}`, {
            headers: {
                'Authorization': getToken()
            }
        })
            .then(response => response.json())
            .then(callback);
    }

    let getOMDB = (id, callback) => {
        fetch(`api/movies/OMDB/${id}`, {
            headers: {
                'Authorization': getToken()
            }
        })
            .then(response => response.json())
            .then(callback);
    }

    let getActorsForMovie = (id, callback) => {
        fetch(`api/actors/${id}`, {
            headers: {
                'Authorization': getToken()
            }
        })
            .then(response => response.json())
            .then(callback);
    }

    let getMovie = (id , callback) => {
        fetch(`api/movies/${id}`, {
            headers: {
                'Authorization': getToken()
            }
        })
            .then(response => response.json())
            .then(callback);
        return callback;

    }

    let getRating = (id, callback) => {
        fetch(`api/rating/${id}`, {
            headers: {
                'Authorization': getToken()
            }
        })
            .then(response => response.json())
            .then(callback);
        return callback;

    }




    let search = (keyword, userName, page, pagesize, callback) => {
        fetch('api/search/' + keyword + '/' + userName + '?page=' + page + '&pagesize=' + pagesize)
            .then(response => response.json())
            .then(callback);
    }

    let getPopularMovies = (callback) => {
        fetch('api/movies/popular', {
            headers: {
                'Authorization': getToken()
            }
        })
            .then(response => response.json())
            .then(callback);
    }

    let login = (values, callback) => {
        fetch('api/auth/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(values)
        })
            .then(response => response.json())
            .then(callback);
    }

    let checkIfAuthenticated = (callback) => {
        fetch('api/auth/checkifauthenticated', {
            headers: {
                'Authorization': getToken()
              }
            })
            .then(response => response.json())
            .then(callback);
    }

    let handleError = (error) => {
        //if (error.status === 401) {
        //    localStorage.setItem('auth', '');
        //    alert('Your login has expired, please proceed to login.')
        //}
    }


    let getActivities = (userName, movieId, callback) => {
        fetch(`api/common/activities/${userName}/${movieId}`, {
            headers: {
                'Authorization': getToken()
            }
        })
            .then(response => response.json())
            .then(callback);
        return callback;

    }

    let addMovieFav = (userName, movieId, callback) => {
        fetch(`api/favorites/movie/add/${userName}/${movieId}`, {
            headers: {
                'Authorization': getToken()
            }
        })
            .then(response => response.json())
            .then(callback);
        return callback;

    }

    let removeMovieFav = (userName, movieId, callback) => {
        fetch(`api/favorites/movie/remove/${userName}/${movieId}`, {
            headers: {
                'Authorization': getToken()
            }
        })
            .then(response => response.json())
            .then(callback);
        return callback;

    }

    let addMovieBookmark = (userName, movieId, callback) => {
        fetch(`api/bookmarks/movie/add/${userName}/${movieId}`, {
            headers: {
                'Authorization': getToken()
            }
        })
            .then(response => response.json())
            .then(callback);
        return callback;
    }

    let removeMovieBookmark = (userName, movieId, callback) => {
        fetch(`api/bookmarks/movie/remove/${userName}/${movieId}`, {
            headers: {
                'Authorization': getToken()
            }
        })
            .then(response => response.json())
            .then(callback);
        return callback;
    }

    let rateMovie = (data, callback) => {
        fetch('api/rating/add/movie', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': getToken()
            },
            body: JSON.stringify(data)
        })
            .then(response => response.json())
            .then(callback);
    }

    let getFavoriteMovies = (userName, callback) => {
        fetch(`api/favorites/${userName}`, {
            headers: {
                'Authorization': getToken()
            }
        })
            .then(response => response.json())
            .then(callback);
        return callback;
    }

    let getBookmarkedMovies = (userName, callback) => {
        fetch(`api/bookmarks/titles/${userName}`, {
            headers: {
                'Authorization': getToken()
            }
        })
            .then(response => response.json())
            .then(callback);
        return callback;
    }


    return {
        getSimilarMovies,
        getRating,
        getMovie,
        getActorsForMovie,
        getOMDB,
        getMovies,
        register,
        login,
        checkIfAuthenticated,
        search,
        getPopularMovies,
        getActivities,
        addMovieFav,
        removeMovieFav,
        addMovieBookmark,
        removeMovieBookmark,
        rateMovie,
        getFavoriteMovies,
        getBookmarkedMovies
    }
        
    
});
