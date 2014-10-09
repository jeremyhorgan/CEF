function MainPageVM() {
    var self = this;

    self.AlertOsVersionInfoClicked = function () {
        alert(AppServices.getHostOsVersion());
    };

    self.DisplayCallStack = function () {
        AppServices.displayCallStack();
    };

    self.BreakIntoVsDebugger = function () {
        AppServices.breakIntoDebugger();
    };
}

ko.applyBindings(new MainPageVM());