using Microsoft.EntityFrameworkCore;
using WebApiFroms.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Cors

builder.Services.AddCors(options =>
options.AddPolicy("Coustom", x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

#endregion

#region Sql Connection

var Connectionstring = builder.Configuration.GetConnectionString("ApiConnection");

builder.Services.AddDbContext<FormsDbContext>(options => options.UseSqlServer(Connectionstring));

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Coustom");
app.UseAuthorization();

app.MapControllers();

app.Run();
