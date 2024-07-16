using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Data.Services;
using WebApplication1.Exceptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer("Data Source=HADI;Initial Catalog=my-books;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"));
builder.Services.AddTransient<BooksService>();
builder.Services.AddTransient<PublishersService>();
builder.Services.AddTransient<AuthorsService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

AppDbInitializer.seed(app);

app.UseHttpsRedirection();

app.UseAuthorization();
app.ConfigureBuidInExceptionHandler();
//app.ConfigureCustomExceptionHandler();

app.MapControllers();

app.Run();
