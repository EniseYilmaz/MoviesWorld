define(['knockout', 'dataservice'], (ko, ds) => {
    return function (params) {

        let name = "Movie";
        let rating = ko.observableArray();
        let actors = ko.observableArray([]);
        let movie = ko.observableArray();
        let OMDB = ko.observableArray();
        let isBookmark = ko.observableArray(false);
        let isFav = ko.observableArray(false);
        let myRating = ko.observableArray();

        let similarmovies = ko.observableArray([]);
        
        console.log(params.titleid);

        ds.getMovie(params.titleid, function (data) {
            console.log("getting movie data... ")
            movie(data)
            //waits for movie to get data
            ds.getOMDB(params.titleid, function (data) {

                console.log("getting OMDB data... ")
                OMDB(data)
                
                ds.getActorsForMovie(params.titleid, function (data) {
                    console.log("getting actors... ")
                    actors(data)

                    ds.getRating(params.titleid, function (data) {
                        console.log(Math.round(data))
                        rating(Math.round(data))
                        ds.getSimilarMovies(movie().originalTitle, function (data) {
                            similarmovies(data)
                            console.log("getting similar movies... ")
                            console.log(similarmovies())
                        });
                    });
                });
            });
        });

        ds.getActivities(params.userName(), params.titleid, function (data) {
            isBookmark(data.isBookmarked);
            isFav(data.isFav);
            myRating(data.rating);
        });

        let addMovieFav = () => {
            ds.addMovieFav(params.userName(), params.titleid, function (data) {
                if (data) {
                    isFav(true);
                }
            });
        }

        let removeMovieFav = () => {
            ds.removeMovieFav(params.userName(), params.titleid, function (data) {
                if (data) {
                    isFav(false);
                }
            });
        }

        let addMovieBookmark = () => {
            ds.addMovieBookmark(params.userName(), params.titleid, function (data) {
                if (data) {
                    isBookmark(true);
                }
            });
        }

        let removeMovieBookmark = () => {
            ds.removeMovieBookmark(params.userName(), params.titleid, function (data) {
                if (data) {
                    isBookmark(false);
                }
            });
        }

        let rate = (value) => {

            var datas = {
                MovieId: params.titleid,
                UserName: params.userName(),
                Rating: value
            }

            ds.rateMovie(datas, function (data) {
                if (data) {
                    myRating(value);
                }
            });
        }

        return {
            similarmovies,
            rating,
            actors,
            movie,
            OMDB,
            myRating,
            isFav,
            isBookmark,
            addMovieFav,
            removeMovieFav,
            addMovieBookmark,
            removeMovieBookmark,
            rate
        }
    }
});
