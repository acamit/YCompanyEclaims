using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using YCompany.Claims.DataAccess;
using YCompany.Claims.Domain.InfrastructureInterfaces;
using YCompany.Claims.ExceptionHandling;
using YCompany.Claims.Logging;
using YCompany.Claims.MessagingQueue;
using YCompany.HealthChecks;
using YCompanyClaimsAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();

    logging.AddYCompanyLogger();

    logging.AddColorConsoleLogger(configuration =>
    {
        // Replace warning value from appsettings.json of "Cyan"
        configuration.LogLevelToColorMap[LogLevel.Warning] = ConsoleColor.DarkCyan;
        // Replace warning value from appsettings.json of "Red"
        configuration.LogLevelToColorMap[LogLevel.Error] = ConsoleColor.DarkRed;
    });
});

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
   .AddJwtBearer(jwtbearerOptions =>
   {
       jwtbearerOptions.Authority = builder.Configuration["Authentication:Authority"];
       jwtbearerOptions.Audience = builder.Configuration["Authentication:Audience"];
       jwtbearerOptions.TokenValidationParameters.ValidateAudience = true;
       jwtbearerOptions.TokenValidationParameters.ValidateIssuer = true;
       jwtbearerOptions.TokenValidationParameters.ValidateIssuerSigningKey = true;
   }
);


/**
 * without this, api will accept any token provided by the authentication server.
 * add an Authorization Policy to the API that will check for the presence of the “ClaimsAPI” scope in the access token. 
 * 
 */

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "https://ycompany.com/claims");
    });
});

builder.Services.AddControllers();
builder.Services.AddCors(corsOptions =>
{
    corsOptions.AddDefaultPolicy(corsPolicyBuilder =>
    {
        corsPolicyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    swaggerGenOptions =>
    {
        swaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Claims API",
            Version = "v1"
        });
        swaggerGenOptions.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.OAuth2,
            Flows = new OpenApiOAuthFlows
            {
                ClientCredentials = new OpenApiOAuthFlow
                {
                    TokenUrl = new Uri($"{builder.Configuration["Authentication:Authority"]}/connect/token"),
                    Scopes = { { "https://ycompany.com/claims", "Claims API" } }
                }
            }
        });

        swaggerGenOptions.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "oauth2"
                    }
                },
                new List<string>
                {
                    "https://ycompany.com/claims"
                }
             }
        });
    });

builder.Services.AddTransient<IMessageBroker, SQSService>();
builder.Services.AddTransient<IClaimsStorageService, SqlStorageService>();
builder.Services.AddHealthChecks().AddCheck<StorageHealthChecks>("Storage");
builder.Services.AddHealthChecks().AddCheck<QueueHealthChecks>("Queue");

var app = builder.Build();
/*
 *  we can log here using
 *  app.Logger.LogInformation("");
*/
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
/*
 * Configure custom middleware
 */
app.UseYCompanyExceptionHandlingMiddleware();

app.UseHttpsRedirection();
app.UseHealthChecks("/health");
app.UseAuthentication();

app.UseAuthorization();


//  app.MapControllers();

/*
 *  link auth policy to controllers
 *
 */
app.MapControllers()
    .RequireAuthorization("ApiScope");


app.Run();

