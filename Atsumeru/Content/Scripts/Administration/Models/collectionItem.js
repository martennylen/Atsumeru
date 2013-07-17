var Atsumeru = Atsumeru || {};
Atsumeru.Models = Atsumeru.Models || {};

Atsumeru.Models.CollectionItem = function (model) {
    var self = this;

    self.id = ko.observable('');
    self.name = ko.observable('');
    self.alternativeName = ko.observable('');

    self.representation = ko.computed(function() {
        return {Id: self.id(), Name: self.name(), AlternativeName: self.alternativeName()};
    });

    self.emptyAll = function() {
        self.id('');
        self.name('');
        self.alternativeName('');
    };
};