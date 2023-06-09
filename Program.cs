using Microsoft.EntityFrameworkCore;
using scorpio.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ScorpioDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("scorpiodb")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
        {
            options.AddPolicy("CorsApi",
                builder => builder
                    .WithOrigins("*").AllowAnyMethod().AllowAnyHeader());
        });

builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsApi");


app.UseAuthorization();

app.MapControllers();

app.Run();
