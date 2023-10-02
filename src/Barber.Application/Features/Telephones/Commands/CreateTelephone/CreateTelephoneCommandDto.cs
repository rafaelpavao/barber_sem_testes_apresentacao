using Barber.Application.Models;

namespace Barber.Application.Features.Addresses.Commands.CreateTelephone;

public class CreateTelephoneCommandDto{
  public int Id { get; set; }
  public string Number { get; set; } = string.Empty;
  public TelephoneTypeDto Type { get; set; }
}