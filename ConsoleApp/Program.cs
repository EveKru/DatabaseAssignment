using ConsoleApp;
using Infrastructure.Contexts;
using Infrastructure.Dtos;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddDbContext<DataContext>(x => x.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Education\\C-Sharp\\DatabaseAssignment\\EFC\\Infrastructure\\Data\\local_database.mdf;Integrated Security=True;Connect Timeout=30"));

    services.AddScoped<AdressRepository>();
    services.AddScoped<CategoryRepository>();
    services.AddScoped<CustomerRepository>();
    services.AddScoped<ProductRepository>();
    services.AddScoped<RoleRepository>();

    services.AddScoped<AdressService>();
    services.AddScoped<CategoryService>();
    services.AddScoped<CustomerService>();
    services.AddScoped<ProductService>();
    services.AddScoped<RoleService>();

    services.AddScoped<ConsoleUI>();


}).Build();

var consoleUI = builder.Services.GetRequiredService<ConsoleUI>();

consoleUI.MainMenuUI();