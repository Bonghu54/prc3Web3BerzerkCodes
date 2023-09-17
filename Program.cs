using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using prc3Web3BerzerkCodes.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<prc3Web3BerzerkCodesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("prc3Web3BerzerkCodesContext") ?? throw new InvalidOperationException("Connection string 'prc3Web3BerzerkCodesContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<prc3Web3BerzerkCodesContext>();
    context.Database.EnsureCreated();
    // DbInitializer.Initialize(context);
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
