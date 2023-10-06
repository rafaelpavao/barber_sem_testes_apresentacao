using AutoMapper;
using Barber.Domain.Entities;
using Barber.Application.Features.Addresses.Commands.CreateAddress;
using Barber.Persistence.Repositories;
using FluentAssertions;
using FluentValidation;
using Moq;
using Moq.AutoMock;

namespace Barber.Application.Tests.Features.Addresses.Commands.CreateAddress;

public class CreateAddressCommandHandlerTests :IClassFixture<CreateAddressCommandHandlerTestsFixture>
{
    readonly CreateAddressCommandHandlerTestsFixture _fixture;
    private AutoMocker _mocker;
    private CreateAddressCommandHandler _createAddressCommandHandler;

    public CreateAddressCommandHandlerTests(CreateAddressCommandHandlerTestsFixture fixture)
    {
        _fixture = fixture;
        _createAddressCommandHandler = _fixture.GenerateAndSetupCommandHandler();
        _mocker = _fixture.Mocker;
    }
    
    [Fact(DisplayName = "Handle Create Address Successfully")]
    [Trait("Category", "Create Address Command Handler Tests")]
    public async void Handle_WhenCommandIsValidAndCustomerExists_Should_ReturnCreateAddressCommandResponse()
    {
        // Arrange
        var command = _fixture.GenerateValidCommand();
        var repo = _mocker.GetMock<ICustomerRepository>();
        var mapper = _mocker.GetMock<IMapper>();
        var validator = _mocker.GetMock<IValidator<CreateAddressCommand>>();
             
        // Act
        var addressHandled = await _createAddressCommandHandler.Handle(command, CancellationToken.None);
        
             
        // Assert
        validator.Verify(v => v.Validate(It.IsAny<CreateAddressCommand>()), Times.Once);
        
        repo.Verify(r => r.GetCustomerWithAddressesById(It.IsAny<int>()), Times.Once);
        repo.Verify(r => r.AddAddress(It.IsAny<Customer>(), It.IsAny<Address>()), Times.Once);
        
        mapper.Verify(m => m.Map<CreateAddressCommandDto>(It.IsAny<Address>()), Times.Once);
        mapper.Verify(m => m.Map<Address>(It.IsAny<CreateAddressCommand>()), Times.Once);
        
        addressHandled.Address.Should().NotBeNull();
        addressHandled.Address.Should().BeOfType<CreateAddressCommandDto>();
        addressHandled.IsSuccessful.Should().BeTrue();
    }
    
}