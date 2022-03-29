using Microsoft.EntityFrameworkCore;
using ChallengeAlternativo.Models;
using ChallengeAlternativo.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEntityFrameworkSqlServer();
//builder.Services.AddDbContext<IconsContext>(optionsAction:(services IServiceProvider,options)=>
//{
//   options.UseInternalServiceProvider(services);
//  options.UseSqlServer();

//});


builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<UserContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(configureOptions:options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;


})
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = "https://localhost:5001",
            ValidIssuer = "https://localhost:5001",
            IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(s:"KeySecretaSuperLargaDeAUTORIZACION"))


        };
    
    });

builder.Services.AddDbContext<IconsContext>((services, options) =>
{
    options.UseInternalServiceProvider(services);
    options.UseSqlServer(builder.Configuration.GetConnectionString(name: "AlkemyConnectionString"));

});


builder.Services.AddDbContext<UserContext>((services, options) =>
{
    options.UseInternalServiceProvider(services);
    options.UseSqlServer(builder.Configuration.GetConnectionString(name: "UserConnectionString"));

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
