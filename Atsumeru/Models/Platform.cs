using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Atsumeru.Models
{
    public class Platform
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Game> Games { get; set; }
        public string Notes { get; set; }
    }
}