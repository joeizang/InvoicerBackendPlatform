using InvoicerDataExtension.Abstractions;
using InvoicerDataExtension.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicerDomainBusinessLogic
{
    public static class Bootstrapper
    {
        public static void BootstrapBusinessLogic(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}
