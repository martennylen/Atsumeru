var Atsumeru = Atsumeru || {};
Atsumeru.ViewModels = Atsumeru.ViewModels || {};

Atsumeru.ViewModels.Administrator = function (model) {
    var self = this;

    self.collectionTypes = ko.observableArray(model.CollectionTypes);
    self.collectionTypeItem = ko.observable();
    
    self.collectionItems = ko.observableArray(model.CollectionItems);
    self.collectionItem = new Atsumeru.Models.CollectionItem(model);

    self.cancelOperation = function() {
        self.loadCollection({});
    };
    
    self.loadCollection = function (collectionType) {
        collectionType.isNew = _.isEmpty(collectionType);

        self.collectionTypeItem(new Atsumeru.Models.CollectionType(collectionType));
    };
    
    self.createCollectionType = function () {
        var operationType = self.collectionTypeItem().isNew() ? 'POST' : 'PUT';
        $.ajax({
            url: 'http://localhost:8099/api/CollectionType?id=' + self.collectionTypeItem().id,
            type: operationType,
            data: JSON.stringify(self.collectionTypeItem().representation()),
            contentType: 'application/json; charset=utf-8',
            success: function() {
                self.collectionTypeItem().emptyAll();
                self.updateCollectionTypes();
            }
        });
    };
    
    self.updateCollectionTypes = function () {
        $.get('http://localhost:8099/api/CollectionType', function (reply) {
            console.log(reply);
            self.collectionTypes(reply);
        });
    };
    
    self.createCollectionItem = function() {
        $.ajax({
            url: 'http://localhost:8099/api/CollectionItem',
            type: 'POST',
            data: JSON.stringify(self.collectionItem.representation()),
            contentType: 'application/json; charset=utf-8',
            success: function () {
                self.collectionItem.emptyAll();
                self.fetchAll();
            }
        });
    };

    self.fetchAll = function() {
        $.get('http://localhost:8099/api/CollectionItem', function (reply) {
            self.collectionItems(reply);
        });
    };

    self.loadCollection({});
};