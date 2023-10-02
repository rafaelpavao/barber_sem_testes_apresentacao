using AutoMapper;
using Barber.Domain.Entities;
using Barber.Application.Features.Addresses.Commands.CreateAddress;
using Barber.Application.Features.Addresses.Commands.UpdateAddress;
using Barber.Application.Features.Addresses.Queries.GetAddressById;
using Barber.Application.Models;

namespace Barber.Application.Profiles;

public class AddressProfile : Profile{
  public AddressProfile(){
    CreateMap<Address, AddressToReturnDto>().ReverseMap();
    CreateMap<AddressToCreateDto, Address>().ReverseMap();
    CreateMap<AddressToCreateDto, AddressToReturnDto>().ReverseMap();
    CreateMap<Address, AddressToUpdateDto>().ReverseMap();

    //CQRS
    //Queries
    CreateMap<Address, GetAddressByIdDetailDto>().ReverseMap();

    //Commands
    CreateMap<Address, CreateAddressCommand>().ReverseMap();
    CreateMap<Address, CreateAddressCommandDto>().ReverseMap();
    CreateMap<Address, UpdateAddressCommand>().ReverseMap();
  }
}