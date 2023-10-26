//using AccountingSubsystem.BasicAthentication.Athentication.Basic;
//using AccountingSubsystem.BasicAthentication.Athentication.Basic.Handlers;
using AccountingSubsystem.Domain.AggregatesModel.Company;
using AccountingSubsystem.Domain.AggregatesModel.Invoice.InvoiceEntity;
using AccountingSubsystem.Infra.Data.Sql;
using AccountingSubsystem.Infra.Data.Sql.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<ICompanyRepository, CompanyRepository>();

builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>(con => new InvoiceRepository(ContextFactory.GetSqlContext()));
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>(con => new CompanyRepository(ContextFactory.GetSqlContext()));
//builder.Services.AddAuthentication()
//    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>(BasicAuthenticationDefaults.AuthenticationScheme, null);


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
