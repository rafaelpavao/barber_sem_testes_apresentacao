using MediatR;

namespace Barber.Application.Features.Addresses.Queries.GetAddressById;

public class GetAddressByIdDetailQuery : IRequest<GetAddressByIdDetailDto>{
  public int CustomerId { get; set; }
  public int AddressId { get; set; }
}