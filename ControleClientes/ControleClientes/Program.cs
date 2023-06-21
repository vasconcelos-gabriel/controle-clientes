using ControleClientes.Data.Repositories;
using ControleClientes.Domain.Repositories;
using ControleClientes.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IClienteDomainService, ClienteDomainService>();
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();

builder.Services.AddCors(
 s => s.AddPolicy("DefaultPolicy", builder =>
 {
     builder.AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader();
 })
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("DefaultPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();