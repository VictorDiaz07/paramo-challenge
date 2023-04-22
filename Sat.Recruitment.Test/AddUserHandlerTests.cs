using AutoMapper;
using FluentValidation.Results;
using Moq;
using Sat.Recruitment.Application.User.Add;
using Sat.Recruitment.Core.Contracts;
using Sat.Recruitment.Core.Dtos;
using Sat.Recruitment.Core.Entities;
using Sat.Recruitment.Core.Models;
using Sat.Recruitment.Core.Services;
using Sat.Recruitment.Test.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Sat.Recruitment.Test
{
    public class AddUserHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly UserService _userService;

        public AddUserHandlerTests()
        {
            var fixture = new TestFixture();
            _mapper = fixture.Mapper;
            _userService = new UserService(new MockGenericRepository<User>(new List<User>()));
        }

        [Fact]
        public async Task Add_ValidRequest_ReturnsSuccessResult()
        {
            // Arrange
            var user = new User
            {
                Name = "Francis Francisco",
                Email = "FrancisF@gmail.com",
                Address = "Av. Delgado",
                Phone = "+18496571265",
                UserType = Core.Enums.UserType.Normal,
                Money = 66
            };
            var expectedResult = BasicOperationResult<UserDto>.Ok();

            // Act
            var result = await _userService.AddAsync(user);

            // Assert
            Assert.Equal(expectedResult.Success, result.Success);
        }

        [Fact]
        public async Task Add_DuplicatedUser_ReturnsErrorResult()
        {
            // Arrange
            var user = new User
            {
                Name = "Agustina",
                Email = "Agustina@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = Core.Enums.UserType.Normal,
                Money = 124
            };
            var expectedResult = BasicOperationResult<UserDto>.Fail("The user is duplicated");



            // Act
            var firstResult = await _userService.AddAsync(user);
            var secondResult = await _userService.AddAsync(user);

            // Assert
            Assert.False(secondResult.Success);
            Assert.Equal(expectedResult.Messages, secondResult.Messages);
        }
    }
}
