require.config({
    baseUrl: "js",
    paths: {
        knockout: "lib/knockout/knockout-latest",
        text: "lib/require-text/text.min",
        dataservice: "services/dataService",
        viewModel: ""
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
});

require(['knockout', 'text'], (ko) => {
    ko.components.register("titlescreen", {
        viewModel: { require: "components/titlescreen/titlescreen" },
        template: { require: "text!components/titlescreen/titlescreen.html" }
    });
});



require(['knockout', 'viewModel'], (ko, vm) => {
    ko.applyBindings(vm);
});
