using homework26_12.Entity;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddAntiforgery();
builder.Services.AddDbContext<ProductDbContext>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("Main")
));

WebApplication app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAntiforgery();

app.MapRazorPages();

app.Run();
