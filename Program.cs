using Application.Commands;
using Application.Commands.Handler;
using AutoMapper;
using Domain.Repositories;
using Infra.Data.Base.UnitOfWork;
using Infra.Data.Interfaces;
using Infra.Data.Repository;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RazorApp.Application.Commands;
using RazorApp.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOptions();
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Default") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddRazorPages();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddTransient<IStudentRepository, StudentRepository>();

builder.Services.AddTransient<IRequestHandler<EditStudentCommand, CommandResult>, EditStudentCommandHandler>();
builder.Services.AddTransient<IRequestHandler<CreateStudentCommand, CommandResult>, CreateStudentCommandHandler>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

builder.Services.AddAutoMapper(typeof(CreateStudentCommand));
builder.Services.AddAutoMapper(typeof(EditStudentCommand));


builder.Services.AddCors(o =>
{
    o.AddPolicy("Everything", p => { p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin(); });
});

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddMaps(new[] {
            $"Application.Reads"
        });
});

var mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
