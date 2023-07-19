using Core.Security.EmailAuthenticator;
using Core.Security.JWT;
using Core.Security.Moldels;
using Core.Security.OtpAuthenticator;
using Core.Security.OtpAuthenticator.OtpNet;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class SecurityServiceRegistration

{
    public static IServiceCollection AddSecurityServices<TContext>(this IServiceCollection services)
        where TContext : DbContext
    {
        services.Configure<DataProtectionTokenProviderOptions>(opt =>
        {
            opt.TokenLifespan = TimeSpan.FromHours(2);
        });

        services.AddIdentity<AppUser, AppRole>(options =>
        {
            options.User.RequireUniqueEmail = true;
            options.User.AllowedUserNameCharacters = "abcdefghijklmnoprstuvwxyz0123456789-._";

            options.Password.RequiredLength = 6;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = false;
            options.Password.RequireDigit = false;
            options.Password.RequiredUniqueChars = 1;

            // Default Lockout settings.
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
            options.Lockout.MaxFailedAccessAttempts = 3;
            options.Lockout.AllowedForNewUsers = true;
        })
            //.AddPasswordValidator<PasswordValidator>()
            //.AddUserValidator<UserValidator>()
            //.AddErrorDescriber<LocalizationIdentityErrorDescriber>()
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<TContext>();

        services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = new PathString("/Account/Login");
            options.LogoutPath = new PathString("/Account/Logout");
            options.AccessDeniedPath = new PathString("/Account/AccessDenied");
            options.Cookie.Name = "AppCookie";
            options.Cookie.HttpOnly = false; //Kötü niyetli insanların client-side tarafından Cookie'ye erişmesini engelliyoruz.
            options.Cookie.SameSite = SameSiteMode.Lax; //Top level navigasyonlara sebep olmayan requestlere Cookie'nin gönderilmemesini belirtiyoruz.
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always; //HTTPS üzerinden erişilebilir yapıyoruz.
            options.ExpireTimeSpan = TimeSpan.FromDays(60); //Oluşturulacak Cookie'nin vadesini belirliyoruz.

            // ReturnUrlParameter requires
            // using Microsoft.AspNetCore.Authentication.Cookies;
            options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;

            options.SlidingExpiration = true;
        });

        services.AddScoped<ITokenHelper, JwtHelper>();
        services.AddScoped<IEmailAuthenticatorHelper, EmailAuthenticatorHelper>();
        services.AddScoped<IOtpAuthenticatorHelper, OtpNetOtpAuthenticatorHelper>();
        return services;
    }
}