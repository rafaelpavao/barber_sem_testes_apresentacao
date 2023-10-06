using Barber.Api.Controllers;
using Barber.Application.Features.Customers.Queries.GetAllCustomers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq.AutoMock;

namespace Barber.Api.Tests.Controllers.Customer;

public class CustomerControllerTests : IClassFixture<CustomerControllerTestsFixture>
{

    readonly CustomerControllerTestsFixture _fixture;
    private AutoMocker _mocker;
    private CustomerController _customerController;

    public CustomerControllerTests(CustomerControllerTestsFixture fixture)
    {
        _fixture = fixture;
        _customerController = _fixture.GenerateAndSetupCustomerController();
        _mocker = _fixture.Mocker;
    }


    [Fact(DisplayName = "Get all Customers Successfully" )]
    [Trait("Categoria", "Customer Controller Tests")]
    public async Task GetAllCustomers_WhenCustomersAreNotNull_ShouldReturnOkCustomers()
    {

        // Arrange
        
        // Act
        var customerResponse = await _customerController.GetAllCustomers();
        
        // Assert

        var actionResult = Assert.IsType<ActionResult<IEnumerable<GetAllCustomersDetailDto>>>(customerResponse);
        var okObjectResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var customerValue = Assert.IsAssignableFrom<IEnumerable<GetAllCustomersDetailDto>>(okObjectResult.Value);
        
        customerValue.Count().Should().BeGreaterThan(0);
    }


}