var Atsumeru = Atsumeru || {};
Atsumeru.ViewModels = Atsumeru.ViewModels || {};
Atsumeru.Models = Atsumeru.Models || {};

Atsumeru.ViewModels.Page = function () {
    var self = this;

    self.administrator = new Atsumeru.ViewModels.Administrator(Atsumeru.Models.administrationModel);
};

ko.applyBindings(new Atsumeru.ViewModels.Page());