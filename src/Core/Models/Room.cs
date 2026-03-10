using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models;

public class Room : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public bool IsActive { get; set; }

}
