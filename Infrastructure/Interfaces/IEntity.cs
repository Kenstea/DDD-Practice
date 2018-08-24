using System;

namespace Infrastructure.Interfaces
{   
    public interface IEntity<TIdentifier>
    {
        TIdentifier Id { get; set; }

        DateTime CreatedAt { get; set; }

        DateTime ModifiedAt { get; set; }

        string CreatedBy { get; set; }

        string ModifiedBy { get; set; } 
    }
}
