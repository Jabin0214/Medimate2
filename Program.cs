using Microsoft.EntityFrameworkCore;
using PharmacyAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// 注册数据库上下文
builder.Services.AddDbContext<PharmacyContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app= builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();