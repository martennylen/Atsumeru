using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Atsumeru.Models.Administration
{
    public class AdministrationModel
    {
        public List<CollectionType> CollectionTypes { get; set; }
        public List<Figures.Beast> CollectionItems { get; set; } 
    }
}