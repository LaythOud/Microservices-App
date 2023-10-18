using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudentAdmissionManagement.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<StudentAdmissionDetailsModelContext>(options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("StudentAdmissionDetailsModelContext") ?? throw new InvalidOperationException("Connection string 'StudentAdmissionDetailsModelContext' not found."),
            options => options.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: System.TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null
            )
        )
    );

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<StudentAdmissionDetailsModelContext>();
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
