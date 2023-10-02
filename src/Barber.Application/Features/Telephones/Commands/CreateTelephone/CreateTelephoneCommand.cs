using Barber.Application.Models;
using MediatR;

namespace Barber.Application.Features.Addresses.Commands.CreateTelephone;

public class CreateTelephoneCommand : IRequest<CreateTelephoneCommandResponse>{
  public string Number { get; set; } = string.Empty;
  public TelephoneTypeDto Type { get; set; }
  public int CustomerId { get; set; }
}