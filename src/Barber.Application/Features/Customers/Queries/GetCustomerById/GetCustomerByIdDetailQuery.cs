using MediatR;

namespace Barber.Application.Features.Customers.Queries.GetCustomerById;

public class GetCustomerByIdDetailQuery : IRequest<GetCustomerByIdDetailDto>{
  public int CustomerId { get; set; }
}