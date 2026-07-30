using FlightPal.Controllers;
using FlightPal.Models;
using FlightPal.Services;
using FlightPal.Data;
using FlightPal.Shared.Layout;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Blazor_ApexCharts;

using ApexCharts;


namespace FlightPal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddControllers();
            builder.Configuration.AddEnvironmentVariables();
           

            var apiSettings = new ApiSettings
            {
                CedulaApi = new CedulaApiSettings
                {
                    BaseUrl = builder.Configuration["CEDULA_API_BASEURL"],
                    AppId = builder.Configuration["CEDULA_API_APPID"],
                    Token = builder.Configuration["CEDULA_API_TOKEN"]
                }
            };
            

            var dBOptions = new DBOptions
            {
                ConnectionString = builder.Configuration.GetConnectionString("FlightPalDBContext"),
            };
          
            var welcomeService = new WelcomeService();

            builder.Services.AddSingleton(apiSettings);
            builder.Services.AddSingleton(dBOptions);
            builder.Services.AddSingleton(welcomeService);
            builder.Services.AddApexCharts();


            builder.Services.AddHttpContextAccessor();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.Cookie.Name = "UserSession";
                options.LoginPath = "/login";
                options.LogoutPath = "/logout";
                options.Cookie.MaxAge = TimeSpan.FromHours(1);
                options.AccessDeniedPath = "/AccessDenied";


            });


            builder.Services.AddAuthorization();
            builder.Services.AddCascadingAuthenticationState();

            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

            builder.Services.AddScoped<AuthService>();
            builder.Services.AddHttpContextAccessor();




            builder.Services.AddHttpClient<ICedulaService, CedulaService>();
            builder.Services.AddHttpClient<IDolarService, DolarService>();
            builder.Services.AddScoped<IDatabaseConnection, DatabaseConnection>();

            builder.Services.AddHttpClient();

      
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
            app.UseHttpsRedirection();
           
            app.UseAntiforgery();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllers();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();
            

    
      

            app.Run();
        }
    }
}
