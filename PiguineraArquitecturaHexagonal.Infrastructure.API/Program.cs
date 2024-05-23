using PiguineraArquitecturaHexagonal.Infrastructure.Persistence;
using PiguineraArquitecturaHexagonal.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
      builder =>
      {
          builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
      });
});


builder.Services.
     AddApplication()
    .AddPersistence(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
app.UseCors();

app.Run();
