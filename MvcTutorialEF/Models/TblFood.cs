using System;
using System.Collections.Generic;

namespace MvcTutorialEF.Models
{
    public partial class TblFood
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Style { get; set; } = null!;
        public int Stars { get; set; }
        public int Price { get; set; }
        public string? Comment { get; set; }
    }
}
