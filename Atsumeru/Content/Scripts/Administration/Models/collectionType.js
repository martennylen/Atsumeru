var Atsumeru = Atsumeru || {};
Atsumeru.Models = Atsumeru.Models || {};

Atsumeru.Models.CollectionType = function (model) {
    var self = this;

    self.id = model.Id || null;
    self.collectionIdentifier = ko.observable(model.CollectionIdentifier || '');
    self.name = ko.observable(model.Name || '');
    self.fields = ko.observableArray([]);
    self.isNew = ko.observable(model.isNew);

    if (model) {
        _.each(model.Fields, function (field) {
            self.fields.push(new Atsumeru.Models.CollectionTypeField(self.fields().length, field));
        });
    }

    self.fieldControls = ko.observableArray([
        { controlName: 'Text input', controlValue: 'Input' },
        { controlName: 'Textarea', controlValue: 'Textarea' },
        { controlName: 'Dropdown', controlValue: 'Select' },
        { controlName: 'Radiobuttons', controlValue: 'Radio' },
        { controlName: 'Checkboxes', controlValue: 'Checkbox' }]);
    
    //self.fieldControls = ['Input', 'Textarea', 'Select', 'Radio', 'Checkbox'];

    self.flattenFields = function () {
        var flattened = [];
        _.each(self.fields(), function(field) {
            flattened.push({ FieldName: field.FieldName(), FieldControl: field.FieldControl() });
        });

        return flattened;
    };

    self.addField = function () {
        self.fields.push(new Atsumeru.Models.CollectionTypeField(self.fields().length, {}));
    };
    
    self.removeField = function (collectionTypeField) {
        self.fields.remove(collectionTypeField);

        _.each(self.fields(), function(item, index) {
            item.id = index;
        });
    };

    self.emptyAll = function () {
        self.collectionIdentifier('');
        self.name('');
        self.fields([]);
    };

    self.buttonText = ko.computed(function() {
        return self.isNew() ? 'Create' : 'Update';
    });
    
    self.representation = ko.computed(function () {
        return { Id: self.id, CollectionIdentifier: self.collectionIdentifier(), Name: self.name(), Fields: self.flattenFields() };
    });
};