require.config({
    baseUrl: "js",
    paths: {
        knockout: "lib/knockout/knockout-latest",
        text: "lib/require-text/text.min",
        dataservice: "services/dataService",
        
    }
});

require(['knockout', 'text'], (ko) => {
    ko.components.register("home", {
        viewModel: { require: "components/home/home" },
        template: { require: "text!components/home/home.html" }
    });

    ko.components.register("search", {
        viewModel: { require: "components/search/search" },
        template: { require: "text!components/search/search.html" }
    });

    ko.components.register("titlescreen", {
        viewModel: { require: "components/titlescreen/titlescreen" },
        template: { require: "text!components/titlescreen/titlescreen.html" }
    });
    ko.components.register("lightview", {
        viewModel: { require: "components/lightview/lightview" },
        template: { require: "text!components/lightview/lightview.html" }
    });

    ko.components.register("register", {
        viewModel: { require: "components/register/register" },
        template: { require: "text!components/register/register.html" }
    });

    ko.components.register("login", {
        viewModel: { require: "components/login/login" },
        template: { require: "text!components/login/login.html" }
    });

});





require(['knockout', 'viewModel'], (ko, vm) => {
    ko.applyBindings(vm);
});
