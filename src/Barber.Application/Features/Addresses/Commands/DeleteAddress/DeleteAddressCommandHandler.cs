using AutoMapper;
using MediatR;
using Barber.Domain.Entities;
using Barber.Application.Repositories;

namespace Barber.Application.Features.Addresses.Commands.DeleteAddress;

public class DeleteAddressCommandHandler: IRequestHandler<DeleteAddressCommand, bool>
{
  private readonly ICustomerRepository _customerRepository;

  public DeleteAddressCommandHandler(ICustomerRepository customerRepository){
    _customerRepository = customerRepository;
  }

  public async Task<bool> Handle(DeleteAddressCommand request, CancellationToken cancellationToken){
    var addressFromDatabase = await _customerRepository.GetAddressById(request.CustomerId, request.AddressId);

    if(addressFromDatabase == null) return false;

    _customerRepository.DeleteAddress(addressFromDatabase);
    await _customerRepository.SaveChangesAsync();

    return true;
  }
}