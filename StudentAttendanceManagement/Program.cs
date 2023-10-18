using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudentAttendanceManagement.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<StudentAttendanceDetailsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StudentAttendanceDetailsContext") ?? throw new InvalidOperationException("Connection string 'StudentAttendanceDetailsContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<StudentAttendanceDetailsContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
