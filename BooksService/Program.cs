using BooksService.Database;
using BooksService.IRepository;
using BooksService.IService;
using BooksService.Repository;
using BooksService.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<BookDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped<IBookRepository, BookRepository>();

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//      var context= scope.ServiceProvider.GetRequiredService<BookDbContext>();
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
