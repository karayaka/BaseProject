using BaseProject.Infrastructure;
using BaseProject.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//data context add
var cnnc = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddNoteDbContext(cnnc);
//repositorys add
builder.Services.AddRepositorys();
//services mappr add container
builder.Services.AddMapper();
//addServices
builder.Services.AddServices();

builder.Services.AddSession(opt =>
{
    opt.IdleTimeout= TimeSpan.FromMinutes(90);
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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
