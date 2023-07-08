using Application;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Encryption;
using Core.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Persistence;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationServices();
builder.Services.AddSecurityServices();
builder.Services.AddPersistenceServices(builder.Configuration);

TokenOptions? tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}) // Authentication: "Bearer JWT_TOKEN"
       .AddJwtBearer(opt =>
       {
           opt.TokenValidationParameters = new TokenValidationParameters
           {
               ValidateIssuer = true,
               ValidIssuer = tokenOptions?.Issuer,
               ValidateAudience = true,
               ValidAudience = tokenOptions?.Audience,
               ValidateLifetime = true,
               ValidateIssuerSigningKey = true,
               IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions?.SecurityKey!),
               ClockSkew = TimeSpan.Zero

               #region ClockSkew

               //JWT token'larýnda genellikle iki süre bulunur: "iat" (Issue At) ve "exp" (Expiration Time).
               //"iat" süresi, token'ýn ne zaman oluþturulduðunu belirtirken, "exp" süresi ise token'ýn ne zaman geçersizleþeceðini gösterir.

               //ClockSkew parametresi bu süreler arasýndaki toleransý belirler.Örneðin, ClockSkew deðeri 5 dakika olarak ayarlanmýþsa,
               //token'ýn geçerlilik süresiyle ilgili kontroller yapýlýrken, token'ýn süresi 5 dakika öncesine veya sonrasýna kadar kabul edilir.

               #endregion ClockSkew
           };
       });

builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition(name: "Bearer", securityScheme: new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description =
            "JWT Authorization header Bearer þemasý kullanýlmaktadýr. Yukarýdaki input alanýna 'Bearer JWT_TOKEN' formatýnda giriþ yapýnýz."
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
    app.ConfigureCustomExceptionMiddleware();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();