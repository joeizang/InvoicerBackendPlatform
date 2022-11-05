using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicerBackendModelsExtension.AbstractTypes;

public interface IBaseEntity
{
    Guid Id { get; }

    DateTimeOffset CreatedAt { get; set; }

    DateTimeOffset UpdatedAt { get; set; }

    bool IsDeleted { get; set; }
}
