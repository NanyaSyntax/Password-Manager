using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NanyaPasswordManager.Core.Services.Implementations;
using NanyaPasswordManager.Core.Services.Interfaces;
using NanyaPasswordManager.Data;
using NanyaPasswordManager.Data.Repositories.Implementations;
using NanyaPasswordManager.Data.Repositories.Interfaces;
using NanyaPasswordManager.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<NanyaPwdMngrDbContext>(options =>
      options.UseSqlServer(builder.Configuration.GetConnectionString("PasswordManagerCS")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<NanyaPwdMngrDbContext>()
                .AddDefaultTokenProviders();
builder.Services.AddScoped<IPasswordManagerService, PasswordManagerService>();
builder.Services.AddScoped<IPasswordManagerRepository, PasswordManagerRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
