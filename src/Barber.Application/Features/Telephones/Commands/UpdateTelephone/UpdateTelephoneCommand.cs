using Barber.Application.Models;
using MediatR;

namespace Barber.Application.Features.Addresses.Commands.UpdateTelephone;

public class UpdateTelephoneCommand : IRequest<UpdateTelephoneCommandResponse>{
  public int Id { get; set; }
  public string Number { get; set; } = string.Empty;
  public TelephoneTypeDto Type { get; set; }
  public int CustomerId { get; set; }
}