using InvoicerDataExtension.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace InvoicerDataExtension;

public static class DbBootstrapper
{
    public static void BootstrapDataExtension(this IServiceCollection services, WebApplicationBuilder builder, string sectionName)
    {
        services.AddDbContext<InvoicerPlatformContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString(sectionName));
            //.EnableSensitiveDataLogging();
        });
    }
}