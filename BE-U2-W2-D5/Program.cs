using BE_U2_W2_D5.Models.Entities;
using BE_U2_W2_D5.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


string connectionString = string.Empty;
try
{
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
        throw new Exception("Stringa di connessione non trovata");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    Environment.Exit(1);
}

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(connectionString)
    );

builder.Services.AddScoped<IClienteServices, ClienteServices>();
builder.Services.AddScoped<ICameraServices, CameraServices>();
builder.Services.AddScoped<IPrenotazioneServices, PrenotazioneServices>();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddIdentity<IdentityUser, IdentityRole>(option =>
{
    option.SignIn.RequireConfirmedPhoneNumber = false; 
    option.SignIn.RequireConfirmedEmail = false; 
    option.SignIn.RequireConfirmedAccount = false; 
    option.Password.RequiredLength = 10;
    option.Password.RequireDigit = false; 
    option.Password.RequireLowercase = true; 
    option.Password.RequireUppercase = true; 
    option.Password.RequireNonAlphanumeric = false; 
                                                  
}
  ).AddEntityFrameworkStores<ApplicationDbContext>().
  AddDefaultTokenProviders(); 

builder.Services.AddScoped<UserManager<IdentityUser>>(); 
builder.Services.AddScoped<SignInManager<IdentityUser>>(); 
builder.Services.AddScoped<RoleManager<IdentityRole>>(); 

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
