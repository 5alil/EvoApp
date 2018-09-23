using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvoApp.UI.Services.Dto
{
    public class EvoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
