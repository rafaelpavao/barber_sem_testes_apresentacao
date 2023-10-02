using MediatR;

namespace Barber.Application.Features.Customers.Queries.GetCustomerWithAddressesAndTelephonesById;

public class GetCustomerWithAddressesAndTelephonesByIdDetailQuery : IRequest<GetCustomerWithAddressesAndTelephonesByIdDetailDto>{
  public int CustomerId { get; set; }
}