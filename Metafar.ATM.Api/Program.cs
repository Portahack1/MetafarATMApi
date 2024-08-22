using FluentValidation;
using MediatR;
using Metafar.ATM.Api;
using Metafar.ATM.Application;
using Metafar.ATM.Application.DataBase.User.Commands.CreateTransaction;
using Metafar.ATM.Application.DataBase.User.Queries;
using Metafar.ATM.Application.Validators;
using Metafar.ATM.Domain.Models;
using Metafar.ATM.External;
using Metafar.ATM.Persistence;
using Metafar.ATM.Persistence.DataBase;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddWebApi()
    .AddApplication()
    .AddExternal(builder.Configuration)
    .AddPersistence(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly)
    .AddBehavior<IPipelineBehavior<GetTokenByCardNumberAndPinQuery, Response<string>>, ValidationBehavior<GetTokenByCardNumberAndPinQuery, string>>()
    .AddBehavior<IPipelineBehavior<CreateTransactionCommand, Response<bool>>, ValidationBehavior<CreateTransactionCommand, bool>>();
});

builder.Services.AddValidatorsFromAssembly(typeof(AssemblyReference).Assembly);

var app = builder.Build();

// migrar database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DataBaseService>();
    context.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
