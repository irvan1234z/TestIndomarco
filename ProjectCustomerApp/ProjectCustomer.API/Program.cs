using Microsoft.EntityFrameworkCore;
using ProjectCustomer.Application.Interfaces;
using ProjectCustomer.Application.Services;
using ProjectCustomer.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProjectCustomerDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<ICustomerService, CustomerService>();

var app = builder.Build();

app.UseRouting();
app.UseAuthorization();

//sebagai mapping controller
app.MapControllers();

//untuk melakukan pengetesan menggunakan swagger
app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();

