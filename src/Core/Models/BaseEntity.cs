using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models;

public interface IEntity { }

public abstract class BaseEntity : IEntity
{
    public DateTime CreatedAt { get; set; }
    public DateTime LastUpdated { get; set; }
}
