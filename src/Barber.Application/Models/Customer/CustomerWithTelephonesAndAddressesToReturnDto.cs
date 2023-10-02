using Barber.Domain.Entities;

namespace Barber.Application.Models;

public class CustomerWithTelephonesAndAddressesToReturnDto : CustomerToManipulationDto{
  public int Id { get; set; }
  public ICollection<TelephoneToReturnDto> Telephones { get; set; } = new List<TelephoneToReturnDto>();
  public ICollection<AddressToReturnDto> Addresses { get; set; } = new List<AddressToReturnDto>();
}