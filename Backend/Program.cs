using Microsoft.EntityFrameworkCore;
using PharmacyAPI.Data;

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

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app= builder.Build();

// 使用 CORS
app.UseCors("AllowFrontend");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();