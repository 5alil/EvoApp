using System;
using System.Collections.Generic;
using System.Text;

namespace EvoApp.Domain
{
    public class Evo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
