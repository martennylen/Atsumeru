using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Raven.Imports.Newtonsoft.Json;
using Raven.Imports.Newtonsoft.Json.Converters;

namespace Atsumeru.Models.Administration
{
    public class CollectionType
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CollectionIdentifier { get; set; }
        public List<CollectionTypeField> Fields { get; set; } 
    }

    public class CollectionTypeField
    {
        public string FieldName { get; set; }
        public CollectionTypeFieldControl FieldControl { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum CollectionTypeFieldControl
    {
        Input,
        Textarea,
        Select,
        Radio,
        Checkbox
    }
}