using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class ClassType : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Style { get; set; } = string.Empty;
        public int Level { get; set; }
        public bool IsActive { get; set; }
    }
}
