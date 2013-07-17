var Atsumeru = Atsumeru || {};
Atsumeru.Models = Atsumeru.Models || {};

Atsumeru.Models.CollectionTypeField = function(id, model) {
    var self = this;

    self.FieldName = ko.observable(model.FieldName || '');
    self.FieldControl = ko.observable(model.FieldControl || '');
    self.FieldValue = ko.observable();
    self.id = id;

    self.FieldControl.subscribe(function(newValue) {
        console.log(newValue);
    });
}