using AutoMapper;
using Barber.Domain.Entities;
using Barber.Application.Features.Customers.Commands.CreateNewCustomer;
using Barber.Application.Features.Customers.Commands.UpdateCustomer;
using Barber.Application.Features.Customers.Queries.GetAllCustomers;
using Barber.Application.Features.Customers.Queries.GetCustomerById;
using Barber.Application.Features.Customers.Queries.GetCustomersWithTelephones;
using Barber.Application.Features.Customers.Queries.GetCustomerWithAddressesAndTelephonesById;
using Barber.Application.Models;

namespace Barber.Application.Profiles;

public class CustomerProfile : Profile{
  public CustomerProfile(){
    CreateMap<Customer, CustomerToReturnDto>().ReverseMap();
    CreateMap<Customer, CustomerWithTelephonesAndAddressesToReturnDto>().ReverseMap();
    CreateMap<CustomerToCreateDto, Customer>().ReverseMap();
    CreateMap<CustomerToCreateDto, CustomerWithTelephonesAndAddressesToReturnDto>().ReverseMap();
    CreateMap<CustomerWithTelephonesAndAddressesToReturnDto, Customer>().ReverseMap();
    CreateMap<CustomerToUpdate, Customer>().ReverseMap();
    CreateMap<Customer, CustomerWithTelephonesToReturnDto>().ReverseMap();
    
    CreateMap<Gender, GenderDto>().ReverseMap();

    //CQRS

    // Queries:
    CreateMap<Customer, GetAllCustomersDetailDto>().ReverseMap();
    CreateMap<Customer, GetCustomerByIdDetailDto>().ReverseMap();
    CreateMap<Customer, GetCustomersWithTelephonesDetailDto>().ReverseMap();
    CreateMap<Customer, GetCustomerWithAddressesAndTelephonesByIdDetailDto>().ReverseMap();

    // Commands:
    CreateMap<Customer, CreateNewCustomerCommand>().ReverseMap();
    CreateMap<Customer, CreateNewCustomerCommandDto>().ReverseMap();
    CreateMap<Customer, UpdateCustomerCommand>().ReverseMap();
  }
}