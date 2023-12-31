using Barber.Application.Models;

namespace Barber.Application.Features.Customers.Queries.GetCustomerWithAddressesAndTelephonesById;

public class GetCustomerWithAddressesAndTelephonesByIdDetailDto{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public DateOnly BirthdayDate { get; set; }
  public GenderDto Gender { get; set; }
  public string CPF { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public ICollection<TelephoneToReturnDto> Telephones { get; set; } = new List<TelephoneToReturnDto>();
  public ICollection<AddressToReturnDto> Addresses { get; set; } = new List<AddressToReturnDto>();
}