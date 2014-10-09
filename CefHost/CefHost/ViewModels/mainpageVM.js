function MainPageVM() {
    var self = this;

    self.AlertModelNameClicked = function () {
        console.log("model.title " + model.title);
        alert(model.title);
    };
}

ko.applyBindings(new MainPageVM());