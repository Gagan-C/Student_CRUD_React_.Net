using Microsoft.EntityFrameworkCore;
using Student_API;
using Student_API.Repositories;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//adding controllers service
builder.Services.AddControllers();

//adding mysql database context
builder.Services.AddDbContext<StudentDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("student_db"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("student_db")))); 

//Dependency Injection
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
using (var serviceScope = app.Services.CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<StudentDbContext>();
    context.Database.Migrate();
}

// Use CORS policy
app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
