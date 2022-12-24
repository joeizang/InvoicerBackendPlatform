using FluentValidation;
using FluentValidation.AspNetCore;
using InvoicerBackendModelsExtension.DTOs;
using InvoicerDataExtension.Data;
using InvoicerDomainBusinessLogic;
using InvoicerPlatformApi.Validators.InvoiceValidators;
using Microsoft.EntityFrameworkCore;
using SecurityDriven.Core;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<CryptoRandom>();
// Add services to the container.

builder.Services.AddDbContext<InvoicerPlatformContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"));
        //.EnableSensitiveDataLogging();
});
builder.Services.AddScoped<IValidator<CreateInvoiceDto>, CreateInvoiceDtoValidator>();
builder.Services.BootstrapBusinessLogic();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();


app.Run();
