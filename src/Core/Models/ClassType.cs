using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class ClassType : BaseEntity
    {
        public static class MaxLength
        {
            public const int Name = 100;
            public const int Description = 500;
            public const int Style = 20;
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Style { get; set; } = string.Empty;
        public int Level { get; set; }
        public bool IsActive { get; set; }
    }
}
