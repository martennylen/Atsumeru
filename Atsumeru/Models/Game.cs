using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Atsumeru.Models
{
    public class Game
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Platform { get; set; }
        public string Notes { get; set; }
    }
}