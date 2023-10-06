using Bogus;
using Bogus.DataSets;
using Barber.Domain.Entities;
using Bogus.Extensions.Brazil;

namespace Barber.Domain.Tests.Entities.Customers{
    public class CustomerTestsFixture 
    {
        public Customer GenerateValidCustomer()
        {
            var genero = new Faker().PickRandom<Name.Gender>();
            var anyValidDate = DateOnly.FromDateTime(new Faker().Date.Past(80, DateTime.Now.AddYears(-18)));

            var customer = new Faker<Customer>("pt_BR")
                .CustomInstantiator(f => new Customer{
                    Id = f.IndexFaker+1,
                    Name = f.Name.FullName(genero),
                    BirthdayDate = anyValidDate,
                    CPF = f.Person.Cpf()})
                .RuleFor(c => c.Email, (f, c) =>
                      f.Internet.Email(c.Name.ToLower()));

            return customer;
        }

        public Customer GenerateInvalidCustomer()
        {
            var genero = new Faker().PickRandom<Name.Gender>();
            var anyValidDate = DateOnly.FromDateTime(new Faker().Date.Past(1, DateTime.Now.AddYears(1)));

            var customer = new Faker<Customer>("pt_BR")
                .CustomInstantiator(f => new Customer{
                    Id = f.IndexFaker+1,
                    Name = f.Name.FullName(genero),
                    BirthdayDate = anyValidDate,
                    CPF = f.Person.Cpf()})
                .RuleFor(c => c.Email, (f, c) =>
                    f.Internet.Email(c.Name.ToLower()));

            return customer;
        }
        
    }
}


