using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Handlers;
using ToDo.Domain.Repositories;
using ToDo.Infra.Contexts;
using ToDo.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseInMemoryDatabase("Database");
});

builder.Services.AddTransient<ToDoHandler, ToDoHandler>();
builder.Services.AddTransient<IToDoRepository, ToDoRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors(x =>
            x.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
