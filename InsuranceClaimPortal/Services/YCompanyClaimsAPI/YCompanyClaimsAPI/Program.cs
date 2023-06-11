using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
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
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://localhost:7001/"; // Identity server URL
        options.TokenValidationParameters = new TokenValidationParameters
        {
            /*
            Audience validation is disabled here because access to the api is modeled with ApiScopes only. By default, no audience will be emitted unless the api is modeled with ApiResources instead. See here for a more in-depth discussion.
            https://docs.duendesoftware.com/identityserver/v6/apis/aspnetcore/jwt/#adding-audience-validation
            */
            ValidateAudience = false
        };
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
        policy.RequireClaim("scope", "ClaimsAPI");
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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

