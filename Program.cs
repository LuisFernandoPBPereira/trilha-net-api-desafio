using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.UseCases.Tarefas;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OrganizadorContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddScoped<AtualizarTarefaUseCase>();
builder.Services.AddScoped<CriarTarefaUseCase>();
builder.Services.AddScoped<DeletarTarefaUseCase>();
builder.Services.AddScoped<ObterTarefaPorDataUseCase>();
builder.Services.AddScoped<ObterTarefaPorIdUseCase>();
builder.Services.AddScoped<ObterTarefaPorStatusUseCase>();
builder.Services.AddScoped<ObterTarefaPorTituloUseCase>();
builder.Services.AddScoped<ObterTarefasUseCase>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
