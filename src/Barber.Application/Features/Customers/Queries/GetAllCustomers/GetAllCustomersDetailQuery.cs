using MediatR;

namespace Barber.Application.Features.Customers.Queries.GetAllCustomers;

public class GetAllCustomersDetailQuery : IRequest<IEnumerable<GetAllCustomersDetailDto>>{
  
}