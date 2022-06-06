using System;
using System.Collections.Generic;

namespace MvcTutorialEF.Models
{
    public class DemoListItem
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public partial class TblHero
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Atk { get; set; }
        public int Hp { get; set; }
    }
}
