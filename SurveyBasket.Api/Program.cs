using Mapster;
using MapsterMapper;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using SurveyBasket;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencies();

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