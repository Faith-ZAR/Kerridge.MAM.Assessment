using Kerridge.MAM.Data.Interfaces;
using Kerridge.MAM.Data.Models;
using Kerridge.MAM.Services.Repositories;
using Kerridge.MAM.Services.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


string dataFilePath = Path.Combine(builder.Environment.ContentRootPath, "TempDB", "MAM_AssessmentDB.json");

builder.Services.AddSingleton<IRepository<Product>>(x => new JsonDBRepository<Product>(dataFilePath, "ProductData"));
builder.Services.AddSingleton<IRepository<Tax>>(x => new JsonDBRepository<Tax>(dataFilePath, "TaxData"));

builder.Services.AddScoped<ITax, TaxService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<TaxService>();

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

app.MapControllers();

app.Run();
