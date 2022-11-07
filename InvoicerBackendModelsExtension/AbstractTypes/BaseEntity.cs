using SecurityDriven.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicerBackendModelsExtension.AbstractTypes;

public abstract class BaseEntity //: IBaseEntity
{
    protected BaseEntity(CryptoRandom random)
    {
        _random = random;
        GenerateId();
        CreatedAt = DateTimeOffset.UtcNow;
        UpdatedAt = DateTimeOffset.UtcNow;
    }

    private readonly CryptoRandom _random;
    protected BaseEntity()
    {
        GenerateId();
        CreatedAt = DateTimeOffset.UtcNow;
        UpdatedAt = DateTimeOffset.UtcNow;
    }

    public Guid Id { get; private set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public void GenerateId()
    {
        if (Id == Guid.Empty)
        {
            Id = _random.NextGuid();
        }
    }
}
