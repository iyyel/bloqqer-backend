using Bloqqer.Infrastructure.Database;
using Bloqqer.Infrastructure.Models;
using Bloqqer.Infrastructure.Repositories;
using Bloqqer.Infrastructure.Repositories.Interfaces;
using Bloqqer.Infrastructure.UnitOfWork;
using Bloqqer.Infrastructure.UnitOfWork.Interfaces;
using Bloqqer.WebAPI.Services;
using Bloqqer.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options => options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
{
    Title = "Bloqqer API Docs",
    Description = "Documentation of the Bloqqer API",
}));

// Auth
builder.Services
    .AddAuthentication(IdentityConstants.ApplicationScheme);
// .AddIdentityCookies();

builder.Services.AddHttpContextAccessor();

// builder.Services.AddAuthorizationBuilder();

// Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration
    .GetConnectionString("LocalConnection"), b =>
    {
        b.MigrationsAssembly("Bloqqer.WebAPI");
        b.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
    }));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
builder.Services.AddScoped<IBloqRepository, BloqRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IReactionRepository, ReactionRepository>();
builder.Services.AddScoped<IFollowRepository, FollowRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBloqService, BloqService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IReactionService, ReactionService>();
builder.Services.AddScoped<IFollowService, FollowService>();

// Identity stuff
builder.Services
    .AddIdentityCore<ApplicationUser>()
    .AddRoles<ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddApiEndpoints();

var app = builder.Build();

// moved outside ...IsDevelopment() as Azure requires the open API definition
app.UseSwagger();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Bloqqer API");
        options.DocumentTitle = "Bloqqer API Docs";
        options.RoutePrefix = "api/docs";
    });
}

app.UseHttpsRedirection();

// app.UseAuthorization();

app.MapControllers();

app.Run();