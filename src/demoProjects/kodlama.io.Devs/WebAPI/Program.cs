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
builder.Services.AddDistributedMemoryCache();

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

               //JWT token'lar�nda genellikle iki s�re bulunur: "iat" (Issue At) ve "exp" (Expiration Time).
               //"iat" s�resi, token'�n ne zaman olu�turuldu�unu belirtirken, "exp" s�resi ise token'�n ne zaman ge�ersizle�ece�ini g�sterir.

               //ClockSkew parametresi bu s�reler aras�ndaki tolerans� belirler.�rne�in, ClockSkew de�eri 5 dakika olarak ayarlanm��sa,
               //token'�n ge�erlilik s�resiyle ilgili kontroller yap�l�rken, token'�n s�resi 5 dakika �ncesine veya sonras�na kadar kabul edilir.

               #endregion ClockSkew
           };
       });

builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Kodlama.io.Devs", Version = "v1" });

    opt.AddSecurityDefinition(name: "Bearer", securityScheme: new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description =
            "JWT Authorization header Bearer �emas� kullan�lmaktad�r. Yukar�daki input alan�na 'Bearer JWT_TOKEN' format�nda giri� yap�n�z."
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
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(opt => { opt.DisplayRequestDuration(); opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Kodlama.io.Devs"); });
}

if (app.Environment.IsProduction())
    app.ConfigureCustomExceptionMiddleware();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();