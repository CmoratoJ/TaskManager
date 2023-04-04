using Microsoft.EntityFrameworkCore;
using TaskManager.Data.DataContext;
using TaskManager.Repositories.StatusRepository.Interface;
using TaskManager.Repositories.StatusRepository.Repository;
using TaskManager.Repositories.TasksRepository.Interface;
using TaskManager.Repositories.TasksRepository.Repository;
using TaskManager.Repositories.UsersRepository.Interface;
using TaskManager.Repositories.UsersRepository.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string strConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DataContext>(option =>
{
    option.UseSqlServer(strConnection);
}
);

builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<ITasksRepository, TasksRepository>();
builder.Services.AddScoped<IStatusRepository, StatusRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
