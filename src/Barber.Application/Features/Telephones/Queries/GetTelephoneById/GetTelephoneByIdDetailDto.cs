using Barber.Application.Models;

namespace Barber.Application.Features.Addresses.Queries.GetTelephoneById;

public class GetTelephoneByIdDetailDto{
  public int Id { get; set; }
  public string Number { get; set; } = string.Empty;
  public TelephoneTypeDto Type { get; set; }
}