using Microsoft.EntityFrameworkCore;
using wandermate.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
    builder => builder.WithOrigins("http://localhost:5173")
    .AllowAnyMethod()
    .AllowAnyHeader()
    );
});
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("AllowAll",
//     builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
//     );
// });

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
    );


var app = builder.Build();



/* builder.Services.AddSwaggerGen(option =>
{

}); */

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.MapControllers();
app.Run();