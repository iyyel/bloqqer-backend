using FlashCards.DataAccess.Contexts;
using FlashCards.DataAccess.Entities;
using FlashCards.DataAccess.Repositories;
using FlashCards.DataAccess.Repositories.Interfaces;
using FlashCards.DataAccess.Repositories.UnitOfWork;
using FlashCards.DataAccess.Services;
using FlashCards.DataAccess.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options => options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
{
    Title = "FlashCards API Docs",
    Description = "Documentation of the FlashCards API",
}));

// Auth
builder.Services
    .AddAuthentication(IdentityConstants.ApplicationScheme)
    .AddIdentityCookies();

builder.Services.AddAuthorizationBuilder();

// Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration
    .GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("FlashCards.WebAPI"))
    );

builder.Services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
builder.Services.AddScoped<IFlashCardRepository, FlashCardRepository>();
builder.Services.AddScoped<IFlashCardSetRepository, FlashCardSetRepository>();

// Identity stuff
builder.Services
    .AddIdentityCore<ApplicationUser>()
    .AddRoles<ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddApiEndpoints();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

app.MapGroup("/api")
   .MapIdentityApi<ApplicationUser>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger()
       .UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "FlashCards API");
        options.DocumentTitle = "FlashCards API Docs";
        options.RoutePrefix = "api/docs";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();