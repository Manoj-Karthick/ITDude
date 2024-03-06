using ITDude.API.Interfaces;
using ITDude.API.Models.Data;
using ITDude.API.Repository;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ITDudeDBContext>(options => 
        options.UseSqlServer(builder.Configuration.GetConnectionString("ITDudeConnectionString")));
builder.Services.AddFluentEmail("test@test.com").AddSmtpSender(()=>new SmtpClient("localhost") 
            { 
                EnableSsl=false,
                DeliveryMethod=SmtpDeliveryMethod.Network,
                Port = 25
            });
builder.Services.AddTransient<IHabitService,HabitService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                                                                   .AllowAnyMethod()
                                                                    .AllowAnyHeader()));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
