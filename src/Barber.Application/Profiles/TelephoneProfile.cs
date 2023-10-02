using AutoMapper;
using Barber.Domain.Entities;
using Barber.Application.Features.Addresses.Commands.CreateTelephone;
using Barber.Application.Features.Addresses.Commands.UpdateTelephone;
using Barber.Application.Features.Addresses.Queries.GetTelephoneById;
using Barber.Application.Models;

namespace Barber.Application.Profiles;

public class TelephoneProfile : Profile{
  public TelephoneProfile(){
    CreateMap<Telephone, TelephoneToReturnDto>().ReverseMap();
    CreateMap<TelephoneToCreateDto, TelephoneToReturnDto>().ReverseMap();
    CreateMap<TelephoneToCreateDto, Telephone>().ReverseMap();
    CreateMap<TelephoneToUpdateDto, Telephone>().ReverseMap();
    CreateMap<TelephoneTypeDto, TelephoneType>();

    //CQRS
    //Queries
    CreateMap<Telephone, GetTelephoneByIdDetailDto>().ReverseMap();

    //Commands
    CreateMap<Telephone, CreateTelephoneCommand>().ReverseMap();
    CreateMap<Telephone, CreateTelephoneCommandDto>().ReverseMap();
    CreateMap<Telephone, UpdateTelephoneCommand>().ReverseMap();
  }
}