define(['knockout', 'dataservice'], (ko, ds) => {
    let selectedComponent = ko.observable('home');

    let changeContent = (component) => {
        selectedComponent(component);
    }
    return {
        changeContent,
        selectedComponent
    };
});