using System.Text.RegularExpressions;
using Barber.Application.Models;
using FluentValidation;

namespace Barber.Application.Features.Addresses.Commands.CreateTelephone;

public class CreateTelephoneCommandValidator : AbstractValidator<CreateTelephoneCommand>{
  public CreateTelephoneCommandValidator(){
    RuleFor(t => t.Number)
      .Cascade(CascadeMode.Stop)
      .NotEmpty()
      .WithMessage("Number tem que ser preenchido...")
      .MaximumLength(80)
      .WithMessage("Number possui um máximo de 80 caracteres...")
      .Must(IsValidPhoneNumber);

    RuleFor(a => a.Type)
      .IsInEnum()
      .WithMessage("Type inválido...");
  }

  private bool IsValidPhoneNumber(string numero){
    string pattern = @"^\+?\d{1,4}?\s?\d{2,5}\s?\d{4,5}-?\d{4}$";

    return Regex.IsMatch(numero, pattern);
  }
}
