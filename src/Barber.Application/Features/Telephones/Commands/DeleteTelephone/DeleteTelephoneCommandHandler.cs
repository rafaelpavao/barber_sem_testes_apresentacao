using AutoMapper;
using MediatR;
using Barber.Domain.Entities;
using Barber.Application.Repositories;

namespace Barber.Application.Features.Addresses.Commands.DeleteTelephone;

public class DeleteTelephoneCommandHandler: IRequestHandler<DeleteTelephoneCommand, bool>
{
  private readonly ICustomerRepository _customerRepository;

  public DeleteTelephoneCommandHandler(ICustomerRepository customerRepository){
    _customerRepository = customerRepository;
  }

  public async Task<bool> Handle(DeleteTelephoneCommand request, CancellationToken cancellationToken){
    var telephoneFromDatabase = await _customerRepository.GetTelephoneById(request.CustomerId, request.TelephoneId);

    if(telephoneFromDatabase == null) return false;

    _customerRepository.DeleteTelephone(telephoneFromDatabase);
    await _customerRepository.SaveChangesAsync();

    return true;
  }
}