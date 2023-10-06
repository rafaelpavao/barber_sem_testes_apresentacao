using Barber.Persistence.Entities;
using Barber.Domain.Entities;
using Barber.Persistence.Repositories;
using FluentAssertions;

namespace Barber.Persistence.Tests.Repositories;

public class CustomerRepositoryTests : IClassFixture<CustomerRepositoryTestsFixture>
{
    private readonly CustomerRepositoryTestsFixture _fixture;
    private CustomerRepository _repo;
    private CustomerContext _context;

    public CustomerRepositoryTests(CustomerRepositoryTestsFixture fixture)
    {
        _fixture = fixture;
        _repo = _fixture.GenerateAndSetupCustomerRepository();
        _context = _fixture.Context;
    }
    
    [Trait("Category", "Customer Repository Tests")]
    [Fact(DisplayName = "Add Customer Test")]
    public async void AddCustomer_WhenCustomerIsValid_Should_CreateCustomerInDb()
    {
        // Arrange
        var customer = _fixture.GenerateCustomers(1).FirstOrDefault();
        
        // Act
        _repo.AddCustomer(customer);
        await _repo.SaveChangesAsync();
        var customerFromDb = _context.Customers.FirstOrDefault();

        //Assert
        customerFromDb.Should().NotBeNull();
        customerFromDb.Should().BeOfType<Customer>();
        Assert.Equal(customer, customerFromDb);

    }

    [Trait("Category", "Customer Repository Tests")]
    [Fact(DisplayName = "Get All Customers Test")]
    public async void GetAllCustomer_WhenCustomersExistInDb_Should_ReturnCollectionOfCustomers()
    {
        // Arrange
        var customers = _fixture.GenerateCustomers(11);
        
        // Act
        _context.Customers.AddRange(customers);
        await _repo.SaveChangesAsync();
        var customersFromDb = await _repo.GetAllCustomers();

        //Assert
        customersFromDb.Should().NotBeNull();
        customersFromDb.Should().NotBeEmpty();
        customersFromDb.Count().Should().BeGreaterThan(10);
        customersFromDb.Should().BeOfType<List<Customer>>();
        customersFromDb.Equals(customers);
    }
    
    [Trait("Category", "Customer Repository Tests")]
    [Fact(DisplayName = "Get Customer by Id Test")]
    public async void GetCustomerById_WhenCustomersExistInDb_Should_ReturnCorrectCustomer()
    {
        // Arrange
        var customer = _fixture.GenerateCustomers(1).FirstOrDefault();
        
        // Act
        _context.Customers.Add(customer);
        await _repo.SaveChangesAsync();
        var customerFromDb = await _repo.GetCustomerById(customer.Id);

        //Assert
        customerFromDb.Should().NotBeNull();
        customerFromDb.Should().BeOfType<Customer>();
        customerFromDb.Id.Equals(customer.Id);
        customerFromDb.Equals(customer);
    }
}