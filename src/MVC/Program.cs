using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
//using AccountingSubsystemIdentity.Areas.Identity.Data;
using AccountingSubsystem.Infra.Data.Sql;
using AccountingSubsystem.Domain.AggregatesModel.Identity;
using AccountingSubsystem.Domain.AggregatesModel.Company;
using AccountingSubsystem.Infra.Data.Sql.Repositories;
using AccountingSubsystem.Domain.AggregatesModel.InvoiceDetail;
using AccountingSubsystem.Domain.AggregatesModel.InvoiceHeaders;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDBContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDBContextConnection' not found.");

builder.Services.AddDbContext<AccountingSubsystemContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<AccountingSubsystemContext>();

builder.Services.AddSingleton<IInvoiceHeaderRepository, InvoiceHeaderRepository>(con => new InvoiceHeaderRepository(ContextFactory.GetSqlContext()));
builder.Services.AddSingleton<IInvoiceDetailRepository, InvoiceDetailRepository>(con => new InvoiceDetailRepository(ContextFactory.GetSqlContext()));
builder.Services.AddSingleton<ICompanyRepository, CompanyRepository>(con => new CompanyRepository(ContextFactory.GetSqlContext()));

builder.Services.ConfigureApplicationCookie(options => 
{
    options.Cookie.SameSite = SameSiteMode.None;
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.Configure<IdentityOptions>(options =>
{
    //  Password settings.
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseDeveloperExceptionPage();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
