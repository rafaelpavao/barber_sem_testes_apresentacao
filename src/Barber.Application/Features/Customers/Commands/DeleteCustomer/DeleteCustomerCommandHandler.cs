using AutoMapper;
using MediatR;
using Barber.Domain.Entities;
using Barber.Application.Repositories;

namespace Barber.Application.Features.Customers.Commands.DeleteCustomer;

public class DeleteCustomerCommandHandler: IRequestHandler<DeleteCustomerCommand, bool>
{
    private readonly ICustomerRepository _customerRepository;

    public DeleteCustomerCommandHandler(ICustomerRepository customerRepository){
        _customerRepository = customerRepository;
    }

    public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken){
      var customerFromDatabase = await _customerRepository.GetCustomerById(request.CustomerId);

      if(customerFromDatabase == null) return false;

      _customerRepository.DeleteCustomer(customerFromDatabase);
      await _customerRepository.SaveChangesAsync();

      return true;
    }
}