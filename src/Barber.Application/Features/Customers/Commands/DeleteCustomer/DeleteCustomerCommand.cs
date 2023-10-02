using Barber.Application.Models;
using MediatR;

namespace Barber.Application.Features.Customers.Commands.DeleteCustomer;

public class DeleteCustomerCommand : IRequest<bool>{
  public int CustomerId { get; set; }
}