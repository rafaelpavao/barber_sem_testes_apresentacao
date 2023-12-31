using System.Reflection;
using System.Runtime.CompilerServices;
using Barber.Application.Features.Addresses.Commands.CreateAddress;
using Barber.Application.Features.Addresses.Commands.CreateTelephone;
using Barber.Application.Features.Addresses.Commands.UpdateAddress;
using Barber.Application.Features.Addresses.Commands.UpdateTelephone;
using Barber.Application.Features.Customers.Commands.CreateNewCustomer;
using Barber.Application.Features.Customers.Commands.UpdateCustomer;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Barber.Application.Extensions;

public static class ApplicationServicesRegistration{
  public static IServiceCollection AddApplicationServices(this IServiceCollection services){
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

    services.AddScoped<IValidator<CreateNewCustomerCommand>, CreateNewCustomerCommandValidator>();
    services.AddScoped<IValidator<UpdateCustomerCommand>, UpdateCustomerCommandValidator>();

    services.AddScoped<IValidator<CreateAddressCommand>, CreateAddressCommandValidator>();
    services.AddScoped<IValidator<UpdateAddressCommand>, UpdateAddressCommandValidator>();

    services.AddScoped<IValidator<CreateTelephoneCommand>, CreateTelephoneCommandValidator>();
    services.AddScoped<IValidator<UpdateTelephoneCommand>, UpdateTelephoneCommandValidator>();

    return services;
  }
}