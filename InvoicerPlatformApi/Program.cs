using InvoicerDataExtension.Data;
using Microsoft.EntityFrameworkCore;
using SecurityDriven.Core;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<CryptoRandom>();
// Add services to the container.

builder.Services.AddDbContext<InvoicerPlatformContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
        .EnableSensitiveDataLogging();
});

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

app.UseAuthorization();


app.Run();
