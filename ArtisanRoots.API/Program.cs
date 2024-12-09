using ArtisanRoots.API.Communication.Application.Internal.CommandServices;
using ArtisanRoots.API.Communication.Application.Internal.QueryServices;
using ArtisanRoots.API.Communication.Domain.Repositories;
using ArtisanRoots.API.Communication.Domain.Services.CommandServices;
using ArtisanRoots.API.Communication.Domain.Services.QueryServices;
using ArtisanRoots.API.Communication.Infrastructure.Persistence.EFC.Repositories;
using ArtisanRoots.API.Shared.Domain.Repositories;
using ArtisanRoots.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using ArtisanRoots.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ArtisanRoots.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

#region DATABASE_CONFIGURATION

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Database Context and Logging Levels

builder.Services.AddDbContext<ArtisanRootsContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseSqlServer(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseSqlServer(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();
    });

#endregion

// Configure Lowercase URLs

builder.Services.AddRouting(options => options.LowercaseUrls = true);

#region OPEN_API_CONFIGURATION

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "ACME.LearningCenterPlatform.API",
                Version = "v1",
                Description = "ACME Learning Center Platform API",
                TermsOfService = new Uri("https://acme-learning.com/tos"),
                Contact = new OpenApiContact
                {
                    Name = "ACME Studios",
                    Email = "contact@acme.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
        c.EnableAnnotations();
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer", Type = ReferenceType.SecurityScheme
                    }
                },
                Array.Empty<string>()
            }
        });
    });

#endregion

// Add CORS Policy

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

#region DEPENDENCY_INJECTION_CONFIGURATION

// SHARED BOUNDED CONTEXT

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// IAM BOUNDED CONTEXT


// COMMUNICATION BOUNDED CONTEXT

builder.Services.AddScoped<INotificationArtisanCommandService, NotificationArtisanCommandService>();

builder.Services.AddScoped<INotificationOwnerCommandService, NotificationOwnerCommandService>();

builder.Services.AddScoped<INotificationArtisanQueryService, NotificationArtisanQueryService>();

builder.Services.AddScoped<INotificationOwnerQueryService, NotificationOwnerQueryService>();

builder.Services.AddScoped<INotificationArtisanRepository, NotificationArtisanRepository>();

builder.Services.AddScoped<INotificationOwnerRepository, NotificationOwnerRepository>();

// COMMERCE BOUNDED CONTEXT

#endregion


var app = builder.Build();

#region SCOPE_DATABASE_CREATION

// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ArtisanRootsContext>();
    context.Database.EnsureCreated();
}

#endregion

app.UseSwagger();

app.UseSwaggerUI();

app.UseCors("AllowAllPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();