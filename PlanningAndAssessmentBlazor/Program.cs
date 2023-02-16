using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using PlanningAndAssessmentLib.Data;
using PlanningAndAssessmentLib.DataAccess;
using PlanningAndAssessmentLib.Services;

var builder = WebApplication.CreateBuilder(args);

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(
    "Mgo+DSMBaFt/QHRqVVhkVVpFdEBBXHxAd1p/VWJYdVt5flBPcDwsT3RfQF5jS35bdkNiXn9WdnRTTg==;Mgo+DSMBPh8sVXJ0S0J+XE9Af1RDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS31TdEVrWXlfd3RdQGJbWQ==;ORg4AjUWIQA/Gnt2VVhkQlFaclZJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxQdkdjUX9YcXNVTmZYVEw=;MTA4Nzk1N0AzMjMwMmUzNDJlMzBkSFlSdVZqSUxIWVRuTFVMbUdqRFJ1MEs5VFNTL2pkRXBuUEd0ajlqaEtJPQ==;MTA4Nzk1OEAzMjMwMmUzNDJlMzBtZEk2MEZVTXl1dG9lTGlXaStaWUc0aFVqUHBkdmxvbS9tdlBNOVFac05rPQ==;NRAiBiAaIQQuGjN/V0Z+WE9EaFtLVmJLYVB3WmpQdldgdVRMZVVbQX9PIiBoS35RdUVhWXdednVSRmhbV0Z/;MTA4Nzk2MEAzMjMwMmUzNDJlMzBjR082cnpIREZWQi9UMEJqVkhRdjhETDFxcHZ4VUtZYm5TWE9EbmNkam4wPQ==;MTA4Nzk2MUAzMjMwMmUzNDJlMzBQTVBqaWxhSGt0dDYwNWtCb01iREJwVy91MGtpQVhXY2VaMWNudi8xalVJPQ==;Mgo+DSMBMAY9C3t2VVhkQlFaclZJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxQdkdjUX9YcXNVTmhZUE0=;MTA4Nzk2M0AzMjMwMmUzNDJlMzBmaktGblpiZjRRK2tmcVBFNWlmTU83SzdLbk1RLzZrM1g3VEs5RGlBcy9NPQ==;MTA4Nzk2NEAzMjMwMmUzNDJlMzBla2NRckcwQTcralc2a0ppdlZIUjJjYmZLK21KZU0wMjREYWd2dDFwbk9NPQ==;MTA4Nzk2NUAzMjMwMmUzNDJlMzBjR082cnpIREZWQi9UMEJqVkhRdjhETDFxcHZ4VUtZYm5TWE9EbmNkam4wPQ=="
);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<HttpClient>();
builder.Services.AddScoped<CurriculumService>();
builder.Services.AddScoped<IDataAccess, SqlDataAccess>();
builder.Services.AddScoped<CurriculumController>();

var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContextFactory<CurriculumContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
