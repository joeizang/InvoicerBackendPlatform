using InvoicerBackendModelsExtension.DomainModels;
using InvoicerDataExtension.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicerDataExtension.Specifications
{
    public class CustomerByIdSpecification : Specification<PlatformCustomer>
    {
        public CustomerByIdSpecification(Guid customerId)
            : base(x => x.Id.Equals(customerId))
        {

        }
    }
}
