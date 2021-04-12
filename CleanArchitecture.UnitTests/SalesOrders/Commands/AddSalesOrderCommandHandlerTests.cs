using AutoMapper;
using CleanArchitecture.Core.Application.Contracts.Persistance;
using CleanArchitecture.Core.Application.Features.Orders.Commands.AddSalesOrder;
using CleanArchitecture.Core.Application.Features.Orders.Queries.GetAllSalesOrder;
using CleanArchitecture.Core.Application.Profiles;
using CleanArchitecture.Core.Domain.Entities;
using CleanArchitecture.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using FluentValidation;
using FluentValidation.Results;

namespace CleanArchitecture.UnitTests.SalesOrders.Commands
{
    public class AddSalesOrderCommandHandlerTests
    {
        private readonly Mock<IAsyncRepository<SalesOrder>> _mockSalesOrderRepository;
        private readonly IMapper _mapper;

        public AddSalesOrderCommandHandlerTests()
        {
            _mockSalesOrderRepository = RepositoryMock.GetSalesOrderRepositoryMock();
            var configurationProvider = new MapperConfiguration(w =>
            {
                w.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task SalesOrder_AddAsync_IsSuccess()
        {
            var hanlder = new AddSalesOrderCommandHandler(_mockSalesOrderRepository.Object);
            await hanlder.Handle(new AddSalesOrderCommand("name"), CancellationToken.None);

            var getAllhandler = new GetAllSalesOrderQueryHandler(_mockSalesOrderRepository.Object, _mapper);
            var result = await getAllhandler.Handle(new GetAllSalesOrderQuery(), CancellationToken.None);
            result.Count().ShouldBe(5);
            result.ElementAt(4).Name.ShouldBe("name");
            result.ShouldAllBe(w => w.Id != null);
            result.ShouldAllBe(w => w.Id != Guid.Empty);
        }

        [Fact]
        public async Task SalesOrder_AddAsync_ValidateReturnSuccess()
        {
            var command = new AddSalesOrderCommand("name");

            // Imperative style of implementation
            var mock = new Mock<IValidator<AddSalesOrderCommand>>();
            mock.Setup(w => w.Validate(command)).Returns(new ValidationResult());

            var result = mock.Object.Validate(command);
            result.Errors.ShouldBeEmpty();
            result.Errors.Count().ShouldBe(0);
        }

        [Fact]
        public async Task SalesOrder_AddAsync_BreakValidationReturnsError()
        {
            var command = new AddSalesOrderCommand(string.Empty);
            var validator = new AddSalesOrderCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.ShouldBeGreaterThan(0);
        }
    }
}
