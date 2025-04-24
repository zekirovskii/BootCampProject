using BootCampProject.Repositories.EF;
using BootCampProject.Repositories.Interfaces;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Veritabanı bağlantı dizesi
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Katman bağımlılıkları (Repository ve Service bağlama)
builder.Services.AddScoped<IInstructorRepository, EfInstructorRepository>();
builder.Services.AddScoped<IApplicantRepository, EfApplicantRepository>();
builder.Services.AddScoped<IEmployeeRepository, EfEmployeeRepository>();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthorization();
app.MapControllers();
app.Run();