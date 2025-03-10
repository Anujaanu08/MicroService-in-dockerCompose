using Microsoft.EntityFrameworkCore;
using RentalsService.Database;
using RentalsService.IRepository;
using RentalsService.IService;
using RentalsService.Repository;
using RentalsService.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<RentalDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddScoped<IRentalService, RentalService>();

builder.Services.AddScoped<IRentalRepository, RentalRepository>();


var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetRequiredService<RentalDbContext>();
//    context.Database.Migrate();
//}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
