using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Application.User.Add;
using Sat.Recruitment.Core.Contracts;
using Sat.Recruitment.Core.Dtos;
using Sat.Recruitment.Core.Interfaces;
using Sat.Recruitment.Core.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
    /// <summary>
    /// Controller for user-related operations.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        /// <summary>
        /// Adds a new user to the system.
        /// </summary>
        /// <param name="request">Request containing user information to be added.</param>
        /// <returns>Result of the operation, with added user information if successful.</returns>
        [HttpPost]
        public async Task<IOperationResult<UserDto>> Add(AddUserRequest request) {

            var validator = new AddUserRequestValidator();
            FluentValidation.Results.ValidationResult validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return await Task.FromResult(BasicOperationResult<UserDto>.Fail(errors));
            }

            var user = _mapper.Map<Core.Entities.User>(request);

            var response = await _userService.AddAsync(user);

            return await Task.FromResult(response);
        }
    }
}
