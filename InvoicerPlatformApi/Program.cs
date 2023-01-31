using FluentValidation;
using FluentValidation.AspNetCore;
using InvoicerBackendModelsExtension.DTOs;
using InvoicerDataExtension.Data;
using InvoicerDomainBusinessLogic;
using InvoicerPlatformApi.Validators.InvoiceItemValidators;
using InvoicerPlatformApi.Validators.InvoiceValidators;
using Microsoft.EntityFrameworkCore;
using SecurityDriven.Core;
using System.Reflection;
using InvoicerDataExtension;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<CryptoRandom>();
// Add services to the container.

builder.Services.BootstrapDataExtension(builder, "Postgres");
builder.Services.AddScoped<IValidator<CreateInvoiceDto>, CreateInvoiceDtoValidator>();
builder.Services.AddScoped<IValidator<UpdateInvoiceDto>, UpdateInvoiceDtoValidator>();
builder.Services.AddScoped<IValidator<CreateInvoiceItemDto>, CreateInvoiceItemDtoValidator>();
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
