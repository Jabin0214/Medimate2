using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using PharmacyAPI.Data;
using Drugsearch.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Drugsearch.Services;
using Drugsearch.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// 配置 CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // 允许的前端地址
              .AllowAnyHeader() // 允许任何请求头
              .AllowAnyMethod() // 允许任何请求方法
              .AllowCredentials(); // 如果需要 Cookie 或认证
    });
});

// 注册数据库上下文
builder.Services.AddDbContext<PharmacyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 配置 Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    // 密码设置
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;

    // 锁定设置
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // 用户设置
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<PharmacyContext>()
.AddDefaultTokenProviders();

// 配置 JWT 认证
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? throw new InvalidOperationException("JWT:Key is not configured")))
    };
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITokenService, TokenService>();

var app = builder.Build();

// 使用 CORS
app.UseCors("AllowFrontend");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 添加认证中间件
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();