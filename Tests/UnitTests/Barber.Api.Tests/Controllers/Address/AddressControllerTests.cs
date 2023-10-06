using Barber.Api.Controllers;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.AutoMock;
using Barber.Application.Features.Addresses.Commands.CreateAddress;
using Barber.Application.Features.Addresses.Queries.GetAddressById;
using Times = Moq.Times;

namespace Barber.Api.Tests.Controllers.Address

{
    [Collection(nameof(AddressControllerAutoMockerCollection))]
        public class AddressControllerAutoMockerFixtureTests
        {

            readonly AddressControllerTestsAutoMockerFixture _addressControllerTestsAutoMockerFixture;
            private AutoMocker _mocker;
            private AddressController _addressController;


            public AddressControllerAutoMockerFixtureTests(AddressControllerTestsAutoMockerFixture addressControllerTestsAutoMockerFixture)
            {
                _addressControllerTestsAutoMockerFixture =  addressControllerTestsAutoMockerFixture;
                _addressController = _addressControllerTestsAutoMockerFixture.GenerateAndSetupAddressController();
                _mocker = _addressControllerTestsAutoMockerFixture.Mocker;
            }


            [Fact(DisplayName = "Get Address Successfully")]
            [Trait("Categoria", "Address Controller AutoMockFixture Tests")]
            public async Task AddressController_GetAddressById_Should_ReturnOkAddress()
            {
                // Arrange
                var query = _addressControllerTestsAutoMockerFixture.GenerateValidQuery();
                
                // Act
                var addressReturned = await _addressController.GetAddressById(query.CustomerId, query.AddressId);
                
                // Assert
                var actionResult = Assert.IsType<ActionResult<GetAddressByIdDetailDto>>(addressReturned);
                var okObjectResult = Assert.IsType<OkObjectResult>(actionResult.Result);
                var addressValue = Assert.IsAssignableFrom<GetAddressByIdDetailDto>(okObjectResult.Value);
                
                addressValue.Should().NotBeNull();
                
                _mocker.GetMock<IMediator>().Verify(m => m.Send(It.IsAny<GetAddressByIdDetailQuery>(), CancellationToken.None),
                    Times.Once);
            }

            [Fact(DisplayName = "Create Address Successfully")]
            [Trait("Categoria", "Address Controller AutoMockFixture Tests")]
            public async Task AddressController_CreateAddress_Should_ReturnCreatedAtRouteAddress()
            {
                // Arrange
                var command = _addressControllerTestsAutoMockerFixture.GenerateValidCommand();
                
                // Act
                var addressCreatedResponse = await _addressController.CreateAddress(command.CustomerId, command);
                
                
                // Assert
                var actionResult = Assert.IsType<ActionResult<CreateAddressCommandDto>>(addressCreatedResponse);
                var createdAtRouteResult = Assert.IsType<CreatedAtRouteResult>(actionResult.Result);
                var addressValue = Assert.IsAssignableFrom<CreateAddressCommandDto>(createdAtRouteResult.Value);
                
                _mocker.GetMock<IMediator>().Verify(m => m.Send(It.IsAny<CreateAddressCommand>(), CancellationToken.None),
                    Times.Once);
            }
           
    }
}

